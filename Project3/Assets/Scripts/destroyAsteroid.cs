using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAsteroid : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	private int scoreValue = 100;
	private GameController gameController;

	/* @brief Instantiates any defined objects. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
	** @pre Asteroids exist in the game.
	** @post Starts the interaction between asteroids and the game environment. 
	** @return None*/
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

	/* @brief Called whenever asteroids enter the Game Controller. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerEnter.html
	** @pre A proper asteroid enters the game.
	** @post Asteroids are destroid if they come into contact with the player/weapon.
	** @return None*/
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
