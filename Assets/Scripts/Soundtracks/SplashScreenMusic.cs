using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenMusic : MonoBehaviour {

	public AudioSource soundtrackMain;

	public bool sceneEnding;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (sceneEnding) {
			soundtrackMain.volume -= 0.025f;
		}
		
	}
}
