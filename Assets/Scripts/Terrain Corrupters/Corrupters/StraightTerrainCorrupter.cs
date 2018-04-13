using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightTerrainCorrupter : MonoBehaviour {

    //private bool playerInRange;

    public float health;

    public GameObject[] deadManArray;

    public GameObject StraightBomb;

    public GameObject bombDestinationPoint;

    public bool canThrowBomb;

	public float recordTime;

	public bool invincibility;
	public float invincibilityTimer;

	public BoxCollider2D box2d;

	public GameObject child1;

	public GameObject Player;

	public AudioSource shootBomb;
	public AudioSource hurt;

	bool once;
	bool pointsEarn;

    // Use this for initialization
    void Start () {
        //playerInRange = false;
        health = 1;

        canThrowBomb = true;

		recordTime = Time.time;

		GameSave.gameSave.Load ();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //we don't want this enemy to accidentally push around deadmans
        deadManArray = GameObject.FindGameObjectsWithTag("deadMan");

        foreach (GameObject deadMan in deadManArray)
        {
            Physics2D.IgnoreCollision(deadMan.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        }

		//if the player is in range and we don't currently have a corrupted terrain child, and the player isn't currently in a state of invincibility from getting hurt
		if (canThrowBomb && Player.GetComponent<Health>().canGetHurt)
        {
            canThrowBomb = false;

            GameObject Bomb = Instantiate(StraightBomb, transform.position + new Vector3(0, -0.5f, 0), transform.rotation);

			shootBomb.Play ();
            //we make the bomb the parent, so that we link their action together, can later on easily reset the ability to throw something
            Bomb.transform.parent = this.transform;

            //we make the bomb move towards the destination point object

        }

		//we are no longer invincible after 0.5 seconds
		if (Time.time >= invincibilityTimer+0.5f) {
			invincibility = false;
		}

		//if the player is currently rapidly descending downwards and we have one hit point left, we make isTrigger true, so that the player can pass right through it,
		//and deactivate our groundcheck child
		if (Player.GetComponent<CopterBasicMovements>().downwardsPush && health == 1 && !invincibility)
		{
			box2d.isTrigger = true;
			child1.SetActive (false);
		}

		if (!Player.GetComponent<CopterBasicMovements>().downwardsPush && health == 1 && !invincibility)
		{
			box2d.isTrigger = false;
			child1.SetActive (true);
		}

		if (health <= 0)
		{
			if (!pointsEarn) {
				Player.GetComponent<pointSystem> ().previouslyEarnedPoints += 100;
				pointsEarn = true;
			}
			StartCoroutine ("Destroy");
		}

		if (Time.time >= recordTime + 25f) {
			StartCoroutine ("Destroy");
		}
    }
		
	private void OnCollisionEnter2D(Collision2D collision)
	{
		//if the player attacks the enemy, it gets hurt!
		if ((collision.gameObject.tag == "throwingMan" || (collision.gameObject.tag == "harmfulobject" && collision.gameObject.name != "CorrupterStraightBomb(Clone)")) && !invincibility)
		{
			health -= 1;

			invincibility = true;
			invincibilityTimer = Time.time;
		}

		if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<CopterBasicMovements>().downwardsPush && !invincibility && health != 1)
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
		if (collision.gameObject.tag == "Player" && !invincibility && health == 1)
		{
			box2d.isTrigger = true;
			health -= 1;
		}

		if (collision.gameObject.layer == LayerMask.NameToLayer("powerup9avoid") && GameSave.gameSave.powerup7 == 2)
		{
			Player.GetComponent<pointSystem> ().previouslyEarnedPoints += 250;
		}

		if (collision.gameObject.tag == "harmfulobject"  && collision.gameObject.name != "CorrupterStraightBomb(Clone)") {
			health -= 1;
		}

	}

	public IEnumerator Destroy ()
	{
		gameObject.transform.GetChild (2).gameObject.SetActive (false);
		gameObject.transform.GetChild (3).gameObject.SetActive (true);

		canThrowBomb = false;
		if (!once) {
			hurt.Play ();
			once = true;
		}
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
	}
}
