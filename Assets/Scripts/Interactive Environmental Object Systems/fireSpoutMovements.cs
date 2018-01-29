using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSpoutMovements : MonoBehaviour {

	public Vector3 originalPosition;
	public Vector3 modifiedLocation1;
	public Vector3 modifiedLocation2;

	public bool beginAscent;
	public bool slightDescent;
	public bool slightAscent;
	public bool finalDescent;

	public float recordTime;

	void awake () {
		
	}

	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
		beginAscent = false;
		slightDescent = false;
		slightAscent = false;
		finalDescent = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//we move the fire from its original position to its top position
		if (beginAscent) {

			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (originalPosition.x, originalPosition.y+7.05f, originalPosition.z), 0.04f);

			if (transform.position == new Vector3 (originalPosition.x, originalPosition.y+7.05f, originalPosition.z) ) {
				beginAscent = false; 
				slightDescent = true;

				recordTime = Time.time; //so that we can time how long we remain going up and down
			}

		}
			
		//from its top position to mid-position
		if (slightDescent)
		{
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (originalPosition.x, originalPosition.y+3.55f, originalPosition.z), 0.025f);

			if (transform.position == new Vector3 (originalPosition.x, originalPosition.y+3.55f, originalPosition.z) ) {
				slightDescent = false;
				slightAscent = true;
			}
		}
			
		//mid-position back to top position, repeatedly until the time is up
		if (slightAscent) 
		{
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (originalPosition.x, originalPosition.y+7.05f, originalPosition.z), 0.025f);

			if (transform.position == new Vector3 (originalPosition.x, originalPosition.y+7.05f, originalPosition.z) ) {

				if (Time.time < recordTime + 13f) {
					slightAscent = false;
					slightDescent = true;
				}
				if (Time.time >= recordTime + 13f) {
					slightAscent = false;
					slightDescent = false;
					finalDescent = true;
				}

			}
		}

		//top position back down to its original position
		if (finalDescent) {

			transform.position = Vector3.MoveTowards (transform.position, originalPosition, 0.06f);

			if (transform.position == originalPosition) {
				finalDescent = false;
			}
		}

	}
}