using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidMover : MonoBehaviour {
	//could probably be random for each asteroid?
	//public float asteroidSpeed;
	private float speed;

	void Start() {
		speed = -5.0f;
		//multiply by time
		GetComponent<Rigidbody> ().velocity = transform.forward * speed * Random.Range (2, 6);
	}
}
