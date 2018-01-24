using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserArray : MonoBehaviour {

	public GameObject laser1;
	public GameObject laser2;
	public GameObject laser3;
	public GameObject laser4;
	public GameObject laser5;
	public GameObject laser6;
	public GameObject laser7;
	public GameObject laser8;

	public float selectedLocation;

	public bool canSelectLocation;

	public float timeToNextLaser;

	public bool firstTime;

	public float coinFlip;

	// Use this for initialization
	void Start () {
		canSelectLocation = false;
		timeToNextLaser = 160; //160
		firstTime = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (GameObject.Find ("CopterBase").GetComponent<gameTimer> ().gameTime >= timeToNextLaser) {

			if (firstTime) {
				canSelectLocation = true;
				firstTime = false;
			} 
			else if (GameObject.Find ("CopterBase").GetComponent<gameTimer> ().gameTime < 500) { //before 100 seconds, we have a 15% chance of summoning one

				coinFlip  = Random.Range (1, 101);
				if (coinFlip <= 15) {

					canSelectLocation = true;
				} 
			}
			else if (GameObject.Find ("CopterBase").GetComponent<gameTimer> ().gameTime >= 500) { //after 100 seconds, we have a 20% chance

				coinFlip  = Random.Range (1, 101);
				print (coinFlip);
				if (coinFlip <= 20) {

					canSelectLocation = true;
				} 
			}

			timeToNextLaser += 10;
		}

		if (canSelectLocation) {
			//we select a random number from the length of our range of possible locations
			selectedLocation = Random.Range (1, 9);

			//then, we instantiate our gameObject in the location of the corresponding chosen child object
			if (selectedLocation == 1) {
				Instantiate(laser1, transform.GetChild(0).transform.position, transform.GetChild(0).transform.rotation);
			}
			if (selectedLocation == 2) {
				Instantiate(laser2, transform.GetChild(1).transform.position, transform.GetChild(1).transform.rotation);
			}
			if (selectedLocation == 3) {
				Instantiate(laser3, transform.GetChild(2).transform.position, transform.GetChild(2).transform.rotation);
			}
			if (selectedLocation == 4) {
				Instantiate(laser4, transform.GetChild(3).transform.position, transform.GetChild(3).transform.rotation);
			}
			if (selectedLocation == 5) {
				Instantiate(laser5, transform.GetChild(4).transform.position, transform.GetChild(4).transform.rotation);
			}
			if (selectedLocation == 6) {
				Instantiate(laser6, transform.GetChild(5).transform.position, transform.GetChild(5).transform.rotation);
			}
			if (selectedLocation == 7) {
				Instantiate(laser7, transform.GetChild(6).transform.position, transform.GetChild(6).transform.rotation);
			}
			if (selectedLocation == 8) {
				Instantiate(laser8, transform.GetChild(7).transform.position, transform.GetChild(7).transform.rotation);
			}

			canSelectLocation = false;
		}

	}
}
