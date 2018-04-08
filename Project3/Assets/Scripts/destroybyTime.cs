using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroybyTime : MonoBehaviour {
	//the amount of time a game object exists in the game 
	public float lifetime;

	/* @brief Instantiates any defined objects. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
	** @pre There are game objects (Player, Asteroids, Explosions) that exist in the game stack.
	** @post Removes any animations or objects that take up memory after a set amount of time.
	** @return None*/
	void Start ()
	{
		Destroy (gameObject, lifetime);
	}
}
