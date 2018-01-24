using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturningSawbladeSystem : MonoBehaviour {

    public GameObject sawblade;
    public GameObject startingPoint;
    public GameObject endingPoint;

    private bool moveleft;

	// Use this for initialization
	void Start () {
        moveleft = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //we either move towards the endingpoint if we're at the startingpoint, or move towards the startingpoint if we're at the endingpoint
        if (sawblade.transform.position == startingPoint.transform.position)
        {
            moveleft = true;
        }

        if (sawblade.transform.position == endingPoint.transform.position)
        {
            moveleft = false;
        }

        if (moveleft)
        {
            sawblade.transform.position = Vector3.MoveTowards(sawblade.transform.position, endingPoint.transform.position, 0.142f);
        }
        
        if(!moveleft)
        {
            sawblade.transform.position = Vector3.MoveTowards(sawblade.transform.position, startingPoint.transform.position, 0.142f);
        }

    }

}
