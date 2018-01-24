using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour {

	public Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
	}
	
	void FixedUpdate()
	{
		//we freeze the enemy's ability to move, so that the player can't push it
		rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
	}
}
