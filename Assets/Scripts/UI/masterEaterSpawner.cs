using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class masterEaterSpawner : MonoBehaviour {

	public GameObject subSpawner11;
	public GameObject subSpawner12;
	public GameObject subSpawner13;
	public GameObject subSpawner14;
	public GameObject subSpawner15;
	public GameObject subSpawner16;

	public GameObject subSpawner21;
	public GameObject subSpawner22;
	public GameObject subSpawner23;
	public GameObject subSpawner24;
	public GameObject subSpawner25;
	public GameObject subSpawner26;

	public GameObject subSpawner31;
	public GameObject subSpawner32;
	public GameObject subSpawner33;
	public GameObject subSpawner34;
	public GameObject subSpawner35;
	public GameObject subSpawner36;

	public GameObject subSpawner41;
	public GameObject subSpawner42;
	public GameObject subSpawner43;
	public GameObject subSpawner44;
	public GameObject subSpawner45;
	public GameObject subSpawner46;

	public GameObject subSpawner51;
	public GameObject subSpawner52;
	public GameObject subSpawner53;
	public GameObject subSpawner54;
	public GameObject subSpawner55;
	public GameObject subSpawner56;

	public GameObject subSpawner61;
	public GameObject subSpawner62;
	public GameObject subSpawner63;
	public GameObject subSpawner64;
	public GameObject subSpawner65;
	public GameObject subSpawner66;

	public float randomNumber;

	public float timeUntilNextSelection;

	public bool canSelectNextSpawner;

	// Use this for initialization
	void Start () {
		timeUntilNextSelection = 0; //15
		canSelectNextSpawner = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!canSelectNextSpawner && gameTimer.gameTime >= timeUntilNextSelection)
		{
			canSelectNextSpawner = true;
			if (gameTimer.gameTime < 30) {
				timeUntilNextSelection += 15;
			}
			if (gameTimer.gameTime >= 30 && gameTimer.gameTime < 60) {
				timeUntilNextSelection += 14.5f;
			}
			if (gameTimer.gameTime >= 60 && gameTimer.gameTime < 90) {
				timeUntilNextSelection += 14f;
			}
			if (gameTimer.gameTime >= 90 && gameTimer.gameTime < 120) {
				timeUntilNextSelection += 13.5f;
			}
			if (gameTimer.gameTime >= 150 && gameTimer.gameTime < 180) {
				timeUntilNextSelection += 13f;
			}
			if (gameTimer.gameTime >= 180 && gameTimer.gameTime < 210) {
				timeUntilNextSelection += 12.5f;
			}
			if (gameTimer.gameTime >= 210 && gameTimer.gameTime < 240) {
				timeUntilNextSelection += 12f;
			}
			if (gameTimer.gameTime >= 240 && gameTimer.gameTime < 270) {
				timeUntilNextSelection += 11f;
			}
			if (gameTimer.gameTime >= 270 && gameTimer.gameTime < 300) {
				timeUntilNextSelection += 10f;
			}
			if (gameTimer.gameTime >= 300 && gameTimer.gameTime < 330) {
				timeUntilNextSelection += 9f;
			}
			if (gameTimer.gameTime >= 330 && gameTimer.gameTime < 360) {
				timeUntilNextSelection += 8;
			}
		}
			
		if (canSelectNextSpawner) {

			canSelectNextSpawner = false;
			selectSubSpawner ();
		}
	}

	void selectSubSpawner () {
		randomNumber = Random.Range (1, 37);
		//subSpawner11.GetComponent<subEaterSpawner> ().spawnEater ();
		if (randomNumber == 1) {
			subSpawner11.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 2) {
			subSpawner12.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 3) {
			subSpawner13.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 4) {
			subSpawner14.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 5) {
			subSpawner15.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 6) {
			subSpawner16.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 7) {
			subSpawner21.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 8) {
			subSpawner22.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 9) {
			subSpawner23.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 10) {
			subSpawner24.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 11) {
			subSpawner25.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 12) {
			subSpawner26.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 13) {
			subSpawner31.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 14) {
			subSpawner32.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 15) {
			subSpawner33.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 16) {
			subSpawner34.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 17) {
			subSpawner35.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 18) {
			subSpawner36.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 19) {
			subSpawner41.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 20) {
			subSpawner42.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 21) {
			subSpawner43.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 22) {
			subSpawner44.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 23) {
			subSpawner45.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 24) {
			subSpawner46.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 25) {
			subSpawner51.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 26) {
			subSpawner52.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 27) {
			subSpawner53.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 28) {
			subSpawner54.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 29) {
			subSpawner55.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 30) {
			subSpawner56.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 31) {
			subSpawner61.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 32) {
			subSpawner62.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 33) {
			subSpawner63.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 34) {
			subSpawner64.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 35) {
			subSpawner65.GetComponent<subEaterSpawner> ().spawnEater ();
		}
		else if (randomNumber == 36) {
			subSpawner66.GetComponent<subEaterSpawner> ().spawnEater ();
		}
	}
}
