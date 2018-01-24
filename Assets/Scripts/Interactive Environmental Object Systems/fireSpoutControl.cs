using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSpoutControl : MonoBehaviour {

	public float nextTimeToFireSpouts;

	public bool firstTime;

	public bool selectSpout;

	public float coinFlip;
	public float fireSpoutChoice;

	// Use this for initialization
	void Start () {
		nextTimeToFireSpouts = 30;
		firstTime = true;
		selectSpout = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (GameObject.Find ("CopterBase").GetComponent<gameTimer> ().gameTime >= nextTimeToFireSpouts) {
			
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

			nextTimeToFireSpouts += 30;
		}

		if (selectSpout) {

			fireSpoutChoice = Random.Range (1, 4);

			if (fireSpoutChoice == 1) {
				transform.Find("leftFireSpout").GetComponent<fireSpoutMovements> ().beginAscent = true;
			}
			else if (fireSpoutChoice == 2) {
				transform.Find("middleFireSpout").GetComponent<fireSpoutMovements> ().beginAscent = true;
			}
			else if (fireSpoutChoice == 3) {
				transform.Find("rightFireSpout").GetComponent<fireSpoutMovements> ().beginAscent = true;
			}


			selectSpout = false;
		}
						
	}
}
