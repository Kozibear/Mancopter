using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JTplayerGroundCheck : MonoBehaviour {

    public GameObject baseObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(baseObject.transform.position.x, baseObject.transform.position.y + 1.7f, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && collision.gameObject.transform.position.y > this.transform.position.y)
        {
            //Makes this object the parent of the colliding "player" object
            collision.transform.parent = this.transform;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.transform.position.y > this.transform.position.y)
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
