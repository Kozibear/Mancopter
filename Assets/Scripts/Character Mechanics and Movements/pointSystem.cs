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

	// Use this for initialization
	void Start () {
		accumulateGroundPoints = false;
		canRecordCurrentTime = true;
		newPoints = 0;

		pointMultiplier = 10;

		timeToNextMinutaryScore = 60;

		scoreDisplays = GameObject.Find("ScoreText").GetComponent<Text> (); //IMP WE NEED TO HAVE THIS PART TO ACCESS THE TEXT
		scoreDisplays.text = "Score: 0";
	}
	
	void FixedUpdate () {

		totalPoints = Mathf.Floor(previouslyEarnedPoints + newPoints); //the points that we will display; it will be more up-to-date than the previouslyEarnedPoints, and rounded down

		scoreDisplays.text = "Score: " + totalPoints.ToString();

		if (accumulateGroundPoints) {

			//we record the current time,
			if (canRecordCurrentTime) {
				currentTime = Time.time;
				canRecordCurrentTime = false;
			}

			//and then subtract it from Time.time so that we know how many seconds have elapsed from this moment forward,
			//so that we can accurately record how many points we're earning
			newPoints = (Time.time - currentTime)*pointMultiplier;
		}

		//when we leave the platform we're on, we add the points we just earned to our overall total
		if (!accumulateGroundPoints) {

			if (!canRecordCurrentTime) {
				previouslyEarnedPoints += newPoints;
				newPoints = 0;
			}

			canRecordCurrentTime = true;
		}

		//if we ever grab one of those floating power-ups, we add 10% (+1 pps) to our pointMultiplier
		if (addToPointMultiplier) {
			pointMultiplier += 1;

			addToPointMultiplier = false;
		}

		//after 1 minute (60 seconds), we add +1 pps 
		if (GameObject.Find ("CopterBase").GetComponent<gameTimer> ().gameTime >= timeToNextMinutaryScore) {
			pointMultiplier += 1;
			timeToNextMinutaryScore += 60;
		}
			
	}
}
