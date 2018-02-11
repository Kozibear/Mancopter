using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideVisibilityChecker : MonoBehaviour {

	public float currentWallNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider collision)
	{
		if (collision.gameObject.tag == "visibleWall") {
			currentWallNumber = collision.GetComponentInParent<lava> ().lavaNumber;
		}
	}
}
