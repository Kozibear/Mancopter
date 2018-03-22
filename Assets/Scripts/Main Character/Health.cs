using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //IMP - must have this in order to load a scene!

public class Health : MonoBehaviour {

    public float healthAmount;

    public bool canGetHurt;
    public bool beginHarmedSequence;
    public bool canLoseMan;

    public float recordTime;

	public GameObject looseBlade1;
	public GameObject looseBlade2;
	public GameObject looseBlade3;
	public GameObject looseBlade4;

	public Image damageFlash;
	public Color damageFlashColor;
	public bool makeFlashRed;

	// Use this for initialization
	void Start () {
        healthAmount = 4;
        canGetHurt = true;
        canLoseMan = false;

		damageFlashColor = damageFlash.color;
		damageFlashColor.a = 0f;

		damageFlash.gameObject.SetActive (false);
	}

    // Update is called once per frame
    void Update() {
        //every time the player loses one hit point, they lose one of their blades
        //when they lose a blade, it falls down, and ignores other objects' collision
        if (beginHarmedSequence)
        {
            //this is done so that the player doesn't immediately lose another man
            canLoseMan = true;

            if (healthAmount == 3 && canLoseMan)
            {
                //first, we check to see which blade, in order of 1-4, is still rendered, and disable the first one that still is
                //(so that, for example, if the second blade is killed in a throw, we know to kill off the first blade, not the second
				if (looseBlade1.GetComponent<Renderer>().enabled)
                {
                    //we disable its mesh renderer, and let the blade know that it is dead so that it can instantiate a dead copy in its place
					looseBlade1.GetComponent<Renderer>().enabled = false;
					looseBlade1.GetComponent<looseBlade>().isDead = true;
                }
				else if (looseBlade2.GetComponent<Renderer>().enabled)
                {
					looseBlade2.GetComponent<Renderer>().enabled = false;
					looseBlade2.GetComponent<looseBlade>().isDead = true;
                }
				else if (looseBlade3.GetComponent<Renderer>().enabled)
                {
					looseBlade3.GetComponent<Renderer>().enabled = false;
					looseBlade3.GetComponent<looseBlade>().isDead = true;
                }
				else if (looseBlade4.GetComponent<Renderer>().enabled)
                {
					looseBlade4.GetComponent<Renderer>().enabled = false;
					looseBlade4.GetComponent<looseBlade>().isDead = true;
                }

                //finally, we make this false, so that we don't lose another man after this!
                canLoseMan = false;
            }

            if (healthAmount == 2 && canLoseMan)
            {
				if (looseBlade1.GetComponent<Renderer>().enabled)
                {
					looseBlade1.GetComponent<Renderer>().enabled = false;
					looseBlade1.GetComponent<looseBlade>().isDead = true;
                }
				else if (looseBlade2.GetComponent<Renderer>().enabled)
                {
					looseBlade2.GetComponent<Renderer>().enabled = false;
					looseBlade2.GetComponent<looseBlade>().isDead = true;
                }
				else if (looseBlade3.GetComponent<Renderer>().enabled)
                {
					looseBlade3.GetComponent<Renderer>().enabled = false;
					looseBlade3.GetComponent<looseBlade>().isDead = true;
                }
				else if (looseBlade4.GetComponent<Renderer>().enabled)
                {
					looseBlade4.GetComponent<Renderer>().enabled = false;
					looseBlade4.GetComponent<looseBlade>().isDead = true;
                }

                canLoseMan = false;
            }

            if (healthAmount == 1 && canLoseMan)
            {
				if (looseBlade1.GetComponent<Renderer>().enabled)
                {
					looseBlade1.GetComponent<Renderer>().enabled = false;
					looseBlade1.GetComponent<looseBlade>().isDead = true;
                }
				else if (looseBlade2.GetComponent<Renderer>().enabled)
                {
					looseBlade2.GetComponent<Renderer>().enabled = false;
					looseBlade2.GetComponent<looseBlade>().isDead = true;
                }
				else if (looseBlade3.GetComponent<Renderer>().enabled)
                {
					looseBlade3.GetComponent<Renderer>().enabled = false;
					looseBlade3.GetComponent<looseBlade>().isDead = true;
                }
				else if (looseBlade4.GetComponent<Renderer>().enabled)
                {
					looseBlade4.GetComponent<Renderer>().enabled = false;
					looseBlade4.GetComponent<looseBlade>().isDead = true;
                }

                canLoseMan = false;
            }

            if (healthAmount == 0 && canLoseMan)
            {
				if (looseBlade1.GetComponent<Renderer>().enabled)
                {
					looseBlade1.GetComponent<Renderer>().enabled = false;
					looseBlade1.GetComponent<looseBlade>().isDead = true;
                }
				else if (looseBlade2.GetComponent<Renderer>().enabled)
                {
					looseBlade2.GetComponent<Renderer>().enabled = false;
					looseBlade2.GetComponent<looseBlade>().isDead = true;
                }
				else if (looseBlade3.GetComponent<Renderer>().enabled)
                {
					looseBlade3.GetComponent<Renderer>().enabled = false;
					looseBlade3.GetComponent<looseBlade>().isDead = true;
                }
				else if (looseBlade4.GetComponent<Renderer>().enabled)
                {
					looseBlade4.GetComponent<Renderer>().enabled = false;
					looseBlade4.GetComponent<looseBlade>().isDead = true;
                }

                canLoseMan = false;
            }

			damageFlash.gameObject.SetActive (true);
			makeFlashRed = true;
			damageFlashColor.a = 1;
			beginHarmedSequence = false;
        }
    }

