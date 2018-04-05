using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outOfBounds : MonoBehaviour {
    void OnTriggerExit(Collider other){
		if (other.tag == "Asteroid") {
			return;
		}

        Destroy(other.gameObject);
    }
}
