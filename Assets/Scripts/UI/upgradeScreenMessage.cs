using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeScreenMessage : MonoBehaviour {

	public Button gotItButton;
	public Image backImage;
	public Text explanationText;

	// Use this for initialization
	void Start () {
		GameSave.gameSave.Load ();
		gotItButton.onClick.AddListener (readScreen);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (!GameSave.gameSave.upgradeScreenExplanationRead) {
			gotItButton.gameObject.SetActive (true);
			backImage.gameObject.SetActive (true);
			explanationText.gameObject.SetActive (true);
		}
	}

	void readScreen () {
		gotItButton.gameObject.SetActive (false);
		backImage.gameObject.SetActive (false);
		explanationText.gameObject.SetActive (false);

		GameSave.gameSave.upgradeScreenExplanationRead = true;
		GameSave.gameSave.Save ();
	}
}
