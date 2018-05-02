using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timePowerUp : MonoBehaviour {
	//effect of powerup pickup
	public float duration;
	public GameObject effect;
	public PlayerController player;

	private bool trigger = false;

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
		slowTime();
		//normalSpeed();
		Destroy(gameObject);
	}

	void slowTime() {
		Time.timeScale = 0.5f;
		player.speed *= 2;
		player.tilt = 2;
		//normalSpeed();
		Invoke("normalSpeed", 0.5f);
	}

	void normalSpeed() {
		if(trigger) {
			Time.timeScale = 1.0f;
			player.speed = 8;
			player.tilt = 4;
		}
	}
}
