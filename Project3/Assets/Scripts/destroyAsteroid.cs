using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAsteroid : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Boundary") {
			return;
		}

		Instantiate (explosion, transform.position, transform.rotation);

		if(other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}

		//this can be commented out with a powerup (maybe have it called 'Super Nova')
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
