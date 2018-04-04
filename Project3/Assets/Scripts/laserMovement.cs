using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserMovement : MonoBehaviour {
    private Rigidbody comp; //creates rigidbody
    public float speed; //speed variable
	void Start () {
        comp = GetComponent<Rigidbody>();          
        comp.velocity = transform.forward * speed;  //moves object along the Z-axis at a set speed
	}
}
