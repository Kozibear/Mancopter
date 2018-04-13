using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMultiplierObject : MonoBehaviour {

	public float recordTime;
	public bool increaseSize;

	// Use this for initialization
	void Start () {
		recordTime = Time.time;
		increaseSize = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.localScale.x < 3 && increaseSize)
		{
			transform.localScale *= 1.05f;
		}
		if (transform.localScale.x >= 3 && increaseSize)
		{
			increaseSize = false;
		}

		if (transform.localScale.x > 1.5f && !increaseSize)
		{
			transform.localScale /= 1.05f;
		}
		if (transform.localScale.x < 1.5f && !increaseSize)
		{
			increaseSize = true;
		}


		if((Time.time - recordTime) >= 6)
		{
			Destroy (gameObject);
		}
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Blade")
		{
			GameObject.Find("CopterBase").GetComponent<pointSystem> ().addToPointMultiplier = true;
			Destroy (gameObject);
		}
		if (collision.gameObject.tag == "throwingMan") {
			GameObject.Find("CopterBase").GetComponent<pointSystem> ().addToPointMultiplier = true;
			collision.GetComponent<throwingMan> ().returnHome = true;
			Destroy (gameObject);
		}
	}
}
