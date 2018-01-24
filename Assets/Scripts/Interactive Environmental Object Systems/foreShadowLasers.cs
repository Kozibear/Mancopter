using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foreShadowLasers : MonoBehaviour {

	public float recordTime;

	public GameObject damagingLaser;

	// Use this for initialization
	void Start () {
		recordTime = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.time >= recordTime + 2) {
			Instantiate(damagingLaser, this.transform.position, this.transform.rotation);

			Destroy (gameObject);
		}
	}
}
