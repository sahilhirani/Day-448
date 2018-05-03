using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombPowerUp : MonoBehaviour {
	//The duration for the power up (found that it was not necessary here)
	public float time;
	//The effect that is played when the user collides with the powerup
	public GameObject effect;
	//The explosion for the asteroids
	public GameObject explosion;
	
	//Executes on powerup collision
	public void OnTriggerEnter (Collider other) {
		//When collider is triggered, checks if powerup collided with the player
		if (other.CompareTag("Player")) {
			//Time management for effect time and powerup period using the player object
			pickup(other); 
		}
	}
	
	/* @brief Creates the action for the power up and give the player some ability.
	** @pre The player has hit a power up.
	** @post The player gains some ability.
	** @return None*/
	public void pickup(Collider player) {
		//Effect on pickup of powerup at the current position and rotation
		Instantiate (effect, transform.position, transform.rotation);
		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
		destroyAsteroids();
		Destroy(gameObject);
	}
	
	/* @brief The asteroids that are currently on the screen are destroyed.
	** @pre The bomb power up has been picked up.
	** @post All asteroids on screen are destroyed.
	** @return None*/
	public void destroyAsteroids() {
		GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
		for (var i = 0; i<asteroids.Length; i++) {
			Instantiate (explosion, asteroids[i].transform.position, asteroids[i].transform.rotation);
			Destroy (asteroids[i]);
		}
	}
}
