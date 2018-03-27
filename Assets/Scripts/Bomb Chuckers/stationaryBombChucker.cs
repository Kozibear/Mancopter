using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stationaryBombChucker : MonoBehaviour
{
    public GameObject[] deadManArray;

    //public Rigidbody2D rb2d;

    public GameObject groundChecker;

    private bool facingLeft;

    private bool lookAtPlayer;
    private bool storedDirection;

    public float health;

    private float lastBombThrow;
    public GameObject shortLeftParaBomb;
    public GameObject longLeftParaBomb;
    public GameObject shortRightParaBomb;
    public GameObject longRightParaBomb;
    public GameObject straightBomb;

	public GameObject simpleBomb;

	public float recordTime;

	public bool invincibility;
	public float invincibilityTimer;

	public BoxCollider2D box2d;

	public GameObject child2;

	public GameObject Player;

    // Use this for initialization
    void Start()
    {
        facingLeft = true;

        lastBombThrow = 0f;

        health = 2;

		recordTime = Time.time;

		invincibility = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //we freeze the enemy's ability to move, so that the player can't push it
        //rb2d.constraints = RigidbodyConstraints2D.FreezeAll;

        //we dont' want our enemy to push a deadMan around
        deadManArray = GameObject.FindGameObjectsWithTag("deadMan");

        foreach (GameObject deadMan in deadManArray)
        {
            Physics2D.IgnoreCollision(deadMan.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        }

        

            //if the difference between the player's position to the left of the enemy and the enemy's position is greater than or equal to 1, we make the enemy face left
		if ((this.transform.position.x - Player.transform.position.x) >= 1)
            {
                if (!facingLeft)
                {
                    Vector3 flipScale = transform.localScale;
                    flipScale.x *= -1;
                    transform.localScale = flipScale;

                    facingLeft = true;
                }

			/*
                //if a few seconds have passed since the last bomb throw, we instantiate a bomb object to damage the player
			if (Time.time >= lastBombThrow + 2.0f && Time.time >= recordTime + 0.5f && Time.time <= recordTime+ 6.5f)
                {
                    //if the player is within 5 units of the bomb chucker, we throw the bombs a little shorter
				if ((this.transform.position.x - Player.transform.position.x) <= 5)
                    {
                        Instantiate(shortLeftParaBomb, transform.position + new Vector3(-1, 1, 0), transform.rotation);
                    }
                    else //if they're further than that (but still within range, throw the bombs a little longer
                    {
                        Instantiate(longLeftParaBomb, transform.position + new Vector3(-1, 1, 0), transform.rotation);
                    }

                    lastBombThrow = Time.time;
                }
			*/

            }

            //if the different between the player's position to the right of the enemy and the enemy's position is greater than or equal to 1, we make the enemy face right
		if ((Player.transform.position.x - this.transform.position.x) >= 1)
            {
                if (facingLeft)
                {
                    Vector3 flipScale = transform.localScale;
                    flipScale.x *= -1;
                    transform.localScale = flipScale;

                    facingLeft = false;
                }

			/*
                //if three seconds have passed since the last bomb throw, we instantiate a bomb object to damage the player
			if (Time.time >= lastBombThrow + 2.0f && Time.time >= recordTime + 0.5f && Time.time <= recordTime+ 6.5f)
                {
                    //if the player is within 5 units of the bomb chucker, we throw the bombs a little shorter
				if ((Player.transform.position.x - this.transform.position.x) <= 5)
                    {
                        Instantiate(shortRightParaBomb, transform.position + new Vector3(1, 1, 0), transform.rotation);
                    }
                    else //if they're further than that (but still within range, throw the bombs a little longer
                    {
                        Instantiate(longRightParaBomb, transform.position + new Vector3(1, 1, 0), transform.rotation);
                    }

                    lastBombThrow = Time.time;
                }
			*/

            }

		/*
            //a third if statement for if the player is more or less directly above the chucker
		if (((Player.transform.position.x - this.transform.position.x) < 1) && ((this.transform.position.x - Player.transform.position.x) < 1))
            {
                //if three seconds have passed since the last bomb throw, we instantiate a bomb object to damage the player
                if (Time.time >= lastBombThrow + 3.0f)
                {
                    Instantiate(straightBomb, transform.position + new Vector3(0, 1, 0), transform.rotation);

                    lastBombThrow = Time.time;
                }
            }
		*/

		//we are no longer invincible after 0.5 seconds
		if (Time.time >= invincibilityTimer+0.5f) {
			invincibility = false;
		}

		//if the player is currently rapidly descending downwards and we have one hit point left, we make isTrigger true, so that the player can pass right through it,
		//and deactivate our groundcheck
		if (Player.GetComponent<CopterBasicMovements>().downwardsPush && health == 1 && !invincibility)
		{
			box2d.isTrigger = true;
			child2.SetActive (false);
		}

		if (!Player.GetComponent<CopterBasicMovements>().downwardsPush && health == 1 && !invincibility)
		{
			box2d.isTrigger = false;
			child2.SetActive (true);
		}

		if (health <= 0)
		{
			Player.GetComponent<pointSystem> ().previouslyEarnedPoints += 100;
			Destroy(gameObject);
		}

		if (Time.time >= recordTime + 10.0f) {

			Destroy(gameObject);
		}

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the player attacks the enemy, it gets hurt!
		if ((collision.gameObject.tag == "throwingMan" || collision.gameObject.tag == "harmfulobject") && !invincibility)
        {
            health -= 1;

			invincibility = true;
			invincibilityTimer = Time.time;
        }

		if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<CopterBasicMovements>().downwardsPush && !invincibility && health == 2)
        {
            health -= 1;

			invincibility = true;
			invincibilityTimer = Time.time;

			//if the player attempts to ground pound us, they automatically get shot up, as if on a spring

			//we need to make sure to cancel out these things first:
			collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			collision.gameObject.GetComponent<CopterBasicMovements> ().downwardsCancel = true;
			collision.gameObject.GetComponent<CopterBasicMovements> ().downwardsPush = false;

			collision.gameObject.GetComponent<CopterBasicMovements> ().recordTimeSinceDownwardsStopped = Time.time;

			//and now we force the player to jump upwards
			collision.gameObject.GetComponent<CopterBasicMovements> ().bouncedOffEnemy = true;
			collision.gameObject.GetComponent<CopterBasicMovements> ().startJump = true;
        }

		if (collision.gameObject.tag == "Player" && !collision.gameObject.GetComponent<CopterBasicMovements>().downwardsPush)
		{
			//Makes this object the parent of the colliding "player" object
			collision.transform.parent = this.transform;
		}
    }

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player" && !collision.gameObject.GetComponent<CopterBasicMovements>().downwardsPush)
		{
			collision.transform.parent = this.transform;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.transform.parent = null;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//if the player crashes through us a second time, our box collider is set to trigger, so the player passes right through us

		if (collision.gameObject.tag == "Player" && !invincibility && health == 1 && collision.gameObject != null)
		{
			box2d.isTrigger = true;
			health -= 1;
		}

		if (collision.gameObject.tag == "harmfulobject" && !invincibility) {
			health -= 1;

			invincibility = true;
			invincibilityTimer = Time.time;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "harmfulobject" && !invincibility) {
			health -= 1;

			invincibility = true;
			invincibilityTimer = Time.time;
		}
	}
}