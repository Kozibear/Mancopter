using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameTimer : MonoBehaviour {

	public static bool canStart;

	public static float gameTime;

	public static float startingWait;

	// Use this for initialization
	void Start () {
		canStart = false;
		gameTime = 0;
		startingWait = 3;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//once the 3-second countdown timer is over, then we can begin counting the "Actual" game time
		if (Time.timeSinceLevelLoad >= startingWait) {
			canStart = true;
		}

		if (canStart) {
			gameTime = Time.timeSinceLevelLoad - startingWait;
		}
	}
}
