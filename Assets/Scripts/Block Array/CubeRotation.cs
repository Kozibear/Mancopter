using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour {

	public bool rotateCounterClockwise;

	public Quaternion targetRotation;

	// Use this for initialization
	void Start () {
		rotateCounterClockwise = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			rotateCounterClockwise = true;
			targetRotation = transform.rotation * Quaternion.Euler (0, 90, 0);
		}


		if (rotateCounterClockwise) {
			transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 4.5f);
			if (transform.rotation == targetRotation) {
				rotateCounterClockwise = false;
			}
		}
	}
}
