using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameTimer : MonoBehaviour {

	public static bool canStart;

	public static float gameTime;

	// Use this for initialization
	void Start () {
		canStart = false;
		gameTime = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		print (canStart);
		print (gameTime);

		//once the 3-second countdown timer is over, then we can begin counting the "Actual" game time
		if (Time.timeSinceLevelLoad >= 3) {
			canStart = true;
		}

		if (canStart) {
			gameTime = Time.timeSinceLevelLoad - 3;
		}
	}
}
