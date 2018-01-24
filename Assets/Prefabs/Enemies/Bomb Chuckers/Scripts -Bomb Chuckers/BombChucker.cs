using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombChucker : MonoBehaviour
{
    public GameObject[] deadManArray;

    public Rigidbody2D rb2d;

    public GameObject groundChecker;
    private bool grounded;

    private bool goLeft;
    private bool goRight;
    private bool canMove;
    private bool facingLeft;

    private bool lookAtPlayer;
    private bool storedDirection;

    private float health;

    private float lastBombThrow;
    public GameObject shortLeftParaBomb;
    public GameObject longLeftParaBomb;
    public GameObject shortRightParaBomb;
    public GameObject longRightParaBomb;
    public GameObject straightBomb;

    // Use this for initialization
    void Start()
    {
        goLeft = true;
        goRight = false;
        canMove = true;
        facingLeft = true;

        lastBombThrow = 0f;

        health = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //we freeze the enemy's ability to move, so that the player can't push it
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;

        //we dont' want our enemy to push a deadMan around
        deadManArray = GameObject.FindGameObjectsWithTag("deadMan");

        foreach (GameObject deadMan in deadManArray)
        {
            Physics2D.IgnoreCollision(deadMan.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        }

        //we do a linecast to see if there is any ground in front of us
        grounded = (Physics2D.Linecast(transform.position, groundChecker.transform.position, 1 << LayerMask.NameToLayer("ground")));


        //if there is nothing in front of us, we flip the character and make it go in another direction
        if (!grounded)
        {
            if (goLeft)
            {
                goLeft = false;
                goRight = true;

                Vector3 flipScale = transform.localScale;
                flipScale.x *= -1;
                transform.localScale = flipScale;
            }
            else if (goRight)
            {
                goLeft = true;
                goRight = false;

                Vector3 flipScale = transform.localScale;
                flipScale.x *= -1;
                transform.localScale = flipScale;
            }
        }

        //we make the thing move back and forth
        if (goLeft && canMove)
        {
            facingLeft = true;

            Vector3 newPosition = transform.position;
            newPosition.x = newPosition.x - 0.08f;
            transform.position = newPosition;
        }

        if (goRight && canMove)
        {
            facingLeft = false;

            Vector3 newPosition = transform.position;
            newPosition.x = newPosition.x + 0.08f;
            transform.position = newPosition;
        }

        //we make the enemy face the player when it is in range, by determining the player's current position
        if(lookAtPlayer)
        { 
            //if the different between the player's position to the left of the enemy and the enemy's position is greater than or equal to 1, we make the enemy face left
            if ((this.transform.position.x - GameObject.Find("CopterBase").transform.position.x) >= 1)
            {
                if(!facingLeft)
                {
                    Vector3 flipScale = transform.localScale;
                    flipScale.x *= -1;
                    transform.localScale = flipScale;

                    facingLeft = true;
                }

                //if a few seconds have passed since the last bomb throw, we instantiate a bomb object to damage the player
                if(Time.time >= lastBombThrow+2.2f)
                {
                    //if the player is within 5 units of the bomb chucker, we throw the bombs a little shorter
                    if ((this.transform.position.x - GameObject.Find("CopterBase").transform.position.x) <= 5)
                    {
                        Instantiate(shortLeftParaBomb, transform.position + new Vector3(-1, 1, 0), transform.rotation);
                    }
                    else //if they're further than that (but still within range, throw the bombs a little longer
                    {
                        Instantiate(longLeftParaBomb, transform.position + new Vector3(-1, 1, 0), transform.rotation);
                    }

                    lastBombThrow = Time.time;
                }
            }

            //if the different between the player's position to the right of the enemy and the enemy's position is greater than or equal to 1, we make the enemy face left
            if ((GameObject.Find("CopterBase").transform.position.x - this.transform.position.x) >= 1)
            {
                if (facingLeft)
                {
                    Vector3 flipScale = transform.localScale;
                    flipScale.x *= -1;
                    transform.localScale = flipScale;

                    facingLeft = false;
                }

                //if three seconds have passed since the last bomb throw, we instantiate a bomb object to damage the player
                if (Time.time >= lastBombThrow + 3.0f)
                {
                    //if the player is within 5 units of the bomb chucker, we throw the bombs a little shorter
                    if ((GameObject.Find("CopterBase").transform.position.x - this.transform.position.x) <= 5)
                    {
                        Instantiate(shortRightParaBomb, transform.position + new Vector3(1, 1, 0), transform.rotation);
                    }
                    else //if they're further than that (but still within range, throw the bombs a little longer
                    {
                        Instantiate(longRightParaBomb, transform.position + new Vector3(1, 1, 0), transform.rotation);
                    }

                    lastBombThrow = Time.time;
                }
            }

            //a third if statement for if the player is more or less directly above the chucker
            if (((GameObject.Find("CopterBase").transform.position.x - this.transform.position.x) < 1) && ((this.transform.position.x - GameObject.Find("CopterBase").transform.position.x) < 1))
            {
                //if three seconds have passed since the last bomb throw, we instantiate a bomb object to damage the player
                if (Time.time >= lastBombThrow + 3.0f)
                {
                    Instantiate(straightBomb, transform.position + new Vector3(0, 1, 0), transform.rotation);

                    lastBombThrow = Time.time;
                }
            }

        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "CopterBase")
        {
            canMove = false;
            lookAtPlayer = true;

            //we store the current direction it is facing, so that when the player leaves, it can resume the same direction it was moving in
            storedDirection = facingLeft;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "CopterBase")
        {
            canMove = true;
            lookAtPlayer = false;

            if (storedDirection != facingLeft)
            {
                Vector3 flipScale = transform.localScale;
                flipScale.x *= -1;
                transform.localScale = flipScale;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the player attacks the enemy, it gets hurt!
        if(collision.gameObject.tag == "throwingMan")
        {
            health -= 1;
        }

        if(collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<CopterBasicMovements>().downwardsPush)
        {
            health -= 1;
        }
    }
}
