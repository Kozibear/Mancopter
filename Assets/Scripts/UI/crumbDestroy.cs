using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crumbDestroy : MonoBehaviour {

	public float startTimer;

	// Use this for initialization
	void Start () {
		startTimer = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (startTimer + 3.1f < Time.time) {
			Destroy (gameObject);
		}
	}
}
