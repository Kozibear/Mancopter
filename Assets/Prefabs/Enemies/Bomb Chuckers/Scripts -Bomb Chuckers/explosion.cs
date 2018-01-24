using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {

    public float recordTime;

	// Use this for initialization
	void Start () {
        recordTime = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Time.time > recordTime+0.75)
        {
            Destroy(gameObject);
        }
	}
}
