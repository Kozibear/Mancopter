using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSawBladeSystem : MonoBehaviour {

    public GameObject sawblade;
    public GameObject endingPoint;

    private bool moveForward;

    // Use this for initialization
    void Start () {
        moveForward = false;
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void FixedUpdate()
    {

        if (moveForward)
        {
            sawblade.transform.position = Vector3.MoveTowards(sawblade.transform.position, endingPoint.transform.position, 0.134f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            moveForward = true;
        }
    }
}
