using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingTrainingManCopterRotor : MonoBehaviour {

    public GameObject baseObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Tie Position to Copter Base
        transform.position = new Vector3(baseObject.transform.position.x, baseObject.transform.position.y + 1.7f, 0);
    }
}
