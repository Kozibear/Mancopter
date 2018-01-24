using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//when we touch a button, we let the one spike in the room know that its button has been pressed before destroying the button
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Blade" || collision.gameObject.tag == "throwingMan")
		{
			GameObject.Find ("buttonSpike(Clone)").GetComponent<spikeAndButton> ().buttonPressed = true;
			Destroy (gameObject);
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Blade" || collision.gameObject.tag == "throwingMan")
		{
			GameObject.Find ("buttonSpike(Clone)").GetComponent<spikeAndButton> ().buttonPressed = true;
			Destroy (gameObject);
		}
	}
}
