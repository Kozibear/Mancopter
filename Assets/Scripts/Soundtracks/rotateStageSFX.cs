using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotateStageSFX : MonoBehaviour {

	public Button thisButton;

	public AudioSource swish;

	// Use this for initialization
	void Start () {
		thisButton.onClick.AddListener (rotateSFX);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void rotateSFX () {
		swish.Play ();
	}
}
