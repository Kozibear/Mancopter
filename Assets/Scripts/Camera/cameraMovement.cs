using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

    public GameObject playerCharacter;

    private Vector3 location;
	private Vector3 originalLocation;

    private float YShakeOffset;

    private float shakeTime;

    private float shakingBeginTime;

    private bool startShaking;

    private bool moveUp;
    private bool moveDown;

	// Use this for initialization
	void Start () {
        shakeTime = 0.15f;
        startShaking = false;

        moveUp = true;
        moveDown = false;

		originalLocation = new Vector3(this.transform.position.x, this.transform.position.y, -52);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		
        //if the player just descended downwards into the ground, the whole world shakes a fraction of a second
        if(playerCharacter.GetComponent<CopterBasicMovements>().shakeWorld)
        {
            playerCharacter.GetComponent<CopterBasicMovements>().shakeWorld = false;

            shakingBeginTime = Time.time;

            startShaking = true;
        }

        if(Time.time < shakingBeginTime+shakeTime && startShaking)
        {
            //this way, it alternates between two Y offsets every time this is called
            if(moveUp)
            {
                YShakeOffset = 0.32f;

                moveUp = false;
                moveDown = true;
            }
            else if (moveDown)
            {
                YShakeOffset = -0.32f;

                moveUp = true;
                moveDown = false;
            }

			//when the player pounds down, the screen shakes for a seconds
			location = new Vector3(this.transform.position.x, this.transform.position.y + YShakeOffset, this.transform.position.z);
			transform.position = location;
        }
        else
        {
            startShaking = false;
            YShakeOffset = 0;

			//afterwards, we return to the screen's original position from the beginning
			transform.position = originalLocation;
        }
    }
}