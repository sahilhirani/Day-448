using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombPowerUp : MonoBehaviour {
	//effect of powerup pickup
	public float time;
	public GameObject effect;
	public GameObject explosion;
	//Executes on powerup collision
	public void OnTriggerEnter (Collider other) {
		//When collider is triggered, checks if powerup collided with the player
		if (other.CompareTag("Player")) {
			//Time management for effect time and powerup period using the player object
			pickup(other); 
		}
	}
	//Player powerup pickup effects
	public void pickup(Collider player) {
		//Effect on pickup of powerup at the current position and rotation
		Instantiate (effect, transform.position, transform.rotation);
		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
		destroyAsteroids();
		Destroy(gameObject);
	}
	
	public void destroyAsteroids() {
		GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
		for (var i = 0; i<asteroids.Length; i++) {
			Instantiate (explosion, asteroids[i].transform.position, asteroids[i].transform.rotation);
			Destroy (asteroids[i]);
		}
	}
}