    private void FixedUpdate()
    {
		//this is for making the screen flash red
		damageFlash.color = damageFlashColor;

		if (makeFlashRed) {
			damageFlashColor.a -= 0.02f;

			if (damageFlashColor.a <= 0)
			{
				damageFlashColor.a = 0;
				makeFlashRed = false;
				damageFlash.gameObject.SetActive (false);
			}
		}

        //if two seconds haven't elapsed since the player was hit, they can't get hurt, and flash
        //after two seconds, they can get hurt
        if (Time.time < recordTime + 2f)
        {
            //the player flashes
            canGetHurt = false;


        }
        else if (Time.time >= recordTime + 2f)
        {
            canGetHurt = true;
        }


        if (healthAmount <= 0 && canGetHurt)
        {
			GameSave.gameSave.Load ();
			GameSave.gameSave.mostRecentScore = this.gameObject.GetComponent<pointSystem> ().totalPoints;
			/*
			GameSave.gameSave.powerup1 = 2;
			GameSave.gameSave.powerup4 = 2;
			GameSave.gameSave.powerup11 = 2;
			GameSave.gameSave.powerup12 = 2;
			GameSave.gameSave.powerup17 = 2;
			*/
			GameSave.gameSave.Save ();

			SceneManager.LoadScene("Splash Upgrades Scores", LoadSceneMode.Single);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //every time the player collides with a harmful object or an enemy (unless they are rapidly descending), they lose one of their hit points
        //however, they are also briefly removed from harm for a few seconds
        if ((collision.gameObject.tag == "enemy" && !this.GetComponent<CopterBasicMovements>().downwardsPush) || collision.gameObject.tag == "harmfulobject")
        {
            if(canGetHurt)
            {
                healthAmount -= 1;
                beginHarmedSequence = true;
                recordTime = Time.time;
                canGetHurt = false;
            }
        }
    }

    //for gameobjects like explosions, which we want to pass through
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "harmfulobject")
        {
            if (canGetHurt)
            {
                healthAmount -= 1;
                beginHarmedSequence = true;
                recordTime = Time.time;
                canGetHurt = false;
            }
        }
    }

    //if the player continues to collide with the object, they will continue to lose health
    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "enemy" && !this.GetComponent<CopterBasicMovements>().downwardsPush) || collision.gameObject.tag == "harmfulobject")
        {

            if (canGetHurt)
            {
                healthAmount -= 1;
                beginHarmedSequence = true;
                recordTime = Time.time;
                canGetHurt = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "harmfulobject")
        {
            if (canGetHurt)
            {
                healthAmount -= 1;
                beginHarmedSequence = true;
                recordTime = Time.time;
                canGetHurt = false;
            }
        }
    }
}
