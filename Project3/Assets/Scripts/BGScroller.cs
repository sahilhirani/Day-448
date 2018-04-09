using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {
	//the speed at which the background moves
	public float scrollSpeed;
	//the size of each background tile
	public float tileSizeZ;
	//the starting position of the background
	private Vector3 startPosition;

	/* @brief Instantiates any defined objects. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
	** @pre None
	** @post The background begins scrolling.
	** @return None*/
	void Start () 
	{
		startPosition = transform.position;
	}

	/* @brief Updates after every game frame to allow see the background moving. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
	** @pre None
	** @post The game is updated every frame.
	** @return None*/
	void Update ()
	{
		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.forward * newPosition;
	}
}
