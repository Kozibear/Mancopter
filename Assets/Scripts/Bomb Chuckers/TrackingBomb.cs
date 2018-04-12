﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingBomb : MonoBehaviour {

	public GameObject player;

	public Vector3 playerPosition;

	public AudioSource bombExplode;

	public bool once;

	// Use this for initialization
	void Start () {
		playerPosition = player.transform.position;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Vector3.MoveTowards (transform.position, playerPosition, 16.5f*Time.deltaTime);

		if (transform.position == playerPosition) {
			if (!once) {
				bombExplode.Play ();
				once = true;
			}
			StartCoroutine ("killExplosion");
		}
	}

	public IEnumerator killExplosion() {
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
	}
}
