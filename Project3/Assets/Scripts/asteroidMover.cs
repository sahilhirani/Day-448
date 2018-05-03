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
		//multiply speed by a random integer between 2 and 3 for powerups
		if(GetComponent<Rigidbody>().tag == "PowerUp"){
			GetComponent<Rigidbody> ().velocity = transform.forward * speed * Random.Range (2, 3);
		}
		//multiply speed by a random integer between 2 and 5 for asteroids
		else{
			GetComponent<Rigidbody> ().velocity = transform.forward * speed * Random.Range (2, 5);
		}

	}
}
