using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombPowerUp : MonoBehaviour {
	//effect of powerup pickup
	public float time;
	public GameObject effect;
	//Executes on powerup collision
	void OnTriggerEnter (Collider other) {
		//When collider is triggered, checks if powerup collided with the player
		if (other.CompareTag("Player")) {
			//Time management for effect time and powerup period using the player object
			StartCoroutine(pickup(other)); 
		}
	}
	//Player powerup pickup effects
	IEnumerator pickup(Collider player) {
		//Effect on pickup of powerup at the current position and rotation
		Instantiate (effect, transform.position, transform.rotation);
		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
	}
}
