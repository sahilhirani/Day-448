using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidRotator : MonoBehaviour {
	public float maxTumble;

	void Start() {
		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * maxTumble;
	}
}
