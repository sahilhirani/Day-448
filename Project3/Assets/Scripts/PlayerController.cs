using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//allows the variables to be serialized and collapsible
[System.Serializable]
public class MapBounds
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    //variable declaration of a rigidbody ship component, the playable field, laser object, and laser spawn transform component which follows the ship
    private Rigidbody shipComp;
    public MapBounds map;
    public GameObject Laser;
    public Transform startLaser;
    //variable declaration of the speed of the ship, the tilt when moving, the rate that it can fire, and the shot time checker
    public float speed;
    public float tilt;
    public float fireRate;
    private float nextShot;

    void Start(){
        //assigns rigidbody component to ship variable
        shipComp = GetComponent<Rigidbody>();
    }

    void Update() {
        //checks if either the keyboard or right mouse button is clicked, and if enough time has passed for another shot
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && Time.time > nextShot)
        {
            //iterates the next time a shot is available by the ship's rate of fire
            nextShot = Time.time + fireRate;
            //instantiates the laser object using the spawn location's position and rotation
            Instantiate(Laser, startLaser.position, startLaser.rotation);
        }
    }

    void FixedUpdate(){
        //declaration of movement variable
        float moveVertical = Input.GetAxis("Vertical");
        //only allows movement vertically
        Vector3 movement = new Vector3(-moveVertical, 0.0f, 0.0f);
        //sets the velocity via speed variable
        shipComp.velocity = movement * speed;
        //keeps the ship from going out of bounds
        shipComp.position = new Vector3(Mathf.Clamp(shipComp.position.x, map.xMin, map.xMax), 0.0f, -3);
        //tilts the ship when moving
		shipComp.rotation = Quaternion.Euler((shipComp.velocity.x * -tilt), -90, -78);
    }
}
