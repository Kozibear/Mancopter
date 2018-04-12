using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonClicks : MonoBehaviour {

	public AudioSource click;

	public Button button1;
	public Button button2;
	public Button button3;
	public Button button4;
	public Button button5;
	public Button button6;
	public Button button7;
	public Button button8;
	public Button button9;
	public Button button10;
	public Button button11;
	public Button button12;
	public Button button13;
	public Button button14;
	public Button button15;
	public Button button16;
	public Button button17;
	public Button button18;
	public Button button19;
	public Button button20;
	public Button button21;

	// Use this for initialization
	void Start () {

		button1.onClick.AddListener (playClick);
		button2.onClick.AddListener (playClick);
		button3.onClick.AddListener (playClick);
		button4.onClick.AddListener (playClick);
		button5.onClick.AddListener (playClick);
		button6.onClick.AddListener (playClick);
		button7.onClick.AddListener (playClick);
		button8.onClick.AddListener (playClick);
		button9.onClick.AddListener (playClick);
		button10.onClick.AddListener (playClick);
		button11.onClick.AddListener (playClick);
		button12.onClick.AddListener (playClick);
		button13.onClick.AddListener (playClick);
		button14.onClick.AddListener (playClick);
		button15.onClick.AddListener (playClick);
		button16.onClick.AddListener (playClick);
		button17.onClick.AddListener (playClick);
		button18.onClick.AddListener (playClick);
		button19.onClick.AddListener (playClick);
		button20.onClick.AddListener (playClick);
		button21.onClick.AddListener (playClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void playClick () {
		click.Play ();
	}
}
