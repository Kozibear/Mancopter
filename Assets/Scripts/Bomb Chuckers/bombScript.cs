using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour {

    public float directionForceX;
    public float directionForceY;

    public Rigidbody2D rb2d;

    public GameObject explosion;


	// Use this for initialization
	void Start () {
        //we addForce to the bomb's rigidbody so that it moves in a parabolic fashion on start
        Vector3 newPush = new Vector3(directionForceX, directionForceY, 0);
        rb2d.AddForce(newPush);
    }
	
	// Update is called once per frame
	void Update () {

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if we touch the player or the ground, we instantiate the explosion in our place
        
		if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "ground" || collision.gameObject.tag == "bombTriggerArea")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }
}
