using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotorRotationAndPosition : MonoBehaviour {

    public GameObject baseObject;

    private bool clockwise;

	// Use this for initialization
	void Start () {
        clockwise = true;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //Tie Position to Copter Base
        transform.position = new Vector3(baseObject.transform.position.x, baseObject.transform.position.y+1.7f, 0);

        //Rotation
        if (baseObject.GetComponent<CopterBasicMovements>().beginDescent && clockwise)
        {
            //the lower our health, the faster we spin (because fewer mans makes it seem like the copter isn't as fast)
            if(baseObject.GetComponent<Health>().healthAmount == 4)
            {
                transform.Rotate(0, 0, -6.5f);
            }

            if (baseObject.GetComponent<Health>().healthAmount == 3)
            {
                transform.Rotate(0, 0, -9.0f);
            }

            if (baseObject.GetComponent<Health>().healthAmount == 2)
            {
                transform.Rotate(0, 0, -10.0f);
            }

            if (baseObject.GetComponent<Health>().healthAmount == 1)
            {
                transform.Rotate(0, 0, -12.0f);
            }
            //except when we have no health, we don't spin anymore
            if (baseObject.GetComponent<Health>().healthAmount <= 0)
            {
                transform.Rotate(0, 0, 0f);
            }
        }

        if (baseObject.GetComponent<CopterBasicMovements>().beginDescent && !clockwise)
        {
            if (baseObject.GetComponent<Health>().healthAmount == 4)
            {
                transform.Rotate(0, 0, 6.5f);
            }

            if (baseObject.GetComponent<Health>().healthAmount == 3)
            {
                transform.Rotate(0, 0, 9.0f);
            }

            if (baseObject.GetComponent<Health>().healthAmount == 2)
            {
                transform.Rotate(0, 0, 10.0f);
            }

            if (baseObject.GetComponent<Health>().healthAmount == 1)
            {
                transform.Rotate(0, 0, 12.0f);
            }
            
            if (baseObject.GetComponent<Health>().healthAmount <= 0)
            {
                transform.Rotate(0, 0, 0f);
            }
        }

		//DECIDED NOT TO IMPLEMENT
        //rapid spin
		/*
        if (baseObject.GetComponent<CopterBasicMovements>().rapidlySpinning && clockwise)
        {
            transform.Rotate(0, 0, -15f);
        }
        if (baseObject.GetComponent<CopterBasicMovements>().rapidlySpinning && !clockwise)
        {
            transform.Rotate(0, 0, 15f);
        }
        */

        //depending on the most recent input, we rotate in a certain direction (unless we're currently rapidSpinning)
        if (!baseObject.GetComponent<CopterBasicMovements>().facingLeft)
        {
            clockwise = true;
        }
        else if (baseObject.GetComponent<CopterBasicMovements>().facingLeft)
        {
            clockwise = false;
        }
    }
}
