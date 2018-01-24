using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBladeMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(0, 0, 5.0f);
    }
}
