using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //need this to access the UI

public class pointSystem : MonoBehaviour {

	public float newPoints;
	public float previouslyEarnedPoints;
	public float totalPoints;
	public float pointMultiplier;

	public bool accumulateGroundPoints;

	public float currentTime;
	public bool canRecordCurrentTime;

	public bool addToPointMultiplier;
	public float timeToNextMinutaryScore;

	public Text scoreDisplays;
	public Text multiplierDisplay;

	public GameObject scoreText;

	//bools for the upgrades
	public bool lessThan4Health;
	public bool over15;
	public bool lastMan;

	// Use this for initialization
	void Start () {
		GameSave.gameSave.Load ();
		//GameSave.gameSave.powerup19 = 2;
		pointMultiplier = 1f;

		//powerup 2
		if (GameSave.gameSave.powerup2 == 2) {
			pointMultiplier*=1.2f;
		}

		//powerup 10
		if (GameSave.gameSave.powerup10 == 2) {
			pointMultiplier *= 1.25f; 
		}

		accumulateGroundPoints = false;
		canRecordCurrentTime = true;
		newPoints = 0;
	
		timeToNextMinutaryScore = 60;

		scoreDisplays = scoreText.GetComponent<Text> (); //IMP WE NEED TO HAVE THIS PART TO ACCESS THE TEXT
		scoreDisplays.text = "Score: 0";
	}
	
	void FixedUpdate () {

		//powerup 10
		if (GameSave.gameSave.powerup10 == 2 && this.gameObject.GetComponent<Health> ().healthAmount < 4 && !lessThan4Health) {
			pointMultiplier /= 1.25f; 
			lessThan4Health = true;
		}

		//powerup 12
		if (GameSave.gameSave.powerup12 == 2 && Time.timeSinceLevelLoad > 900 && !over15) {
			pointMultiplier *= 1.5f;
			over15 = true;
		}

		//powerup 19
		if (GameSave.gameSave.powerup19 == 2 && this.gameObject.GetComponent<Health> ().healthAmount == 1 && !lastMan) {
			pointMultiplier *= 1.35f;
			lastMan = true;
		}

		totalPoints = Mathf.Floor(previouslyEarnedPoints + newPoints); //the points that we will display; it will be more up-to-date than the previouslyEarnedPoints, and rounded down

		scoreDisplays.text = "Score: " + totalPoints.ToString();

		//if it is a whole number...
		if (Mathf.RoundToInt (pointMultiplier) == pointMultiplier) {
			multiplierDisplay.text = pointMultiplier.ToString () + ".0x";
		}
		//if it is not a whole number...
		else if (Mathf.RoundToInt (pointMultiplier) != pointMultiplier) {
			multiplierDisplay.text = pointMultiplier.ToString () + "x";
		}

		if (accumulateGroundPoints  && !this.gameObject.GetComponent<CopterBasicMovements>().insideObject && gameTimer.canStart) {

			//we record the current time,
			if (canRecordCurrentTime) {
				currentTime = Time.time;
				canRecordCurrentTime = false;
			}

			//and then subtract it from Time.time so that we know how many seconds have elapsed from this moment forward,
			//so that we can accurately record how many points we're earning
			newPoints = (Time.time - currentTime)*10*pointMultiplier;
		}
		else {
			
			//when we leave the platform we're on, we add the points we just earned to our overall total

			if (!canRecordCurrentTime) {
				previouslyEarnedPoints += newPoints;
				newPoints = 0;
			}

			canRecordCurrentTime = true;
		}

		//if we ever grab one of those floating power-ups, we add 10% (+0.1 pps) to our pointMultiplier
		if (addToPointMultiplier) {
			pointMultiplier += 0.1f;

			addToPointMultiplier = false;
		}

		/*
		//after 1 minute (60 seconds), we add +1 pps 
		if (gameTimer.gameTime >= timeToNextMinutaryScore) {
			pointMultiplier += 0.1;
			timeToNextMinutaryScore += 60;
		}
		*/
			
	}
}
