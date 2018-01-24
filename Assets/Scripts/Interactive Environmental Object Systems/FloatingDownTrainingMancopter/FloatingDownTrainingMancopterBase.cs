using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingDownTrainingMancopterBase : MonoBehaviour {

	public bool canJump;
	private float recordTime;
	public bool recordTimeLandedOnGround;
	public bool grounded;
	private float recordTime2;
	public bool descending;

	public GameObject groundCheck;
	public Rigidbody2D rb2d;
	public GameObject playerGroundCheck;

	public float jumpStrength;
	public float waitTime;
	public float jumpingTime;

	private bool playerTouching;

	private Vector3 originalPosition;
	private bool setOriginalPosition;

	public float gravityReduction;

	public bool recordDescentBeginningTime;
	public float recordTime3;

	// Use this for initialization
	void Start () {
		setOriginalPosition = true;
		canJump = false;
		recordTimeLandedOnGround = true;
		descending = false;
		playerTouching = false;
		recordDescentBeginningTime = true;
	}

	// Update is called once per frame
	void FixedUpdate () {

		grounded = (Physics2D.Linecast(transform.position, groundCheck.transform.position, 1 << LayerMask.NameToLayer("ground")));

		//we set the mancopter's original position, so that upon returning to the ground, it always returns to this one position, doesn't start digging into the ground
		if (grounded && setOriginalPosition) 
		{
			originalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

			setOriginalPosition = false;

		}


		if(grounded)
		{
			if (recordTimeLandedOnGround) {
				recordTime = Time.time;
				recordTimeLandedOnGround = false;
			}

			descending = false;
			rb2d.gravityScale = 1;
			this.transform.position = originalPosition;
			rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
			recordDescentBeginningTime = true;
		}
		else
		{
			rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
		}

		if (grounded && !playerTouching && Time.time >= recordTime + waitTime)
		{
			originalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			canJump = true;

			recordTime = Time.time;

			recordTime2 = Time.time;
		}

		if(canJump && Time.time < recordTime2 + jumpingTime)
		{

			Vector3 newPosition = transform.position;
			newPosition.y = newPosition.y + jumpStrength - (Time.time - recordTime2)/2;
			transform.position = newPosition;
		}
		else if (canJump && Time.time >= recordTime2 + jumpingTime)
		{
			canJump = false;
		}

		if(!canJump && !grounded)
		{

			if (recordDescentBeginningTime) 
			{
				rb2d.velocity = Vector3.zero;

				recordTime3 = Time.time;
				recordDescentBeginningTime = false;
			}

			descending = true;
			rb2d.gravityScale = gravityReduction;

		}

		if (!grounded) {
			recordTimeLandedOnGround = true;
		}


	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			playerTouching = true;
		}

		if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
		{
			rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
			descending = false;
		}
			
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			playerTouching = true;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			playerTouching = false;
		}
	}
}
