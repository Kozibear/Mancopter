﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlScreenButton : MonoBehaviour {

	public Image blackBackground;

	public Color blackBackgroundColor;

	public bool darkenScreen;

	public Button startGame;

	public AudioSource click;

	// Use this for initialization
	void Start () {

		blackBackground.gameObject.SetActive (true);

		blackBackgroundColor = new Color (0, 0, 0, 1);

		darkenScreen = false;

		startGame.onClick.AddListener (startTheGame);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//for the black background fading out 
		if (!darkenScreen && blackBackgroundColor.a > 0) {
			blackBackground.color = blackBackgroundColor;
			blackBackgroundColor.a -= 0.025f;
		}
		if (!darkenScreen && blackBackgroundColor.a <= 0) {
			blackBackgroundColor.a = 0;
			blackBackground.gameObject.SetActive (false);
		}

		//for the black background fading in
		if (darkenScreen) {
			blackBackground.gameObject.SetActive (true);
			blackBackground.color = blackBackgroundColor;
			blackBackgroundColor.a += 0.05f;
		}
		if (darkenScreen && blackBackgroundColor.a >= 1) {
			SceneManager.LoadScene ("Mancopter Main Scene", LoadSceneMode.Single);
		}
	}

	void startTheGame() {
		darkenScreen = true;
		click.Play ();
	}
}
