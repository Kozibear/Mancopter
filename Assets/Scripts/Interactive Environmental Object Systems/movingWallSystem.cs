using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingWallSystem : MonoBehaviour {

    public bool moveWall;
    public bool movementComplete;

    public GameObject childWall;

    public BoxCollider2D box2d;

    public float wallXPosition;
    public float wallYPosition;
    public float wallZPosition;
    public float wallMovementSpeed;

    private Vector3 finalWallPosition;

    // Use this for initialization
    void Start () {
        moveWall = false;
        movementComplete = false;

        finalWallPosition = childWall.transform.position + new Vector3(wallXPosition, wallYPosition, wallZPosition);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //if we are hit by a thrown object, we start moving the wall, and disable the box collider
		if(moveWall && !movementComplete)
        {
            //box2d.enabled = false;
            childWall.transform.position = Vector3.MoveTowards(childWall.transform.position, finalWallPosition, wallMovementSpeed);
        }

        //once the wall is in the desired place, we stop moving it move
        if (childWall.transform.position == finalWallPosition)
        {
            movementComplete = true;
        }
	}
}
