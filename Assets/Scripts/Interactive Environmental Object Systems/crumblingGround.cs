using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crumblingGround : MonoBehaviour {

    private float recordTime;
    private bool untouched;

    private bool quickDestroy;

    public BoxCollider2D box2d;

	// Use this for initialization
	void Start () {
        untouched = true;
        quickDestroy = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //if its been more than a second since we've been touched, we start fading
        if(!untouched && (Time.time > recordTime+1f) && !quickDestroy)
        {
            //code where we will make the object become transparent
            //code where we will activate the crumbling animation
        }

        //if it has been more than 1.5 seconds, we are destroyed
        if (!untouched && (Time.time > recordTime + 1.5f) && !quickDestroy)
        {
            Destroy(gameObject);
        }

        //if the platform was destroyed by the player rapidly descending downwards, it crumbles quickly
        if(!untouched && Time.time > recordTime + 0.5f && quickDestroy)
        {
            
            Destroy(gameObject);
        }

        //if the player is currently rapidly descending downwards, we make isTrigger true, so that the player can pass right through it
        if (GameObject.Find("CopterBase").GetComponent<CopterBasicMovements>().downwardsPush && untouched)
        {
            box2d.isTrigger = true;
        }

        if (!GameObject.Find("CopterBase").GetComponent<CopterBasicMovements>().downwardsPush && untouched)
        {
            box2d.isTrigger = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && untouched)
        {
				box2d.isTrigger = true;
                recordTime = Time.time;
                untouched = false;
                //where code will go that starts the object's cracking animation
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && untouched)
        {
				box2d.isTrigger = true;
                recordTime = Time.time;
                untouched = false;
                quickDestroy = true;
                //code where we will activate the crumbling animation
        }

    }
}
