using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject asteroid;
	public Vector3 spawnValues;
	public int asteroidCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	private float difficulty = 0.0017f;
	public Text scoreText;
	public Text gameOverText;
	public Text restartText;
	private int score;
	private bool restart;
	private bool gameOver;

	void Start() {
		restart = false;
		gameOver = false;
		gameOverText.text = "";
		restartText.text = "";
		score = 0;
		updateScore ();
		StartCoroutine(spawnWaves ());
	}

	void Update(){
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}

	}

	IEnumerator spawnWaves() {
		yield return new WaitForSeconds (startWait);

		Debug.Log (Time.time);

		while(true) {
			//asteroidCount = (asteroidCount * Mathf.CeilToInt(Time.realtimeSinceStartup));
			score += Mathf.CeilToInt(Time.realtimeSinceStartup);
			updateScore ();
			for (int i = 0; i < asteroidCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 0.0f, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (asteroid, spawnPosition, spawnRotation);
				score += Mathf.CeilToInt(Time.realtimeSinceStartup);
				updateScore ();
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
				break;
			}
		}
}

	public void addScore(int newScoreValue){
		score += newScoreValue;
		updateScore ();
	}
	void updateScore() {
		scoreText.text = "Score: " + score.ToString();
	}
	public void GameOver(){
		gameOverText.text = "Game Over!";
		gameOver = true;
		scoreText.text = "";
	}


}
