using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagingLasers : MonoBehaviour {

	public float recordTime;

	// Use this for initialization
	void Start () {
		recordTime = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Time.time >= recordTime + 2) {

			Destroy (gameObject);
		}
	}
}
