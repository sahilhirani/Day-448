using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidRotator : MonoBehaviour {
	//the maximum value for the tumble of asteroids
	public float maxTumble;

	/* @brief Instantiates any defined objects. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
	** @pre Asteroids exist in the game.
	** @post Starts the random rotation of each asteroid. 
	** @return None*/
	void Start() {
		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * maxTumble;
	}
}
