using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	//asteroid object in the game
	public GameObject asteroid;
	//spawn location for the asteroid
	public Vector3 spawnValues;
	//number of asteroids that appear for every wave
	public int asteroidCount;
	//the waiting time for each asteroid
	public float spawnWait;
	//the waiting time for the user to prepare for the game to begin
	public float startWait;
	//the waiting time for each wave of asteroids
	public float waveWait;
	//the rate at which the waveWait decreases to make the game harder
	private float difficulty = 0.0017f;
	//text that holds the scre
	public Text scoreText;
	//text that holds the "Game Over" message
	public Text gameOverText;
	//text that holds the option to restart the game
	public Text restartText;
	//the players score
	private int score;
	//value that determines if player resarts
	private bool restart;
	//value that determines if game is over
	private bool gameOver;

	/* @brief Instantiates any defined objects. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
	** @pre The game objects are valid and the game is prepared to be run.
	** @post Score count is started and the game begins spawning asteroids.
	** @return None*/
	void Start() {
		restart = false;
		gameOver = false;
		gameOverText.text = "";
		restartText.text = "";
		score = 0;
		updateScore ();
		StartCoroutine(spawnWaves ());
	}

	/* @brief Updates after every game frame to create asteroids for the user to dodge/shoot. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
	** @pre None
	** @post The game is updated every frame.
	** @return None*/
	void Update(){
		//checks to see if the user has selected to restart the game
		if (restart) {
			//if user has pressed "R" the game restarts
			if (Input.GetKeyDown (KeyCode.R))
			{
				//game restarts
				Application.LoadLevel (Application.loadedLevel);
			}
		}

	}

	/* @brief Spawns waves of asteroids. Allows for there to be a wait time before each wave.
	** @pre Method is called in the Start() function.
	** @post Asteroid waves are spawned with a decreasing wave waiting time.
	** @return a new WaitForSeconds objects that pauses the game*/
	IEnumerator spawnWaves() {
		yield return new WaitForSeconds (startWait);

		Debug.Log (Time.time);

		while(true) {
			score += Mathf.CeilToInt(Time.realtimeSinceStartup);
			updateScore ();
			for (int i = 0; i < asteroidCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 0.0f, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (asteroid, spawnPosition, spawnRotation);
				spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 0.0f, spawnValues.z);
				Instantiate (asteroid, spawnPosition, spawnRotation);
				score += Mathf.CeilToInt(Time.realtimeSinceStartup);
				updateScore ();
				if (gameOver) {
					updateScore ();
					break;
				}
				yield return new WaitForSeconds (spawnWait);
			}
			difficulty = difficulty + 0.0005f;
			waveWait = waveWait - difficulty;
			asteroidCount = asteroidCount + 1;
			if (asteroidCount > 20) {
				asteroidCount = 10;
			}
			if (waveWait <= 0.12f) {
				waveWait = 0.2f;
			}
			yield return new WaitForSeconds (waveWait);
			if (gameOver) {
				restartText.text = "To Restart press 'R'";
				restart = true;
				updateScore ();
				break;
			}
		}
}

	/* @brief Increments the score as the user progresses through the game.
	** @pre A valid new score is passed in.
	** @post The score is updated.
	** @return None*/
	public void addScore(int newScoreValue){
		score += newScoreValue;
		updateScore ();
	}

	/* @brief The score on the game screen is updated.
	** @pre None
	** @post Score is updated for the user to see.
	** @return None*/
	void updateScore() {
		scoreText.text = "SCORE: " + score.ToString();
	}

	/* @brief Displays the "Game Over" text after the user's ship is destroyed.
	** @pre None
	** @post The user is notified that the game is over and they are able to view their final score.
	** @return None*/
	public void GameOver(){
		gameOverText.text = "Game Over!";
		gameOver = true;
		scoreText.text = "";
	}


}
