using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftWallCheck : MonoBehaviour
{
    public GameObject copterBase;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //if our box collider is against a wall, we can't continue moving forward
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground") || collision.gameObject.layer == LayerMask.NameToLayer("enemy") || collision.gameObject.layer == LayerMask.NameToLayer("Ally"))
        {
            copterBase.GetComponent<CopterBasicMovements>().collidingWithALeftWall = true;
        }
    }
    //the moment we stop colliding, we can move again
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground") || collision.gameObject.layer == LayerMask.NameToLayer("enemy") || collision.gameObject.layer == LayerMask.NameToLayer("Ally"))
        {
            copterBase.GetComponent<CopterBasicMovements>().collidingWithALeftWall = false;
        }
    }
}