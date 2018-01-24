using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePillarKill : MonoBehaviour {

	public float recordTime;

	// Use this for initialization
	void Start () {
		recordTime = Time.time;
	}
	
	void FixedUpdate () {

		if (Time.time >= recordTime + 1.5f) {
			Destroy (gameObject);
		}
	}
}
