using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returningPufferfish : MonoBehaviour {

    public GameObject pufferFish;
    public GameObject startingPoint;
    public GameObject endingPoint;

    private bool moveleft;

    // Use this for initialization
    void Start () {
        moveleft = true;
    }
	
	// Update is called once per frame
	void Update () {

    }

    void FixedUpdate()
    {
        //we either move towards the endingpoint if we're at the startingpoint, or move towards the startingpoint if we're at the endingpoint
        if (pufferFish.transform.position == startingPoint.transform.position)
        {
            moveleft = true;
        }

        if (pufferFish.transform.position == endingPoint.transform.position)
        {
            moveleft = false;
        }

        if (moveleft)
        {
            pufferFish.transform.position = Vector3.MoveTowards(pufferFish.transform.position, endingPoint.transform.position, 0.06f);
        }

        if (!moveleft)
        {
            pufferFish.transform.position = Vector3.MoveTowards(pufferFish.transform.position, startingPoint.transform.position, 0.06f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Makes this object the parent of the colliding "player" object
            collision.transform.parent = this.transform;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
}
