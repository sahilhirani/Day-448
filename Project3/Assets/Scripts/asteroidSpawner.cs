using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	private bool gameover;
	public GameController gameController;
	
	//the players score
	private int score;
	// Use this for initialization
	void Start () {
		gameover = false;
		StartCoroutine(spawnWaves());
	}
	
	// Update is called once per frame
	void Update () {
		gameover = gameController.GO ();
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
		
}
