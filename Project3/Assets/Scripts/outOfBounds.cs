using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outOfBounds : MonoBehaviour {

	/* @brief Called whenever a game object leaves the Game Controller. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerExit.html
	** @pre Valid game objects exist in the Game Controller.
	** @post Objects are destroid after they leave the Game Controller boundary.
	** @return None*/
    void OnTriggerExit(Collider other){
		if (other.tag == "Asteroid") {
			return;
		}

        Destroy(other.gameObject);
    }
}
