using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public float tilt;
	public Boundary boundary;
    public GameObject Laser;
    public Transform startLaser;
    public float fireRate;
    private float nextFire;

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}

    void Update() {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Laser, startLaser.position, startLaser.rotation);
        }
    }

    void FixedUpdate(){
		//float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (-moveVertical, 0.0f, 0.0f);
		rb.velocity = movement * speed;

		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, (rb.velocity.x * -tilt));
	}
}
