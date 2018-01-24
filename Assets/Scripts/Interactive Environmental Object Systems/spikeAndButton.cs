using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeAndButton : MonoBehaviour {


	public bool buttonPressed;

	public float recordTime;

	// Use this for initialization
	void Start () {
		buttonPressed = false;

		recordTime = Time.time;

		GameObject.Find ("buttonArray").GetComponent<buttonArray> ().canSelectLocation = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (buttonPressed) {
			GameObject.Find ("buttonArray").GetComponent<buttonArray> ().newSpikeAllowed = true;

			this.transform.parent.GetComponent<BlockMovementEffects> ().doubleEXP = true;
			Destroy (gameObject);
		}

		if (Time.time >= recordTime + 10.3f) {

			GameObject.Find ("buttonArray").GetComponent<buttonArray> ().newSpikeAllowed = true;
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			//Makes this object the parent of the colliding "player" object
			collision.transform.parent = this.transform;
		}

	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.transform.parent = this.transform;
		}

	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.transform.parent = null;
		}
	}
}
