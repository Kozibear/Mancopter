using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connect : MonoBehaviour {

	public GameObject lower;
	public GameObject upper;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		upper.transform.position = new Vector3(lower.transform.position.x, lower.transform.position.y+1.7f, 0);
	}
}
