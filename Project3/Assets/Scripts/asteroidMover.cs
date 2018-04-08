using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidMover : MonoBehaviour {
	//could probably be random for each asteroid?
	//public float asteroidSpeed;
	private float speed;

	/* @brief Instantiates any defined objects. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
	** @pre A valid asteroid is created and entered into the game.
	** @post Gives each asteroid a random speed.
	** @return None*/
	void Start() {
		speed = -5.0f;
		//multiply by time
		GetComponent<Rigidbody> ().velocity = transform.forward * speed * Random.Range (2, 6);
	}
}
