using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointBoostItemLocation : MonoBehaviour {

	public float selectedLocation;

	public bool canSelectLocation;

	public GameObject boostItem;

	public float timeToNextBoostAvailability;

	// Use this for initialization
	void Start () {
		canSelectLocation = false;
		timeToNextBoostAvailability = 30;
	}

	void FixedUpdate () {

		//if the gameTime has passed the time required to wait until the next boost's availability
		if (GameObject.Find ("CopterBase").GetComponent<gameTimer> ().gameTime >= timeToNextBoostAvailability) {
			canSelectLocation = true;
			timeToNextBoostAvailability += 30; //we set the next boost's availability 30 seconds in the future;
		}

		if (canSelectLocation) {
			//we select a random number from the length of our range of possible locations
			selectedLocation = Random.Range (1, 17);

			//then, we instantiate our gameObject in the location of the corresponding chosen child object
			if (selectedLocation == 1) {
				Instantiate(boostItem, transform.GetChild(0).transform.position, transform.GetChild(0).transform.rotation);
			}
			if (selectedLocation == 2) {
				Instantiate(boostItem, transform.GetChild(1).transform.position, transform.GetChild(1).transform.rotation);
			}
			if (selectedLocation == 3) {
				Instantiate(boostItem, transform.GetChild(2).transform.position, transform.GetChild(2).transform.rotation);
			}
			if (selectedLocation == 4) {
				Instantiate(boostItem, transform.GetChild(3).transform.position, transform.GetChild(3).transform.rotation);
			}
			if (selectedLocation == 5) {
				Instantiate(boostItem, transform.GetChild(4).transform.position, transform.GetChild(4).transform.rotation);
			}
			if (selectedLocation == 6) {
				Instantiate(boostItem, transform.GetChild(5).transform.position, transform.GetChild(5).transform.rotation);
			}
			if (selectedLocation == 7) {
				Instantiate(boostItem, transform.GetChild(6).transform.position, transform.GetChild(6).transform.rotation);
			}
			if (selectedLocation == 8) {
				Instantiate(boostItem, transform.GetChild(7).transform.position, transform.GetChild(7).transform.rotation);
			}
			if (selectedLocation == 9) {
				Instantiate(boostItem, transform.GetChild(8).transform.position, transform.GetChild(8).transform.rotation);
			}
			if (selectedLocation == 10) {
				Instantiate(boostItem, transform.GetChild(9).transform.position, transform.GetChild(9).transform.rotation);
			}
			if (selectedLocation == 11) {
				Instantiate(boostItem, transform.GetChild(10).transform.position, transform.GetChild(10).transform.rotation);
			}
			if (selectedLocation == 12) {
				Instantiate(boostItem, transform.GetChild(11).transform.position, transform.GetChild(11).transform.rotation);
			}
			if (selectedLocation == 13) {
				Instantiate(boostItem, transform.GetChild(12).transform.position, transform.GetChild(12).transform.rotation);
			}
			if (selectedLocation == 14) {
				Instantiate(boostItem, transform.GetChild(13).transform.position, transform.GetChild(13).transform.rotation);
			}
			if (selectedLocation == 15) {
				Instantiate(boostItem, transform.GetChild(14).transform.position, transform.GetChild(14).transform.rotation);
			}
			if (selectedLocation == 16) {
				Instantiate(boostItem, transform.GetChild(15).transform.position, transform.GetChild(15).transform.rotation);
			}


			canSelectLocation = false;
		}
	}
}
