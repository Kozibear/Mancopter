using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class looseBlade : MonoBehaviour {

    public GameObject baseObject;
    public GameObject referenceBlade;
    public Rigidbody2D rb2d;

    public float startingTime;
    private bool recordTime;
    //private bool recordRapidSpinTime;
    //private bool returnToOriginalPlace;

    public bool returnFromThrowPushback;
    public float offsetStartingTime;
    public HingeJoint2D hinge;
    public JointMotor2D motor;
    public bool currentlyPushingBack;
    public bool leftReturn;

    public float rotationStopPointLeft;
    public float rotationStopPointRight;

    public bool isDead;
    public GameObject deadMan;

    public GameObject[] bladeArray;
    public GameObject[] playerArray;
    public GameObject[] deadManArray;
    public GameObject[] groundArray;
    public GameObject[] throwingManArray;

    private void Awake()
    {
    }

    // Use this for initialization
    void Start () {
        returnFromThrowPushback = false;
        currentlyPushingBack = false;
        isDead = false;
        //returnToOriginalPlace = true;

        //we create an array of all our objects with the Blade tag (less intensive on unity, and less time-consuming, than individually listing the names of all objects)
        bladeArray = GameObject.FindGameObjectsWithTag("Blade");

        //for each individual blade object in our bladeArray, we ignore its box collider
        foreach (GameObject blade in bladeArray)
        {
            Physics2D.IgnoreCollision(blade.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        }

        playerArray = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject playerObject in playerArray)
        {
            Physics2D.IgnoreCollision(playerObject.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        }

        groundArray = GameObject.FindGameObjectsWithTag("ground");
        //NOT ENEMIES OR DAMAGING OBJECTS
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		

        //only if we're descending, we ignore the walls
        //we have to call this in the update because whether we're descending or not changes overtime

        if (GameObject.Find("CopterBase").GetComponent<CopterBasicMovements>().beginDescent)
        {
			
            foreach (GameObject groundObject in groundArray)
            {
                if (groundObject != null) //we need to include this, since certain ground objects dissapear 
                {
                    Physics2D.IgnoreCollision(groundObject.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
                }
            }

        }
        else
        {
            foreach (GameObject groundObject in groundArray)
            {
                if(groundObject != null)
                {
                    Physics2D.IgnoreCollision(groundObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>(), false);
                }
                
            }
        }
		

        //we need to call this in the update because there are no deadMans at Start
        deadManArray = GameObject.FindGameObjectsWithTag("deadMan");

        foreach (GameObject deadMan in deadManArray)
        {
            Physics2D.IgnoreCollision(deadMan.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        }

        //we need to call this in the update because there are no throwingMans at the start
        throwingManArray = GameObject.FindGameObjectsWithTag("throwingMan");

        foreach (GameObject throwingMan in throwingManArray)
        {
            Physics2D.IgnoreCollision(throwingMan.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        }


        //when the copter is jumping, the blades get pushed downwards, and when rapidly pushing downwards, the blades get pushed upwards
        if (baseObject.GetComponent<CopterBasicMovements>().jumping && !baseObject.GetComponent<CopterBasicMovements>().downwardsPush)
        {
            rb2d.gravityScale = 15f;
            rb2d.angularDrag = 5f;
        }
        else if ((baseObject.GetComponent<CopterBasicMovements>().downwardsPush || baseObject.GetComponent<CopterBasicMovements>().immovableDescent) && !baseObject.GetComponent<CopterBasicMovements>().jumping)
        {
            rb2d.gravityScale = -20f;
            rb2d.angularDrag = 5f;
        }
        else if (baseObject.GetComponent<CopterBasicMovements>().grounded) //if grounded, we push a little hard on gravity
        {
            rb2d.gravityScale = 3f;
            rb2d.angularDrag = 1.5f;
        }
        else //otherwise, gravity and angular drag remains normal
        {
            rb2d.gravityScale = 1f;
            rb2d.angularDrag = 1f;
        }


        //code for moving the copter's blades into place when slowly desscending
        //we record the current time, so that we can use the time passed since this recording to gradually increase the lerp below
        if (baseObject.GetComponent<CopterBasicMovements>().beginDescent && recordTime)
        {
            startingTime = Time.time;

            recordTime = false; 
        }


		//possibly
        //we make the copter's loose blades gradually move towards the position of the reference blades, with the closeness increasing every second, if we're not pushing downwards or just got a man back from throwing it
        if (baseObject.GetComponent<CopterBasicMovements>().beginDescent && !baseObject.GetComponent<CopterBasicMovements>().downwardsPush)
        {
            if (!currentlyPushingBack)
            {
                transform.position = Vector3.Lerp(transform.position, referenceBlade.transform.position, ((Time.time - startingTime) / 1.5f)); //vectors are for positions,
                transform.rotation = Quaternion.Lerp(transform.rotation, referenceBlade.transform.rotation, ((Time.time - startingTime) / 1.5f)); //quaternions are for rotations
            }
            if (currentlyPushingBack) //if we just got the blade back from being thrown, it instantly assumes the referenceBlade's position
            {
                transform.position = referenceBlade.transform.position;
                transform.rotation = referenceBlade.transform.rotation;
            }
        }


		//Code for when rapidlySpinning, no longer in use
		/*
        //code for moving the copter's blades into place quickly when rapidlySpinning
        if (baseObject.GetComponent<CopterBasicMovements>().rapidlySpinning && recordRapidSpinTime)
        {
            startingTime = Time.time;

            recordRapidSpinTime = false;
        }


        if (baseObject.GetComponent<CopterBasicMovements>().rapidlySpinning)
        {
            transform.position = Vector3.MoveTowards(transform.position, referenceBlade.transform.position, 0.4f + (Time.time - startingTime)*13f); 
            transform.rotation = Quaternion.RotateTowards(transform.rotation, referenceBlade.transform.rotation, 0.4f + (Time.time - startingTime)*13f); 
        }


        //after rapid spin, we make sure that the loose blades are fully in the referenceblades' places before descending
        if (baseObject.GetComponent<CopterBasicMovements>().immovableDescent && returnToOriginalPlace)
        {
            transform.position = referenceBlade.transform.position;
            transform.rotation = referenceBlade.transform.rotation;

            returnToOriginalPlace = false;
        }
		*/

        //If a man just returned from being thrown, we briefly activate the hingeJoint2D's motor to slightly shake the looseBlade, to make it seem like "it" was what was thrown
        if (returnFromThrowPushback && Time.time < offsetStartingTime+0.04f && leftReturn)
        {
            hinge.useMotor = true;

            motor = hinge.motor;
            motor.motorSpeed = -1000f;
            hinge.motor = motor;

            currentlyPushingBack = true;
        }
        if (returnFromThrowPushback && Time.time < offsetStartingTime + 0.04f && !leftReturn)
        {
            hinge.useMotor = true;

            motor = hinge.motor;
            motor.motorSpeed = 1000f;
            hinge.motor = motor;

            currentlyPushingBack = true;
        }
        if (Time.time >= offsetStartingTime+0.04f)
        {
            hinge.useMotor = false;
            returnFromThrowPushback = false;
        }
        
        //when we're walking on the ground, we make the blades sway left or right depending on the direction we are currently walking
        //we do this by adding force to the blades' rigidbody (if we translate, it will instantly move it to a different location, which is not what we want)
        //(but if we're up against a wall, it doesn't work)
        if((Input.GetKey("a") || Input.GetKey("left")) && baseObject.GetComponent<CopterBasicMovements>().grounded && !baseObject.GetComponent<CopterBasicMovements>().collidingWithALeftWall)
        {
            Vector3 newPush = new Vector3(40, 0, 0);
            rb2d.AddForce(newPush);
        }
        else if((Input.GetKey("d") || Input.GetKey("right")) && baseObject.GetComponent<CopterBasicMovements>().grounded && !baseObject.GetComponent<CopterBasicMovements>().collidingWithARightWall)
        {
            Vector3 newPush = new Vector3(-40, 0, 0);
            rb2d.AddForce(newPush);
        }
        
        //once we jump again, or we forcibly push ourselves downwards, we can record time again for either instance in which the blades must lerp into position
        if (baseObject.GetComponent<CopterBasicMovements>().jumping || baseObject.GetComponent<CopterBasicMovements>().grounded || baseObject.GetComponent<CopterBasicMovements>().downwardsPush)
        {
            recordTime = true;
        }

        if (baseObject.GetComponent<CopterBasicMovements>().grounded)
        {
            //recordRapidSpinTime = true;
            currentlyPushingBack = false;
            //returnToOriginalPlace = true;
        }

        //if this blade is killed off, we instantiate a new, identical blade to appear that falls to the ground.
        if (isDead)
        {
            Instantiate(deadMan, transform.position, transform.rotation);
            //deadMan.GetComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;

            isDead = false;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if an individual blade collides with an enemy or a harmful object, and we can get hurt, and are rendered,
        //we disabled the renderer, lower our health, make the player invincible briefly, and instantiate a deadMan
        if ((collision.gameObject.tag == "enemy" || collision.gameObject.tag == "harmfulobject") && baseObject.GetComponent<Health>().canGetHurt == true && GetComponent<Renderer>().enabled == true)
        {
            GetComponent<Renderer>().enabled = false;

            baseObject.GetComponent<Health>().healthAmount -= 1;
            baseObject.GetComponent<Health>().canGetHurt = false;
            baseObject.GetComponent<Health>().recordTime = Time.time;

            isDead = true;
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if ((collision.gameObject.tag == "enemy" || collision.gameObject.tag == "harmfulobject") && baseObject.GetComponent<Health>().canGetHurt == true && GetComponent<Renderer>().enabled == true)
		{
			GetComponent<Renderer>().enabled = false;

			baseObject.GetComponent<Health>().healthAmount -= 1;
			baseObject.GetComponent<Health>().canGetHurt = false;
			baseObject.GetComponent<Health>().recordTime = Time.time;

			isDead = true;
		}
	}

}
