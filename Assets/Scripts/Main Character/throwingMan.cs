using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwingMan : MonoBehaviour {

    private float recordThrowTime;
    public bool returnHome;
    public BoxCollider2D box2d;
    public Renderer rend;
    public bool recordCurrentTime;
    public float identityValue;
    public bool goLeft;
    public float flashTimeRecorder;

    public bool isDead;
    public GameObject deadMan;

	public GameObject playerBase;
	public GameObject looseblade1;
	public GameObject looseblade2;
	public GameObject looseblade3;
	public GameObject looseblade4;

    // Use this for initialization
    void Start () {
        returnHome = false;
        recordThrowTime = Time.time;

		if (playerBase.GetComponent<CopterBasicMovements>().facingLeft)
        {
            goLeft = true;
        }
        else
        {
            goLeft = false;
        }

        flashTimeRecorder = Time.time;

        isDead = false;

		GameSave.gameSave.Load ();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //if the alloted time hasn't elapsed, or we haven't hit another object, we still move forward, based on what direction the player is facing
        if (!returnHome)
        {
            if (!goLeft)
            {
                Vector3 newPosition = transform.position;
                newPosition.x = newPosition.x + 0.32f;
                transform.position = newPosition;
                transform.Rotate(0, 0, -15f);
            }
            if (goLeft)
            {
                Vector3 newPosition = transform.position;
                newPosition.x = newPosition.x - 0.32f;
                transform.position = newPosition;
                transform.Rotate(0, 0, 15f);
            }
        }

        if (Time.time >= recordThrowTime+2f)
        {
            returnHome = true;
        }

        //otherwise, the objects moves back to its corresponding blade, and we allow it to flash every second (by alternating its alpha value)
        if (returnHome)
        {
            box2d.enabled = false;

            //if we are rendered and a certain amount of time has passed, we don't render, and vice-versa
            if (rend.enabled && (Time.time >= flashTimeRecorder+0.005f))
            {
                rend.enabled = false;
                flashTimeRecorder = Time.time;
            }
            else if (!rend.enabled && (Time.time >= flashTimeRecorder + 0.005f))
            {
                rend.enabled = true;
                flashTimeRecorder = Time.time;
            }
           
            if (Time.time < recordThrowTime + 2f)
            {
                if (identityValue == 1)
                {
					transform.position = Vector3.MoveTowards(transform.position, looseblade1.transform.position, 0.75f);
                }
                if (identityValue == 2)
                {
					transform.position = Vector3.MoveTowards(transform.position, looseblade2.transform.position, 0.75f);
                }
                if (identityValue == 3)
                {
					transform.position = Vector3.MoveTowards(transform.position, looseblade3.transform.position, 0.75f);
                }
                if (identityValue == 4)
                {
					transform.position = Vector3.MoveTowards(transform.position, looseblade4.transform.position, 0.75f);
                }
            }
            
            //if it's taking too long, we increase the speed at which we move towards the copter mast
            if (Time.time >= recordThrowTime + 2f)
            {
                if (identityValue == 1)
                {
					transform.position = Vector3.MoveTowards(transform.position, looseblade1.transform.position, 0.75f + (Time.time - (recordThrowTime + 2)) / 10);
                }
                if (identityValue == 2)
                {
					transform.position = Vector3.MoveTowards(transform.position, looseblade2.transform.position, 0.75f + (Time.time - (recordThrowTime + 2)) / 10);
                }
                if (identityValue == 3)
                {
					transform.position = Vector3.MoveTowards(transform.position, looseblade3.transform.position, 0.75f + (Time.time - (recordThrowTime + 2)) / 10);
                }
                if (identityValue == 4)
                {
					transform.position = Vector3.MoveTowards(transform.position, looseblade4.transform.position, 0.75f + (Time.time - (recordThrowTime + 2)) / 10);
                }
            }

            transform.Rotate(0, 0, 20f);
        }
        

        //once we have returned to our original position after being thrown and returning, we 
        //render our corresponding looseblade, record the current time (for the rotational offset), indicate what direction the object was originally thrown (to control what direction it will rotate)
        //and are destroyed
		if (returnHome && identityValue == 1 && transform.position == looseblade1.transform.position)
        {

			looseblade1.GetComponent<looseBlade>().returnFromThrowPushback = true;
			looseblade1.GetComponent<looseBlade>().offsetStartingTime = Time.time;
			looseblade1.GetComponent<Renderer>().enabled = true;

            if (goLeft)
            {
				looseblade1.GetComponent<looseBlade>().leftReturn = true;
            }
            else
            {
				looseblade1.GetComponent<looseBlade>().leftReturn = false;
            }

            Destroy(gameObject);
        }

		if (returnHome && identityValue == 2 && transform.position == looseblade2.transform.position)
        {

			looseblade2.GetComponent<looseBlade>().returnFromThrowPushback = true;
			looseblade2.GetComponent<looseBlade>().offsetStartingTime = Time.time;
			looseblade2.GetComponent<Renderer>().enabled = true;

            if (goLeft)
            {
				looseblade2.GetComponent<looseBlade>().leftReturn = true;
            }
            else
            {
				looseblade2.GetComponent<looseBlade>().leftReturn = false;
            }

            Destroy(gameObject);
        }

		if (returnHome && identityValue == 3 && transform.position == looseblade3.transform.position)
        {

			looseblade3.GetComponent<looseBlade>().returnFromThrowPushback = true;
			looseblade3.GetComponent<looseBlade>().offsetStartingTime = Time.time;
			looseblade3.GetComponent<Renderer>().enabled = true;

            if (goLeft)
            {
				looseblade3.GetComponent<looseBlade>().leftReturn = true;
            }
            else
            {
				looseblade3.GetComponent<looseBlade>().leftReturn = false;
            }

            Destroy(gameObject);
        }

		if (returnHome && identityValue == 4 && transform.position == looseblade4.transform.position)
        {

			looseblade4.GetComponent<looseBlade>().returnFromThrowPushback = true;
			looseblade4.GetComponent<looseBlade>().offsetStartingTime = Time.time;
			looseblade4.GetComponent<Renderer>().enabled = true;

            if (goLeft)
            {
				looseblade4.GetComponent<looseBlade>().leftReturn = true;
            }
            else
            {
				looseblade4.GetComponent<looseBlade>().leftReturn = false;
            }

            Destroy(gameObject);
        }

        //if a thrown Object strikes a harmful object (like a spiked enemy), we instantiate the dead copy in its place, lower our health by 1 point, 
        //make the player briefly invincible, and destroy the thrown object
        if(isDead)
        {
            Instantiate(deadMan, transform.position, transform.rotation);

			playerBase.GetComponent<Health>().healthAmount -= 1;
			playerBase.GetComponent<Health>().recordTime = Time.time;
			playerBase.GetComponent<Health>().canGetHurt = false;

            Destroy(gameObject);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            returnHome = true;
        }
        if(collision.gameObject.tag == "enemy")
        {
            returnHome = true;
        }

		if(collision.gameObject.tag == "harmlessEnemy")
		{
			returnHome = true;
		}

		if(collision.gameObject.tag == "prize")
		{
			returnHome = true;
		}

        if(collision.gameObject.tag == "harmfulobject")
        {
			if (GameSave.gameSave.powerup17 == 2) {
				isDead = false;
			}
			else {
				isDead = true;
			}
        }

    } 
}
