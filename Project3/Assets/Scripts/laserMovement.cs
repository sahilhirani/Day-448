using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserMovement : MonoBehaviour {
    //laser component variable
    private Rigidbody laserComp;
    //variable for the speed of the laser
    public float speed; 
	void Start () {
        //assigns rigidbody component to laser variable
        laserComp = GetComponent<Rigidbody>();
        //moves object along the Z-axis at a set speed
        laserComp.velocity = transform.forward * speed;  
	}
}
