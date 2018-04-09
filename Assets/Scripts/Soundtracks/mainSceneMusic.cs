using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainSceneMusic : MonoBehaviour {

	public GameObject player;

	public AudioSource soundtrackMain;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (player.GetComponent<Health> ().healthAmount == 0) {
			soundtrackMain.volume -= 0.01f;
		}
	}
}
