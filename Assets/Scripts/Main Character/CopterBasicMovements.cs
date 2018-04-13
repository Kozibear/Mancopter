using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopterBasicMovements : MonoBehaviour {

    public float jumpForce;
    public float speed;
	public float reducedGravity;
	public float gravityChanging;
	public float slowdownAscent;
	public float slowdownDescent;
	public float groundPoundSpeed;
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
	public bool cancelMomentum = false;
    public bool fallingNoJumping = false;
    public bool grounded;
    public bool startJump = false;
    public bool startDoubleJump = false;
    public bool jumping = false;
    public bool beginDescent = false;
    public bool beginDownwardsPush = false;
    public bool downwardsPush = false;
    public bool emergencyDescent = true;
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

	public GameObject spawnPoint;

	public bool touchingObject;
	public bool insideObject;

	public bool playSpaceRotating;

	public GameObject pufferfishArray;

	public bool collectedGroundPoundTerrainMultiplier;

	public AudioSource jumpSound;
	public AudioSource rotorPop;
	public AudioSource rapidlyDescending;
	public AudioSource connectWithGroundPound;
	public AudioSource enemyHurt;

	public GameObject sittingAnimation;
	public GameObject jumpingAnimation;

    // Use this for initialization
    void Start() {

		GameSave.gameSave.Load ();

		//powerup 1
		if (GameSave.gameSave.powerup1 == 2) {
			storedDoubleJumpTimes += 1;
		}

		//powerup 2
		if (GameSave.gameSave.powerup2 == 2) {
			storedDoubleJumpTimes -= 1;
		}

		//powerup 5
		if (GameSave.gameSave.powerup5 == 2) {
			groundPoundSpeed = 750;
		}

		//powerup 6
		if (GameSave.gameSave.powerup6 == 2) {
			storedDoubleJumpTimes += 1;
		}

		//powerup 9
		if (GameSave.gameSave.powerup9 == 2) {
			slowdownDescent = -40;
		}

		//powerup 11
		if (GameSave.gameSave.powerup11 == 2) {
			storedDoubleJumpTimes += 1;
		}

		//powerup 13
		if (GameSave.gameSave.powerup13 == 2) {
			jumpForce = 1260;
		}

		//powerup 16
		if (GameSave.gameSave.powerup16 == 2) {
			storedDoubleJumpTimes += 1;
		}

		//powerup 20
		if (GameSave.gameSave.powerup20 == 2) {
			storedDoubleJumpTimes += 1;
		}

		rb2d.velocity = Vector3.zero;

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

		playSpaceRotating = false;

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
		if (!playSpaceRotating && (Input.GetKeyDown("up") || Input.GetKeyDown("space") || Input.GetKeyDown("w")) && grounded && !(Input.GetKeyDown("a") || Input.GetKeyDown("d") || Input.GetKeyDown("left") || Input.GetKeyDown("right")) && gameObject.GetComponent<Health>().healthAmount != 0)
        {
            startJump = true;
			jumpSound.Play ();
        }

        //conditions for double jump
		if (!playSpaceRotating && (Input.GetKeyDown("up") || Input.GetKeyDown("space") || Input.GetKeyDown("w")) && (beginDescent || jumping) && !grounded && ((doubleJumpTimes > 0) || (nonRechargingDoubleJumpTimes > 0)) && gameObject.GetComponent<Health>().healthAmount != 0)
        {
            startDoubleJump = true;
			jumpSound.Play ();
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

		if (Input.GetKeyDown ("s") || Input.GetKeyDown ("down")) {
			rapidlyDescending.Play ();

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

		if (Input.GetKeyUp ("s") || Input.GetKeyUp ("down") || grounded) {
			rapidlyDescending.Stop ();
		}

        //we need to reset momentum upon releasing the force down key so that the copter doesn't go barrelling downwards, even with reduced gravity
        if (Input.GetKeyUp("s") || Input.GetKeyUp("down") && !grounded)
        {
			rotorPop.Play ();
            rb2d.velocity = Vector3.zero;
            beginDownwardsPush = false;
        }


		//for summoning pufferfish
		if (GameSave.gameSave.powerup14 == 2 && Input.GetKeyDown (KeyCode.P) && this.gameObject.GetComponent<pointSystem> ().totalPoints >= 100) {

			this.gameObject.GetComponent<pointSystem> ().previouslyEarnedPoints -= 100;

			pufferfishArray.GetComponent<pufferfishArraySystem> ().canSelectLocation = true;
		}
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
			collectedGroundPoundTerrainMultiplier = false;

            rb2d.gravityScale = 1f;

            if (airTime != storedAirTime)
            {
                airTime = storedAirTime;
            }

            if (doubleJumpTimes < storedDoubleJumpTimes)
            {
                doubleJumpTimes = storedDoubleJumpTimes;
            }

			rotorPop.Stop ();

			sittingAnimation.SetActive (true);
			jumpingAnimation.SetActive (false);
        }

		if (!grounded) {
			sittingAnimation.SetActive (false);
			jumpingAnimation.SetActive (true);
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

			/*
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
			*/
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

        //once the player begins descending, we cancel their momentum, and then decrease the gravity (unless we push downwards)
        if (beginDescent && !grounded)
        {
			//print (rb2d.velocity.magnitude);
			if (cancelMomentum && rb2d.velocity.magnitude > 1f)
            {
				Vector3 slowDown = new Vector3(0, slowdownAscent, 0);
				rb2d.AddForce (slowDown);
            }

			if (cancelMomentum && rb2d.velocity.magnitude > 8 && rb2d.velocity.magnitude < 9) {
				rotorPop.Play ();

			}

			if (cancelMomentum && rb2d.velocity.magnitude <= 1f) {
				cancelMomentum = false;
				gravityChanging = 0.6f;
			}

			if (!downwardsPush && !cancelMomentum && gravityChanging > reducedGravity)
            {
				Vector3 slowDown = new Vector3(0, slowdownDescent, 0);
				rb2d.AddForce (slowDown);

				rb2d.gravityScale = gravityChanging;
				gravityChanging -= 0.01f;
            }
			if (!downwardsPush && !cancelMomentum && gravityChanging <= reducedGravity) {
				rb2d.gravityScale = reducedGravity;
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
			/*
            Vector3 newPosition = transform.position;
			newPosition.y = newPosition.y - groundPoundSpeed;
            transform.position = newPosition;
            */

			Vector3 newPush = new Vector3(0, -groundPoundSpeed, 0);
			rb2d.AddForce(newPush);

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

        //after x second of falling, we start floating in mid-air
        if (fallingNoJumping)
        {
            beginDescent = true;
			fallingNoJumping = false;
        }

        //moving left
        if (movingLeft)
        { 
            Vector3 newPosition = transform.position;
            newPosition.x = newPosition.x - speed;
            transform.position = newPosition;

			if (!facingLeft) {
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
			}
            facingLeft = true;
        }

        //moving right
        if (movingRight)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = newPosition.x + speed;
            transform.position = newPosition;

			if (facingLeft) {
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
			}
            facingLeft = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the player is rapidly descending downward when they touch the ground, we make this true so that the camera knows to shake
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground") && collision.gameObject.tag != "spring" && (Input.GetKey("down") || Input.GetKey("s")))
        {
			
            shakeWorld = true;
			connectWithGroundPound.Play ();
            //Important make sure that springs are not included!
        }

		if (collision.gameObject.name == "leftParabolicTerrainCorrupter(Clone)" || collision.gameObject.name == "middletraightTerrainCorrupter(Clone)"  || collision.gameObject.name == "rightParabolicTerrainCorrupter(Clone)") {
		
			if (GameSave.gameSave.powerup8 == 2 && (Input.GetKey ("down") || Input.GetKey ("s"))) {
				this.gameObject.GetComponent<pointSystem> ().pointMultiplier *= 1.05f;
			}
		}
    }

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "harmfulobject" || collision.gameObject.tag == "ground") {
			touchingObject = true;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "harmfulobject" || collision.gameObject.tag == "ground") {
			touchingObject = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//in case we go out of bounds, we are teleported back to the center of the room
		if (collision.gameObject.tag == "teleporter") {

			rb2d.velocity = Vector3.zero;
			transform.position = spawnPoint.transform.position;
		}

		if (collision.gameObject.name == "leftParabolicTerrainCorrupter(Clone)" || collision.gameObject.name == "middletraightTerrainCorrupter(Clone)"  || collision.gameObject.name == "rightParabolicTerrainCorrupter(Clone)") {

			if (GameSave.gameSave.powerup8 == 2 && (Input.GetKey ("down") || Input.GetKey ("s")) && !collectedGroundPoundTerrainMultiplier) {
				this.gameObject.GetComponent<pointSystem> ().pointMultiplier *= 1.05f;
				collectedGroundPoundTerrainMultiplier = true;
			}
		}
	}

	private void OnTriggerStay2D (Collider2D collision)
	{

		if (collision.gameObject.tag == "harmfulobject" && collision.gameObject.name != "flamePillar(Clone)"){

			insideObject = true;

			//for if the player is the child of a pufferfish
			if (gameObject.transform.parent != null) {
				
				if (gameObject.transform.parent.name == "Harmless Belly") {
					gameObject.transform.parent = null;
				}
			}

		}

		if (collision.gameObject.tag == "teleporter") {

			rb2d.velocity = Vector3.zero;
			transform.position = spawnPoint.transform.position;
		}
	}

	private void OnTriggerExit2D (Collider2D collision)
	{
		if (collision.gameObject.tag == "harmfulobject") {
			insideObject = false;
		}
	}

	public void enemyIsDestroyed ()
	{
		enemyHurt.Play ();
	}

}