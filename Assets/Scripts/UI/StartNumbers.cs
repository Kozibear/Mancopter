using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartNumbers : MonoBehaviour {

	public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.timeSinceLevelLoad < 0.65f) {
			text.text = "3";
		}
		if (Time.timeSinceLevelLoad < 1.3f && Time.timeSinceLevelLoad >= 0.65f) {
			text.text = "2";
		}
		if (Time.timeSinceLevelLoad < 1.95f && Time.timeSinceLevelLoad >= 1.3f) {
			text.text = "1";
		}
		if (Time.timeSinceLevelLoad < 2.6f && Time.timeSinceLevelLoad >= 1.95f) {
			text.text = "Start!";
		}
		if (Time.timeSinceLevelLoad > 3) {
			text.text = "";
		}
	}


}
