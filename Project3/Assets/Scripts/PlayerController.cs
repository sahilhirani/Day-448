using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //allows for variables declared below to be visible in the unity editor
public class MapBounds
{
	//variable declaration for the bounds of the camera to keep the ship and asteroids within frame
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    //variable declaration of a rigidbody ship component, the playable field, laser object, and laser spawn transform component which follows the ship
    private Rigidbody shipComp;
    public MapBounds map;
    public GameObject Laser;
    public GameObject upgradedLaser;
    public Transform startLaser;
    //variable declaration of the speed of the ship, the tilt when moving, the rate that it can fire, and the shot time checker
    public float speed;
    public float tilt;
    public float fireRate;
    private float nextShot;
    public bool laserUpgrade = false;

    /* @brief Instantiates any defined objects. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
	** @pre A valid ship model exists.
	** @post The ship model gets assigned a rigid body that is used for physics.
	** @return None*/
    void Start(){
        //assigns rigidbody component to ship variable
        shipComp = GetComponent<Rigidbody>();
    }

    /* @brief Updates after every game frame to allow user to fire their weapon. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
	** @pre None
	** @post The game is updated every frame.
	** @return None*/
    void Update() {
        if (laserUpgrade == false)
        {
            //checks if either the keyboard or right mouse button is clicked, and if enough time has passed for another shot
            if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && Time.time > nextShot)
            {
                //iterates the next time a shot is available by the ship's rate of fire
                nextShot = Time.time + fireRate;
                //instantiates the laser object using the spawn location's position and rotation
                Instantiate(Laser, startLaser.position, startLaser.rotation);
                //play laser sound
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            Instantiate(upgradedLaser, startLaser.position, startLaser.rotation);
        }
    }

    /* @brief Updates after every fixed framerate. Specifically used in conjunction with Rigidbody objects.. More info from Unity at: https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html
	** @pre None
	** @post Allows for the ship to be moved by the user. Tilt is given to prevent a static moving object.
	** @return None*/
    void FixedUpdate(){
        //declaration of movement variable
        float moveVertical = Input.GetAxis("Vertical");
        //only allows movement vertically
        Vector3 movement = new Vector3(-moveVertical, 0.0f, 0.0f);
        //sets the velocity via speed variable
        shipComp.velocity = movement * speed;
        //keeps the ship from going out of bounds
        shipComp.position = new Vector3(Mathf.Clamp(shipComp.position.x, map.xMin, map.xMax), 0.0f, -2);
        //tilts the ship when moving
		shipComp.rotation = Quaternion.Euler((shipComp.velocity.x * -tilt), -90, -78);
    }
}
