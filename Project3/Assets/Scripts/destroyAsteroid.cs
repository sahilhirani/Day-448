﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAsteroid : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	private int scoreValue = 10;
	private GameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Bounds") {
			return;
		}

		Instantiate (explosion, transform.position, transform.rotation);

		if(other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
			gameController.GameOver ();
			return;
		}

		//this can be commented out with a powerup (maybe have it called 'Super Nova')
		gameController.addScore(scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
