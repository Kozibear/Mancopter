using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMultiplierObject : MonoBehaviour {

	public float recordTime;

	// Use this for initialization
	void Start () {
		recordTime = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

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
