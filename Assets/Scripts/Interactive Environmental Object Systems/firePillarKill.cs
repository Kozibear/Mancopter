using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePillarKill : MonoBehaviour {

	public float recordTime;

	public AudioSource firePillarSound;

	// Use this for initialization
	void Start () {
		recordTime = Time.time;
		firePillarSound.Play ();
	}
	
	void FixedUpdate () {

		if (Time.time >= recordTime + 1.5f) {
			Destroy (gameObject);
		}
	}
}
