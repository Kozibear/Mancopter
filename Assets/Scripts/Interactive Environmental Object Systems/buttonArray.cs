using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonArray : MonoBehaviour {

	public GameObject left1;
	public GameObject left2;
	public GameObject left3;
	public GameObject left4;
	public GameObject right1;
	public GameObject right2;
	public GameObject right3;
	public GameObject right4;

	public float selectedLocation;
	public float coinFlip;

	public static bool canSelectLocation;
	public static bool newSpikeAllowed;

	// Use this for initialization
	void Start () {
		canSelectLocation = false;
		newSpikeAllowed = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (canSelectLocation) {

			coinFlip  = Random.Range (1, 9);

			if (coinFlip == 1) {
				Instantiate(left1, transform.GetChild(0).transform.position, transform.GetChild(0).transform.rotation);
			}
			if (coinFlip == 2) {
				Instantiate(left2, transform.GetChild(1).transform.position, transform.GetChild(1).transform.rotation);
			}
			if (coinFlip == 3) {
				Instantiate(left3, transform.GetChild(2).transform.position, transform.GetChild(2).transform.rotation);
			}
			if (coinFlip == 4) {
				Instantiate(left4, transform.GetChild(3).transform.position, transform.GetChild(3).transform.rotation);
			}
			if (coinFlip == 5) {
				Instantiate(right1, transform.GetChild(4).transform.position, transform.GetChild(4).transform.rotation);
			}
			if (coinFlip == 6) {
				Instantiate(right2, transform.GetChild(5).transform.position, transform.GetChild(5).transform.rotation);
			}
			if (coinFlip == 7) {
				Instantiate(right3, transform.GetChild(6).transform.position, transform.GetChild(6).transform.rotation);
			}
			if (coinFlip == 8) {
				Instantiate(right4, transform.GetChild(7).transform.position, transform.GetChild(7).transform.rotation);
			}

			canSelectLocation = false;
		}
	}
}
