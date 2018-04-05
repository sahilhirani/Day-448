using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidMover : MonoBehaviour {
	//could probably be random for each asteroid?
	//public float asteroidSpeed;
	private float elapsedTime;

	void Start() {
		elapsedTime = -5.0f;
		//multiply by time
		GetComponent<Rigidbody> ().velocity = transform.forward * elapsedTime;//* -Random.Range (1, 2) * elapsedTime;
	}
}
