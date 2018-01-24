using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwingMansController : MonoBehaviour {

    public Transform throwingMan1;
    public Transform throwingMan2;
    public Transform throwingMan3;
    public Transform throwingMan4;

    public GameObject looseBlade1;
    public GameObject looseBlade2;
    public GameObject looseBlade3;
    public GameObject looseBlade4;

    public GameObject baseObject;

    public float bladeCount;
    private bool canThrowObject = false;

    // Use this for initialization
    void Start () {
        bladeCount = 1;
	}
	
	// Update is called once per frame
	void Update () {


        //if we press either of these keys, and we are not rapidly spinning, we gain the ability to throw an object
        if ((Input.GetKeyDown("left ctrl") || Input.GetKeyDown("k")) && !baseObject.GetComponent<CopterBasicMovements>().rapidlySpinning)
        {
            //however, if none of the looseblades are rendered, it doesn't work
            if (looseBlade1.GetComponent<Renderer>().enabled || looseBlade2.GetComponent<Renderer>().enabled || looseBlade3.GetComponent<Renderer>().enabled || looseBlade4.GetComponent<Renderer>().enabled)
            canThrowObject = true;
        }

        if (canThrowObject)
        {
            //if our bladecount is a certain number and we can still throw objects, we proceed
            if (bladeCount == 1 && canThrowObject)
            {

                //if the mesh of the corresponding loose blade is enabled, we throw the object (slightly lower than the position of the rotor), and disable the renderer
                if (looseBlade1.GetComponent<Renderer>().enabled)
                {
                    Instantiate(throwingMan1, transform.position - new Vector3(0, 1, 0), transform.rotation);
                    //where we will put code that makes the sprite of the looseblade and the thrown object the same
                    //throwingMan.GetComponent<SpriteRenderer>().sprite = looseBlade1.GetComponent<SpriteRenderer>().sprite;
                    looseBlade1.GetComponent<Renderer>().enabled = false;

                    canThrowObject = false;
                }
                //we upgrade the count regardless of whether we throw or not, so that we can try the next one
                bladeCount = 2;
            }

            //if we didn't throw the last one, we throw this one; if we did, canThrowObject is false, and we don't
            if (bladeCount == 2 && canThrowObject)
            {

                if (looseBlade2.GetComponent<Renderer>().enabled)
                {
                    Instantiate(throwingMan2, transform.position - new Vector3(0, 1, 0), transform.rotation);
                    //where we will put code that makes the sprite of the looseblade and the thrown object the same
                    //throwingMan.GetComponent<SpriteRenderer>().sprite = looseBlade1.GetComponent<SpriteRenderer>().sprite;
                    looseBlade2.GetComponent<Renderer>().enabled = false;

                    canThrowObject = false;
                }
                bladeCount = 3;
            }

            if (bladeCount == 3 && canThrowObject)
            {

                if (looseBlade3.GetComponent<Renderer>().enabled)
                {
                    Instantiate(throwingMan3, transform.position - new Vector3(0, 1, 0), transform.rotation);
                    //where we will put code that makes the sprite of the looseblade and the thrown object the same
                    //throwingMan.GetComponent<SpriteRenderer>().sprite = looseBlade1.GetComponent<SpriteRenderer>().sprite;
                    looseBlade3.GetComponent<Renderer>().enabled = false;

                    canThrowObject = false;
                }
                bladeCount = 4;
            }

            if (bladeCount == 4 && canThrowObject)
            {

                if (looseBlade4.GetComponent<Renderer>().enabled)
                {
                    Instantiate(throwingMan4, transform.position - new Vector3(0, 1, 0), transform.rotation);
                    //where we will put code that makes the sprite of the looseblade and the thrown object the same
                    //throwingMan.GetComponent<SpriteRenderer>().sprite = looseBlade1.GetComponent<SpriteRenderer>().sprite;
                    looseBlade4.GetComponent<Renderer>().enabled = false;

                    canThrowObject = false;
                }
                bladeCount = 1;
            }

        }
	}
}
