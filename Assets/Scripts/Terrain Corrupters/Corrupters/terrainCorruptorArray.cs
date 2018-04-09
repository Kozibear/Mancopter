using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainCorruptorArray : MonoBehaviour {

	public GameObject left;
	public GameObject middle;
	public GameObject right;

	public GameObject player;

	public float selectedLocation;

	public bool canSelectLocation;

	public float timeToNextCorruptor;

	public bool firstTime;

	public float coinFlip;

	// Use this for initialization
	void Start () {
		canSelectLocation = false;
		timeToNextCorruptor = 50; //should be 50
		firstTime = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (gameTimer.gameTime >= timeToNextCorruptor) {

			if (firstTime) {
				canSelectLocation = true;
				firstTime = false;
			} 
			else if (gameTimer.gameTime < 280) { //before 100 seconds, we have a 15% chance of summoning one

				coinFlip  = Random.Range (1, 101);
				if (coinFlip <= 45) {

					canSelectLocation = true;
				} 
			}
			else if (gameTimer.gameTime >= 280) { //after 100 seconds, we have a 20% chance

				coinFlip  = Random.Range (1, 101);
				print (coinFlip);
				if (coinFlip <= 60) {

					canSelectLocation = true;
				} 
			}

			timeToNextCorruptor += 30;
		}

		if (canSelectLocation) {
			//we select a random number from the length of our range of possible locations
			selectedLocation = Random.Range (1, 4);

			//then, we instantiate our gameObject in the location of the corresponding chosen child object
			if (selectedLocation == 1) {
				GameObject Corruptor = Instantiate(left, transform.GetChild(0).transform.position, transform.GetChild(0).transform.rotation);
				Corruptor.GetComponent<ParabolicTerrainCorrupter> ().Player = player;
			}
			if (selectedLocation == 2) {
				GameObject Corruptor = Instantiate(middle, transform.GetChild(1).transform.position, transform.GetChild(1).transform.rotation);
				Corruptor.GetComponent<StraightTerrainCorrupter>().Player = player;
			}
			if (selectedLocation == 3) {
				GameObject Corruptor = Instantiate(right, transform.GetChild(2).transform.position, transform.GetChild(2).transform.rotation);
				Corruptor.GetComponent<ParabolicTerrainCorrupter>().Player = player;
			}

			canSelectLocation = false;
		}

	}
}
