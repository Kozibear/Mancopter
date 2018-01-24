using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopterBasicMovements : MonoBehaviour {

    public float jumpForce;
    public float speed;
    public Transform GroundCheckCenter;
    public Transform GroundCheckLeft;
    public Transform GroundCheckRight;
    public float storedAirTime;
    public float airTime;
    private float tempTime;
    public Rigidbody2D rb2d;
    public float storedDoubleJumpTimes;
    public float doubleJumpTimes;
    public float nonRechargingDoubleJumpTimes;
    public float emergencyTime;
    public float rapidSpinTime;

    private bool beginCountDown = false;
    private bool cancelMomentum = false;
    //private bool canBeginRapidSpinTime = false;
    public bool fallingNoJumping = false;
    public bool grounded;
    public bool startJump = false;
    public bool startDoubleJump = false;
    public bool jumping = false;
    public bool beginDescent = false;
    public bool beginDownwardsPush = false;
    public bool downwardsPush = false;
    public bool emergencyDescent = true;
    //public bool canRapidSpinAttack = true;
    public bool rapidlySpinning = false;
    public bool immovableDescent = false;
    public bool movingLeft = false;
    public bool movingRight = false;
    public bool facingLeft = false;
    public bool onASpring = false;
    public bool onASpringCharged = false;

    public bool collidingWithALeftWall;
    public bool collidingWithARightWall;

    public bool shakeWorld = false;

	public bool downwardsCancel = false;
	public float recordTimeSinceDownwardsStopped;

	public bool bouncedOffEnemy = false;

    // Use this for initialization
    void Start() {

        //we check if we saved at a checkpoint, and if we did, we transform our position to said checkpoint's position
        if (PlayerPrefs.GetInt("playerAtCheckpoint") == 1)
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("playerSavedPositionX"), PlayerPrefs.GetFloat("playerSavedPositionY"), 0);
        }

        //we save a copy of these values, so that they can be reset upon touching the ground
        airTime = storedAirTime;
        doubleJumpTimes = storedDoubleJumpTimes;

        collidingWithALeftWall = false;
        collidingWithARightWall = false;
    }

    // Update is called once per frame
    void Update()
    {
        //I have to put all the keystrokes in the update, OTHERWISE I need to be pressing the key at the exact moment when the program updates
        if (Input.GetKey("q") && Input.GetKey("z"))
        {
            PlayerPrefs.DeleteAll();
        }

        //conditions for jump
        if ((Input.GetKeyDown("up") || Input.GetKeyDown("space") || Input.GetKeyDown("w")) && grounded && !(Input.GetKeyDown("a") || Input.GetKeyDown("d") || Input.GetKeyDown("left") || Input.GetKeyDown("right")))
        {
            startJump = true;
        }

        //conditions for double jump
        if ((Input.GetKeyDown("up") || Input.GetKeyDown("space") || Input.GetKeyDown("w")) && (beginDescent || jumping) && !grounded && ((doubleJumpTimes > 0) || (nonRechargingDoubleJumpTimes > 0)))
        {
            startDoubleJump = true;
        }

        //conditions for moving left
        if ((Input.GetKey("a") || Input.GetKey("left")) && !jumping && !rapidlySpinning && !immovableDescent && !collidingWithALeftWall && !(Input.GetKey("s") || Input.GetKey("down")))
        {
            movingLeft = true;
        }
        else
        {
            movingLeft = false;
        }

        //conditions for moving right
        if ((Input.GetKey("d") || Input.GetKey("right")) && !jumping && !rapidlySpinning && !immovableDescent && !collidingWithARightWall && !(Input.GetKey("s") || Input.GetKey("down")))
        {
            movingRight = true;
        }
        else
        {
            movingRight = false;
        }

        //conditions for descending (that don't center round time)
        //once we press left, right, or down, everything is reset and the player begins descending
        if (jumping && (Input.GetKeyDown("left") || Input.GetKeyDown("right") || Input.GetKeyDown("a") || Input.GetKeyDown("d") || downwardsPush))
        {
            jumping = false;

            beginDescent = true;

            cancelMomentum = true;
        }

        //force downwards
        if ((Input.GetKey("s") || Input.GetKey("down")) && !grounded && !downwardsCancel)
        {
            beginDownwardsPush = true;
        }
        else
        {
            beginDownwardsPush = false;
        }

        //we need to reset momentum upon releasing the force down key so that the copter doesn't go barrelling downwards, even with reduced gravity
        if (Input.GetKeyUp("s") || Input.GetKeyUp("down") && !grounded)
        {
            rb2d.velocity = Vector3.zero;
            beginDownwardsPush = false;
        }

        //rapid mid-air spin followed by an immediate, unstoppable descent 
		//DECIDED NOT TO IMPLEMENT
		/*
        if ((Input.GetKeyDown("left alt") || Input.GetKeyDown("l")) && !grounded && canRapidSpinAttack)
        {
            canRapidSpinAttack = false;

            jumping = false;
            beginDescent = false;
            downwardsPush = false;
            fallingNoJumping = false;

            rapidlySpinning = true;
            canBeginRapidSpinTime = true;
        }
		*/
    }

    void FixedUpdate() { 

        //I'm making a linecast between the object and the child groundcheck object to see if the ground layer is between them
        //true if it is, false if it isn't
        //at least one of the three groundchecks must be true
        grounded = (Physics2D.Linecast(transform.position, GroundCheckCenter.position, 1 << LayerMask.NameToLayer("ground")) || Physics2D.Linecast(transform.position, GroundCheckLeft.position, 1 << LayerMask.NameToLayer("ground")) || Physics2D.Linecast(transform.position, GroundCheckRight.position, 1 << LayerMask.NameToLayer("ground")) );

        //if the character returns to the ground, the timer is reset, and gravity is reset (so that the player's ascent isn't affected
        if (grounded)
        {
            immovableDescent = false;
            beginDescent = false;
            downwardsPush = false;
            fallingNoJumping = false;
            jumping = false;
            emergencyDescent = true;
            //canRapidSpinAttack = true;

            rb2d.gravityScale = 1f;

            if (airTime != storedAirTime)
            {
                airTime = storedAirTime;
            }

            if (doubleJumpTimes < storedDoubleJumpTimes)
            {
                doubleJumpTimes = storedDoubleJumpTimes;
            }
        }
        
        //jumping
        if (startJump)
        {
            rb2d.velocity = Vector3.zero; //so that if we're on a platform going up and down, we cancel our momentum so that we can jump correctly
            startJump = false;

            jumping = true; //we will use this so that the user can't be moving and jumping up at the same time
            
            //if we're on a spring, and/or entered it by pushing downwards, we increase our jumpforce
            if(onASpring)
            {
                jumpForce += 400;
            }

            if(onASpringCharged)
            {
                jumpForce += 1000;
            }

			if (bouncedOffEnemy) 
			{
				jumpForce += 500;
				airTime = 1.6f;
			}

            Vector3 newPush = new Vector3(0, jumpForce, 0); //we're adding to the y-axis, jumpforce=y value

            rb2d.AddForce(newPush);

            beginCountDown = true; //we begin the countdown of how long the user is in the air

            if(onASpring)
            {
                jumpForce -= 400;
                onASpring = false;
            }

            if(onASpringCharged)
            {
                jumpForce -= 1000;
                onASpringCharged = false;
            }

			if (bouncedOffEnemy) 
			{
				jumpForce -= 500;
				airTime = storedAirTime;
				bouncedOffEnemy = false;
			}
        }
        
        
        //we record the current time, so that we know when to stop the player's jump
        if (beginCountDown)
        {
            tempTime = Time.time; //new method, we record what time it is right now
            beginCountDown = false; //we instantly stop so that only this time is recorded
        }

        //if the alloted airTime has passed, we begin descending
        if (jumping && (Time.time > tempTime + airTime))
        {

            jumping = false;

            beginDescent = true;

            cancelMomentum = true;
        }

        //descending
        //once the player begins descending, we cancel their momentum, and then decrease the gravity (unless we push downwards)
        if (beginDescent && !grounded)
        {
            
            if (cancelMomentum)
            {
                rb2d.velocity = Vector3.zero;
                cancelMomentum = false;
            }

            if (!downwardsPush)
            {
                rb2d.gravityScale = 0.205f;
            }
        }

        //double-jump
        if(startDoubleJump)
        {

			airTime = storedAirTime;

            startDoubleJump = false;

            if ((doubleJumpTimes == 0) && (nonRechargingDoubleJumpTimes > 0))
            {
                nonRechargingDoubleJumpTimes -= 1;
            }

            if (doubleJumpTimes > 0)
            {
                doubleJumpTimes -= 1;
            }

            rb2d.velocity = Vector3.zero;

            Vector3 newPush = new Vector3(0, jumpForce, 0);
            rb2d.AddForce(newPush);

            //we alter these values so that we can start the whole descending process again, as if we just jumped for the first time
            jumping = true;
            beginCountDown = true;
            beginDescent = false;
            rb2d.gravityScale = 1f;
        }

        //force downwards
        if (beginDownwardsPush)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = newPosition.y - 0.25f;
            transform.position = newPosition;

            downwardsPush = true;
        }
        else
        {
            downwardsPush = false;
        }

		//if our downwards push is ever canceled, we un-cancel it after a few seconds
		if (Time.time >= recordTimeSinceDownwardsStopped + 0.3f) {
			downwardsCancel = false;
		}
        
        //falling without jumping first
        if (!grounded && !jumping && !beginDescent && emergencyDescent)
        {
            fallingNoJumping = true;

            emergencyTime = Time.time;

            emergencyDescent = false;
        }

        //after 1 second of falling, we start floating in mid-air
        if ((Time.time > emergencyTime+0.3f) && fallingNoJumping)
        {
            fallingNoJumping = false;
            beginDescent = true;
            cancelMomentum = true;
        }


		//DECIDED NOT TO IMPLEMENT
		/*
        //rapid-spinning
        //timer
        if (rapidlySpinning && canBeginRapidSpinTime)
        {
            rapidSpinTime = Time.time;
            canBeginRapidSpinTime = false;
        }
        if(rapidlySpinning)
        {
            //lock rigidbody location
            rb2d.velocity = Vector3.zero;

            jumping = false;
            beginDescent = false;
            downwardsPush = false;
            fallingNoJumping = false;

            //we make it more slightly upwards as it's doing this
            Vector3 newPosition = transform.position;
            newPosition.y = newPosition.y + 0.015f;
            transform.position = newPosition;
        }
        //we make the copter fall after the timer ends
        if ((Time.time >= rapidSpinTime+1f) && rapidlySpinning)
        {
            rapidlySpinning = false;

            immovableDescent = true;
            rb2d.gravityScale = 1f;
        }
		*/


        //moving left
        if (movingLeft)
        { 
            Vector3 newPosition = transform.position;
            newPosition.x = newPosition.x - speed;
            transform.position = newPosition;

            facingLeft = true;
        }

        //moving right
        if (movingRight)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = newPosition.x + speed;
            transform.position = newPosition;

            facingLeft = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "spring" && !downwardsPush)
        {
            onASpring = true;
        }
        else if (collision.gameObject.tag == "spring" && downwardsPush)
        {
            onASpringCharged = true;
        }
        else
        {
            //so that if we fall off a spring and end up on another surface, we don't use our spring jump on a non-spring surface
            onASpring = false;
            onASpringCharged = false;

        }

        //if the player is rapidly descending downward when they touch the ground, we make this true so that the camera knows to shake
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground") && collision.gameObject.tag != "spring" && (Input.GetKey("down") || Input.GetKey("s")))
        {
            shakeWorld = true;
            //Important make sure that springs are not included!
        }

    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//in case we go out of bounds, we are teleported back to the center of the room
		if (collision.gameObject.tag == "teleporter") {

			rb2d.velocity = Vector3.zero;
			transform.parent.transform.position = GameObject.Find ("SpawnPoint").transform.position;

		}
			
	}
}
