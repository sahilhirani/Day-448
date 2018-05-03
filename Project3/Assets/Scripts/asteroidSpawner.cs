using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class asteroidSpawner : MonoBehaviour {
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
	//boolean for whether the game is over or not
	private bool gameover;
	//the actual game controller where everything runs
	public GameController gameController;
	//the in-game score
	public ScoreTracker scoreTracker;
	//array of game objects for all 5 powerups
	public GameObject[] powerUps;
	private int randomNum;
	private int spawnNum = 2000;
	public int difficultyNum = 0;

	//the players score
	private int score;
	
	/* @brief Instantiates any defined objects. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
	** @pre The game objects are valid and the game begins spawning them.
	** @post Asteroids and powerups are spawned into the game.
	** @return None*/
	void Start () {
		gameover = false;
		Scene currentScene = SceneManager.GetActiveScene ();
		string sceneName = currentScene.name;

		if (sceneName == "Easy") {
			StartCoroutine (spawnWavesE ());
		} else if (sceneName == "Regular") {
			StartCoroutine (spawnWaves ());
		} else if (sceneName == "Insane") {
			StartCoroutine (spawnWavesI ());
		} else if (difficultyNum == 0) {
			StartCoroutine (spawnWaves ());
		}

	}

	/* @brief Updates after every game frame to create powerups for the user. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
	** @pre None
	** @post The game is updated every frame.
	** @return None*/
	void Update () {
		gameover = gameController.GO ();
		if (((scoreTracker.score >= spawnNum)) && (scoreTracker.score != 0)) {
			//increase the spawn score for asteroid by 2x
			spawnNum = spawnNum * 2;
			spawnPU ();
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
			for (int i = 0; i < asteroidCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 0.0f, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (asteroid, spawnPosition, spawnRotation);
				spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 0.0f, spawnValues.z);
				Instantiate (asteroid, spawnPosition, spawnRotation);

				if (gameover) {
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
			if (gameover) {
				break;
			}
		}
	}

	/* @brief Spawns waves of asteroids. Allows for there to be a wait time before each wave.
	** @pre Method is called in the Start() function.
	** @post Asteroid waves are spawned with a decreasing wave waiting time.
	** @return a new WaitForSeconds objects that pauses the game*/
	IEnumerator spawnWavesE() {
		yield return new WaitForSeconds (startWait);

		Debug.Log (Time.time);

		while(true) {
			for (int i = 0; i < asteroidCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 0.0f, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (asteroid, spawnPosition, spawnRotation);

				if (gameover) {
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
			if (gameover) {
				break;
			}
		}
	}

	/* @brief Spawns waves of asteroids. Allows for there to be a wait time before each wave.
	** @pre Method is called in the Start() function.
	** @post Asteroid waves are spawned with a decreasing wave waiting time.
	** @return a new WaitForSeconds objects that pauses the game*/
	IEnumerator spawnWavesI() {
		yield return new WaitForSeconds (startWait);

		Debug.Log (Time.time);

		while(true) {
			for (int i = 0; i < asteroidCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 0.0f, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (asteroid, spawnPosition, spawnRotation);
				spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 0.0f, spawnValues.z);
				Instantiate (asteroid, spawnPosition, spawnRotation);
				spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 0.0f, spawnValues.z);
				Instantiate (asteroid, spawnPosition, spawnRotation);
				spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 0.0f, spawnValues.z);
				Instantiate (asteroid, spawnPosition, spawnRotation);
				if (gameover) {
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
			if (gameover) {
				break;
			}
		}
	}	

	/* @brief Instantiates the power ups so that the player can use them.
	** @pre None.
	** @post A random power up is instantiated into the game.
	** @return None*/
	void spawnPU(){
		//the power up's spawn position in the game
		Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 0.0f, spawnValues.z);
		//the "random" index for the power up array
		randomNum = Mathf.RoundToInt (Random.Range (0, 5));
		//the rotation value for the power up
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (powerUps [randomNum], spawnPosition, spawnRotation);
	}
}