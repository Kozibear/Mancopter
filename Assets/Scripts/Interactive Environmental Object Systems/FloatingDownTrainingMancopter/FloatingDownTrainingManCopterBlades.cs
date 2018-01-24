using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingDownTrainingManCopterBlades : MonoBehaviour {

	public GameObject baseObject;

	public GameObject referenceBlade;

	public Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		

		if (baseObject.GetComponent<FloatingDownTrainingMancopterBase>().grounded && !baseObject.GetComponent<FloatingDownTrainingMancopterBase>().canJump) //if grounded, we push a little hard on gravity
		{
			rb2d.gravityScale = 10f;
			rb2d.angularDrag = 1f;
		}
		else if (baseObject.GetComponent<FloatingDownTrainingMancopterBase>().canJump && !baseObject.GetComponent<FloatingDownTrainingMancopterBase>().grounded)
		{
			rb2d.gravityScale = 15f;
			rb2d.angularDrag = 5f;
		}
		else if (baseObject.GetComponent<FloatingDownTrainingMancopterBase>().descending)
		{
			transform.position = Vector3.MoveTowards(transform.position, referenceBlade.transform.position, (Time.time-baseObject.GetComponent<FloatingDownTrainingMancopterBase>().recordTime3)*0.8f ); //vectors are for positions,
			transform.rotation = Quaternion.Lerp(transform.rotation, referenceBlade.transform.rotation, (Time.time-baseObject.GetComponent<FloatingDownTrainingMancopterBase>().recordTime3)*10f ); //quaternions are for rotations
		}
		else //otherwise, gravity and angular drag remains normal
		{
			rb2d.gravityScale = 1f;
			rb2d.angularDrag = 1f;
		}
	}
}
