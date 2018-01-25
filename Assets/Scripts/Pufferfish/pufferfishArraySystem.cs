using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pufferfishArraySystem : MonoBehaviour {

	public GameObject left1;
	public GameObject left2;
	public GameObject left3;
	public GameObject left4;
	public GameObject left5;
	public GameObject right1;
	public GameObject right2;
	public GameObject right3;
	public GameObject right4;
	public GameObject right5;

	public GameObject player;

	public float selectedLocation;

	public bool canSelectLocation;

	public float timeToNextPufferfish;

	public bool firstTime;

	public float coinFlip;

	// Use this for initialization
	void Start () {
		canSelectLocation = false;
		timeToNextPufferfish = 50;
		firstTime = true;
	}
	

	void FixedUpdate () {

		if (gameTimer.gameTime >= timeToNextPufferfish) {

			if (firstTime) {
				canSelectLocation = true;
				firstTime = false;
			} 
			else if (gameTimer.gameTime < 200) { //before 100 seconds, we have a 15% chance of summoning one

				coinFlip  = Random.Range (1, 101);
				if (coinFlip <= 15) {

					canSelectLocation = true;
				} 
			}
			else if (gameTimer.gameTime >= 200) { //after 100 seconds, we have a 20% chance

				coinFlip  = Random.Range (1, 101);
				print (coinFlip);
				if (coinFlip <= 20) {

					canSelectLocation = true;
				} 
			}
				
			timeToNextPufferfish += 10;
		}

		if (canSelectLocation) {
			//we select a random number from the length of our range of possible locations
			selectedLocation = Random.Range (1, 11);

			//then, we instantiate our gameObject in the location of the corresponding chosen child object
			if (selectedLocation == 1) {
				Instantiate(left1, transform.GetChild(0).transform.position, transform.GetChild(0).transform.rotation);
			}
			if (selectedLocation == 2) {
				Instantiate(left2, transform.GetChild(1).transform.position, transform.GetChild(1).transform.rotation);
			}
			if (selectedLocation == 3) {
				Instantiate(left3, transform.GetChild(2).transform.position, transform.GetChild(2).transform.rotation);
			}
			if (selectedLocation == 4) {
				Instantiate(left4, transform.GetChild(3).transform.position, transform.GetChild(3).transform.rotation);
			}
			if (selectedLocation == 5) {
				Instantiate(left5, transform.GetChild(4).transform.position, transform.GetChild(4).transform.rotation);
			}
			if (selectedLocation == 6) {
				Instantiate(right1, transform.GetChild(5).transform.position, transform.GetChild(5).transform.rotation);
			}
			if (selectedLocation == 7) {
				Instantiate(right2, transform.GetChild(6).transform.position, transform.GetChild(6).transform.rotation);
			}
			if (selectedLocation == 8) {
				Instantiate(right3, transform.GetChild(7).transform.position, transform.GetChild(7).transform.rotation);
			}
			if (selectedLocation == 9) {
				Instantiate(right4, transform.GetChild(8).transform.position, transform.GetChild(8).transform.rotation);
			}
			if (selectedLocation == 10) {
				Instantiate(right5, transform.GetChild(9).transform.position, transform.GetChild(9).transform.rotation);
			}

			canSelectLocation = false;
		}


	}
}
