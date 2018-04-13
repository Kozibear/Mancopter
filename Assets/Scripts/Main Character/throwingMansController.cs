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
			if (looseBlade1.transform.GetChild(0).gameObject.activeInHierarchy || looseBlade1.transform.GetChild(1).gameObject.activeInHierarchy || looseBlade2.transform.GetChild(0).gameObject.activeInHierarchy || looseBlade2.transform.GetChild(1).gameObject.activeInHierarchy || looseBlade3.transform.GetChild(0).gameObject.activeInHierarchy || looseBlade3.transform.GetChild(1).gameObject.activeInHierarchy || looseBlade4.transform.GetChild(0).gameObject.activeInHierarchy || looseBlade4.transform.GetChild(1).gameObject.activeInHierarchy)
            canThrowObject = true;
        }

        if (canThrowObject)
        {
            //if our bladecount is a certain number and we can still throw objects, we proceed
            if (bladeCount == 1 && canThrowObject)
            {

                //if the mesh of the corresponding loose blade is enabled, we throw the object (slightly lower than the position of the rotor), and disable the renderer
				if (looseBlade1.transform.GetChild(0).gameObject.activeInHierarchy || looseBlade1.transform.GetChild(1).gameObject.activeInHierarchy)
                {
					Transform ThrowingMan1 = Instantiate(throwingMan1, transform.position - new Vector3(0, 1, 0), transform.rotation);

					ThrowingMan1.GetComponent<throwingMan> ().playerBase = baseObject;
					ThrowingMan1.GetComponent<throwingMan> ().looseblade1 = looseBlade1;
					ThrowingMan1.GetComponent<throwingMan> ().looseblade2 = looseBlade2;
					ThrowingMan1.GetComponent<throwingMan> ().looseblade3 = looseBlade3;
					ThrowingMan1.GetComponent<throwingMan> ().looseblade4 = looseBlade4;

                    //where we will put code that makes the sprite of the looseblade and the thrown object the same
                    //throwingMan.GetComponent<SpriteRenderer>().sprite = looseBlade1.GetComponent<SpriteRenderer>().sprite;
					looseBlade1.GetComponent<looseBlade>().canRenderSprites = false;

                    canThrowObject = false;
                }
                //we upgrade the count regardless of whether we throw or not, so that we can try the next one
                bladeCount = 2;
            }

            //if we didn't throw the last one, we throw this one; if we did, canThrowObject is false, and we don't
            if (bladeCount == 2 && canThrowObject)
            {

				if (looseBlade2.transform.GetChild(0).gameObject.activeInHierarchy || looseBlade2.transform.GetChild(1).gameObject.activeInHierarchy)
                {
					Transform ThrowingMan2 = Instantiate(throwingMan2, transform.position - new Vector3(0, 1, 0), transform.rotation);

					ThrowingMan2.GetComponent<throwingMan> ().playerBase = baseObject;
					ThrowingMan2.GetComponent<throwingMan> ().looseblade1 = looseBlade1;
					ThrowingMan2.GetComponent<throwingMan> ().looseblade2 = looseBlade2;
					ThrowingMan2.GetComponent<throwingMan> ().looseblade3 = looseBlade3;
					ThrowingMan2.GetComponent<throwingMan> ().looseblade4 = looseBlade4;

                    //where we will put code that makes the sprite of the looseblade and the thrown object the same
                    //throwingMan.GetComponent<SpriteRenderer>().sprite = looseBlade1.GetComponent<SpriteRenderer>().sprite;
					looseBlade2.GetComponent<looseBlade>().canRenderSprites = false;

                    canThrowObject = false;
                }
                bladeCount = 3;
            }

            if (bladeCount == 3 && canThrowObject)
            {

				if (looseBlade3.transform.GetChild(0).gameObject.activeInHierarchy || looseBlade3.transform.GetChild(1).gameObject.activeInHierarchy)
                {
					Transform ThrowingMan3 = Instantiate(throwingMan3, transform.position - new Vector3(0, 1, 0), transform.rotation);

					ThrowingMan3.GetComponent<throwingMan> ().playerBase = baseObject;
					ThrowingMan3.GetComponent<throwingMan> ().looseblade1 = looseBlade1;
					ThrowingMan3.GetComponent<throwingMan> ().looseblade2 = looseBlade2;
					ThrowingMan3.GetComponent<throwingMan> ().looseblade3 = looseBlade3;
					ThrowingMan3.GetComponent<throwingMan> ().looseblade4 = looseBlade4;

                    //where we will put code that makes the sprite of the looseblade and the thrown object the same
                    //throwingMan.GetComponent<SpriteRenderer>().sprite = looseBlade1.GetComponent<SpriteRenderer>().sprite;
					looseBlade3.GetComponent<looseBlade>().canRenderSprites = false;

                    canThrowObject = false;
                }
                bladeCount = 4;
            }

            if (bladeCount == 4 && canThrowObject)
            {

				if (looseBlade4.transform.GetChild(0).gameObject.activeInHierarchy || looseBlade4.transform.GetChild(1).gameObject.activeInHierarchy)
                {
					Transform ThrowingMan4 = Instantiate(throwingMan4, transform.position - new Vector3(0, 1, 0), transform.rotation);

					ThrowingMan4.GetComponent<throwingMan> ().playerBase = baseObject;
					ThrowingMan4.GetComponent<throwingMan> ().looseblade1 = looseBlade1;
					ThrowingMan4.GetComponent<throwingMan> ().looseblade2 = looseBlade2;
					ThrowingMan4.GetComponent<throwingMan> ().looseblade3 = looseBlade3;
					ThrowingMan4.GetComponent<throwingMan> ().looseblade4 = looseBlade4;

                    //where we will put code that makes the sprite of the looseblade and the thrown object the same
                    //throwingMan.GetComponent<SpriteRenderer>().sprite = looseBlade1.GetComponent<SpriteRenderer>().sprite;
					looseBlade4.GetComponent<looseBlade>().canRenderSprites = false;

                    canThrowObject = false;
                }
                bladeCount = 1;
            }
        }
	}
}
