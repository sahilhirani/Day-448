using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidMover : MonoBehaviour {
	//could probably be random for each asteroid?
	//public float asteroidSpeed;
	public float elapsedTime;

	void Start() {
		elapsedTime = Time.realtimeSinceStartup / 2;
		//multiply by time
		GetComponent<Rigidbody> ().velocity = transform.forward * -Random.Range (1, 2) * elapsedTime;
	}
}
