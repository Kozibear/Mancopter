using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class straightBlade : MonoBehaviour {

    // NO LONGER USING THIS SCRIPT

    public GameObject looseBlade;
    public GameObject baseObject;
    public GameObject referenceBlade;

    private Renderer rend2d;

    private void Awake()
    {
        rend2d = GetComponent<Renderer>();
    }

    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        //if the copter begins descending, the straight blades will render and move to their original, cross-shaped position
        if (baseObject.GetComponent<CopterBasicMovements>().beginDescent)
        {
            transform.position = Vector3.Lerp(transform.position, referenceBlade.transform.position, 0.2f); //vectors are for positions,
            transform.rotation = Quaternion.Lerp(transform.rotation, referenceBlade.transform.rotation, 0.2f); //quaternions are for rotations
            rend2d.enabled = true;
        }
        else //otherwise, the straight blades will not render and constantly occupy the movements as the loose blades
        {
            rend2d.enabled = false;

            transform.position = looseBlade.transform.position;
            transform.rotation = looseBlade.transform.rotation;

        }

        
    }
}
