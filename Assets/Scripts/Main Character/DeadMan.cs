using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMan : MonoBehaviour {

    public BoxCollider2D box2d;
    public Rigidbody2D rb2d;

    public GameObject[] enemyArray;
    public GameObject[] deadManArray;

    private bool canSpin;

	// Use this for initialization
	void Start () {
        //have to make sure that all box colliders are ignored, otherwise it won't work!!!
        Physics2D.IgnoreCollision(GameObject.Find("CopterBase").GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(GameObject.Find("LeftWallCheck").GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(GameObject.Find("RightWallCheck").GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());


        canSpin = true;
    }
	
	// Update is called once per frame
	void Update () {

        //since enemies can be spawned randomly in a level, we must create our array, and check each of them, in the update
        enemyArray = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject enemy in enemyArray)
        {
            Physics2D.IgnoreCollision(enemy.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        }

        deadManArray = GameObject.FindGameObjectsWithTag("deadMan");

        foreach (GameObject deadMan in deadManArray)
        {
            Physics2D.IgnoreCollision(deadMan.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        }
    }

    void FixedUpdate ()
    {
        if (canSpin)
        {
            transform.Rotate(0, 0, 4f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            canSpin = false;
        }
    }
}