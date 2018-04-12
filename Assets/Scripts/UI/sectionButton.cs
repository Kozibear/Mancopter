using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sectionButton : MonoBehaviour {

	public GameObject splashScreen;
	public GameObject upgradeScreen;
	public GameObject highScoreScreen;

	public Button thisButton;

	public AudioSource click;

	// Use this for initialization
	void Start () {
		thisButton.onClick.AddListener (switchScreen);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void switchScreen () {
		if (this.gameObject.name == "High Scores Button") {
			
			splashScreen.gameObject.SetActive (false);
			upgradeScreen.gameObject.SetActive (false);
			highScoreScreen.gameObject.SetActive (true);
		}

		if (this.gameObject.name == "Upgrades Button") {

			splashScreen.gameObject.SetActive (false);
			upgradeScreen.gameObject.SetActive (true);
			highScoreScreen.gameObject.SetActive (false);
		}

		if (this.gameObject.name == "Splash Screen Button") {

			splashScreen.gameObject.SetActive (true);
			upgradeScreen.gameObject.SetActive (false);
			highScoreScreen.gameObject.SetActive (false);
		}
	}
}
