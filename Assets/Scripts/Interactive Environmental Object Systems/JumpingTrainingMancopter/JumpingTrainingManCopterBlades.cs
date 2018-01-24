using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingTrainingManCopterBlades : MonoBehaviour {

    public GameObject baseObject;

    public Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (baseObject.GetComponent<JumpingTrainingManCopterBase>().grounded && !baseObject.GetComponent<JumpingTrainingManCopterBase>().canJump) //if grounded, we push a little hard on gravity
        {
            rb2d.gravityScale = 10f;
            rb2d.angularDrag = 1f;
        }
        else if (baseObject.GetComponent<JumpingTrainingManCopterBase>().canJump && !baseObject.GetComponent<JumpingTrainingManCopterBase>().grounded)
        {
            rb2d.gravityScale = 15f;
            rb2d.angularDrag = 6f;
        }
		else if (baseObject.GetComponent<JumpingTrainingManCopterBase>().descending && !baseObject.GetComponent<JumpingTrainingManCopterBase>().playerIsUnderneath)
        {
            rb2d.gravityScale = -40f;
            rb2d.angularDrag = 7f;
        }
		else if (baseObject.GetComponent<JumpingTrainingManCopterBase>().descending && baseObject.GetComponent<JumpingTrainingManCopterBase>().playerIsUnderneath)
		{
			rb2d.gravityScale = 10f;
			rb2d.angularDrag = 1f;
		}
        else //otherwise, gravity and angular drag remains normal
        {
            rb2d.gravityScale = 1f;
            rb2d.angularDrag = 1f;
        }
    }
}
