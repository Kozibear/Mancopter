using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class quitGme : MonoBehaviour {

	public Button quitButton;

	// Use this for initialization
	void Start () {
		quitButton.onClick.AddListener (quitGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void quitGame () {
		Application.Quit ();
	}
}
