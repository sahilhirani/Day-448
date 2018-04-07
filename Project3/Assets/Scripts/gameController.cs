using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {
	public GameObject asteroid;
	public Vector3 spawnValues;
	public int asteroidCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	private float difficulty = 0.002f;

	void Start() {
		StartCoroutine(spawnWaves ());
	}

	IEnumerator spawnWaves() {
		yield return new WaitForSeconds (startWait);

		Debug.Log (Time.time);

		while(true) {
			//asteroidCount = (asteroidCount * Mathf.CeilToInt(Time.realtimeSinceStartup));
			difficulty = difficulty + 0.0001f;
			waveWait = waveWait - difficulty;
			asteroidCount = asteroidCount + 1;
			if (asteroidCount > 20) {
				asteroidCount = 10;
			}
			if (waveWait <= 0.12f) {
				waveWait = 0.2f;
			}
			for (int i = 0; i < asteroidCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 0.0f, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (asteroid, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (waveWait);

			}
		}
	}
}


