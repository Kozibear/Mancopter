using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {

    public GameObject playerIsAboveSpringCheck;

    public Rigidbody2D rb2d;

    private float recordTime;

    private bool playerTouching;

	// Use this for initialization
	void Start () {
        playerTouching = false;
        recordTime = Time.time;
    }
	
	// Update is called once per frame
	void FixedUpdate () {


        //if the player exits the spring and a fraction of the second has passed, then we can return its gravity to normal
        //this is to prevent the gravity from returning to normal if the player descends so hard on the spring that it and the player
        //briefly lose contact; thus resetting the gravity prematurely
        if (Time.time >= recordTime+0.4 && !playerTouching)
        {
            rb2d.gravityScale = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        //for when the player lands normally
        if (collision.gameObject.tag == "Player" && !(Input.GetKey("down")) && !(Input.GetKey("s")))
        {
            rb2d.gravityScale = 2;
            playerTouching = true;
        }

        //for when the player lands after rapidly descending
        if(collision.gameObject.tag == "Player" && (Input.GetKey("s") || Input.GetKey("down")) )
        {
            rb2d.gravityScale = 6;
            playerTouching = true;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            recordTime = Time.time;
            playerTouching = false;
        }
    }
}
