﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSpoutControl : MonoBehaviour {

	public float nextTimeToFireSpouts;

	public bool firstTime;

	public bool selectSpout;

	public float coinFlip;
	public float fireSpoutChoice;

	public GameObject fireSpout1;
	public GameObject fireSpout2;
	public GameObject fireSpout3;

	// Use this for initialization
	void Start () {
		nextTimeToFireSpouts = 20; //20
		firstTime = true;
		selectSpout = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (gameTimer.gameTime >= nextTimeToFireSpouts) {
			
			if (firstTime) {
				selectSpout = true;
			} 
			else 
			{
				coinFlip = (Random.Range (0, 2));

				if (coinFlip == 1) {

					selectSpout = true;
				} 
			}

			nextTimeToFireSpouts += 20;
		}

		if (selectSpout) {

			fireSpoutChoice = Random.Range (1, 4);

			if (fireSpoutChoice == 1) {
				fireSpout1.SetActive (true);
				fireSpout2.SetActive (false);
				fireSpout3.SetActive (false);
				fireSpout1.GetComponent<fireSpoutMovements> ().beginAscent = true;
			}
			else if (fireSpoutChoice == 2) {
				fireSpout1.SetActive (false);
				fireSpout2.SetActive (true);
				fireSpout3.SetActive (false);
				fireSpout2.GetComponent<fireSpoutMovements> ().beginAscent = true;
			}
			else if (fireSpoutChoice == 3) {
				fireSpout1.SetActive (false);
				fireSpout2.SetActive (false);
				fireSpout3.SetActive (true);
				fireSpout3.GetComponent<fireSpoutMovements> ().beginAscent = true;
			}


			selectSpout = false;
		}
						
	}
}
