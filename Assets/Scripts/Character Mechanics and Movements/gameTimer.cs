using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameTimer : MonoBehaviour {

	public bool canStart;

	public float gameTime;

	// Use this for initialization
	void Start () {
		canStart = false;
		gameTime = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//once the 3-second countdown timer is over, then we can begin counting the "Actual" game time
		if (Time.timeSinceLevelLoad >= 3) {
			canStart = true;
		}

		if (canStart) {
			gameTime = Time.timeSinceLevelLoad - 3;
		}
	}
}
