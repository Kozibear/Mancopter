using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagingLasers : MonoBehaviour {

	public float recordTime;

	public AudioSource laserSound;

	// Use this for initialization
	void Start () {
		recordTime = Time.time;
		laserSound.Play ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Time.time >= recordTime + 2) {

			Destroy (gameObject);
		}
	}
}
