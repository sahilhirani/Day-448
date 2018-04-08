using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserMovement : MonoBehaviour {
    //laser component variable
    private Rigidbody laserComp;
    //variable for the speed of the laser
    public float speed; 

	/* @brief Instantiates any defined objects. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
	** @pre The laser has been fired and exists in the frame of the game.
	** @post The laser moves across the screen.
	** @return None*/
	void Start () {
        //assigns rigidbody component to laser variable
        laserComp = GetComponent<Rigidbody>();
        //moves object along the Z-axis at a set speed
        laserComp.velocity = transform.forward * speed;  
	}
}
