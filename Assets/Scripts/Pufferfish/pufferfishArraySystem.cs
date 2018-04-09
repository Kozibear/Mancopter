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
		timeToNextPufferfish = 45; //45
		firstTime = true;
	}
	

	void FixedUpdate () {

		if (gameTimer.gameTime >= timeToNextPufferfish) {

			if (firstTime) {
				canSelectLocation = true;
				firstTime = false;
			} 
			else if (gameTimer.gameTime < 150) { //before X seconds, we have a 15% chance of summoning one

				coinFlip  = Random.Range (1, 101);
				if (coinFlip <= 15) {

					canSelectLocation = true;
				} 
			}
			else if (gameTimer.gameTime >= 150) { //after X seconds, we have a 20% chance

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

				GameObject pufferfish = Instantiate(left1, transform.GetChild(0).transform.position, transform.GetChild(0).transform.rotation);
				pufferfish.transform.GetChild(0).GetComponent<oneWayPufferfish> ().Player = player;

			}
			if (selectedLocation == 2) {
				GameObject pufferfish = Instantiate(left1, transform.GetChild(1).transform.position, transform.GetChild(1).transform.rotation);
				pufferfish.transform.GetChild(0).GetComponent<oneWayPufferfish> ().Player = player;

			}
			if (selectedLocation == 3) {
				GameObject pufferfish = Instantiate(left1, transform.GetChild(2).transform.position, transform.GetChild(2).transform.rotation);
				pufferfish.transform.GetChild(0).GetComponent<oneWayPufferfish> ().Player = player;

			}
			if (selectedLocation == 4) {
				GameObject pufferfish = Instantiate(left1, transform.GetChild(3).transform.position, transform.GetChild(3).transform.rotation);
				pufferfish.transform.GetChild(0).GetComponent<oneWayPufferfish> ().Player = player;

			}
			if (selectedLocation == 5) {
				GameObject pufferfish = Instantiate(left1, transform.GetChild(4).transform.position, transform.GetChild(4).transform.rotation);
				pufferfish.transform.GetChild(0).GetComponent<oneWayPufferfish> ().Player = player;

			}
			if (selectedLocation == 6) {
				GameObject pufferfish = Instantiate(left1, transform.GetChild(5).transform.position, transform.GetChild(5).transform.rotation);
				pufferfish.transform.GetChild(0).GetComponent<oneWayPufferfish> ().Player = player;

			}
			if (selectedLocation == 7) {
				GameObject pufferfish = Instantiate(left1, transform.GetChild(6).transform.position, transform.GetChild(6).transform.rotation);
				pufferfish.transform.GetChild(0).GetComponent<oneWayPufferfish> ().Player = player;

			}
			if (selectedLocation == 8) {
				GameObject pufferfish = Instantiate(left1, transform.GetChild(7).transform.position, transform.GetChild(7).transform.rotation);
				pufferfish.transform.GetChild(0).GetComponent<oneWayPufferfish> ().Player = player;

			}
			if (selectedLocation == 9) {
				GameObject pufferfish = Instantiate(left1, transform.GetChild(8).transform.position, transform.GetChild(8).transform.rotation);
				pufferfish.transform.GetChild(0).GetComponent<oneWayPufferfish> ().Player = player;

			}
			if (selectedLocation == 10) {
				GameObject pufferfish = Instantiate(left1, transform.GetChild(9).transform.position, transform.GetChild(9).transform.rotation);
				pufferfish.transform.GetChild(0).GetComponent<oneWayPufferfish> ().Player = player;

			}
				
			canSelectLocation = false;
		}


	}
}
