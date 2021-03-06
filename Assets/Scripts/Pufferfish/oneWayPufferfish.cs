﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneWayPufferfish : MonoBehaviour {

	public GameObject pufferFish;
	public GameObject startingPoint;
	public GameObject endingPoint;

	public float movementSpeed;

	public GameObject[] groundArray;
	public GameObject[] enemyArray;
	public GameObject[] harmlessEnemyArray;

	private bool moveleft;

	public bool moveForward;

	public float health = 1;

	public GameObject Player;

	public AudioSource hurt;

	bool once;

	// Use this for initialization
	void Start () {

		GameSave.gameSave.Load ();

		//we create an array of all our objects with the ground tag (less intensive on unity, and less time-consuming, than individually listing the names of all objects)
		groundArray = GameObject.FindGameObjectsWithTag("ground");

		//for each individual blade object in our bladeArray, we ignore its box collider
		foreach (GameObject ground in groundArray)
		{
			Physics2D.IgnoreCollision(ground.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
		}

		movementSpeed = 0.22f;

		moveForward = true;
	}
		
	void FixedUpdate()
	{
		//we also ignore all enemies currently in the game
		enemyArray = GameObject.FindGameObjectsWithTag ("enemy");

		foreach (GameObject enemy in enemyArray)
		{
			Physics2D.IgnoreCollision(enemy.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
		}

		harmlessEnemyArray = GameObject.FindGameObjectsWithTag ("harmlessEnemy");

		foreach (GameObject enemy2 in harmlessEnemyArray)
		{
			Physics2D.IgnoreCollision(enemy2.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
		}

		if (moveForward) {
			pufferFish.transform.position = Vector3.MoveTowards (pufferFish.transform.position, endingPoint.transform.position, movementSpeed);
		}

		if (pufferFish.transform.position == endingPoint.transform.position) {
			Destroy (transform.parent.gameObject);
		}

		if (health <= 0) {
			//Destroy (transform.parent.gameObject);
			StartCoroutine ("Destroy");
		}
	}

	void OnTriggerEnter2D (Collider2D coll)
	{

		if (coll.gameObject.layer == LayerMask.NameToLayer("powerup9avoid") && GameSave.gameSave.powerup7 == 2)
		{
			Player.GetComponent<pointSystem> ().previouslyEarnedPoints += 350;
		}

		if (coll.gameObject.tag == "harmfulobject" && coll.gameObject.name != "Area1" && coll.gameObject.name != "Area2" && coll.gameObject.name != "Area3" && coll.gameObject.name != "Area4")
		{
			health -= 1;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<Health>().canGetHurt)
		{
			//Makes this object the parent of the colliding "player" object
			collision.transform.parent = this.transform;
		}

		if (collision.gameObject.layer == LayerMask.NameToLayer("powerup9avoid"))
		{
			
		}

		if (collision.gameObject.tag == "harmfulobject"  && collision.gameObject.name != "Corner1" && collision.gameObject.name != "Corner2" && collision.gameObject.name != "Corner3" && collision.gameObject.name != "Corner4" && collision.gameObject.name != "Corner5" && collision.gameObject.name != "Corner6" && collision.gameObject.name != "Corner7" && collision.gameObject.name != "Corner8")
		{
			health -= 1;
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<Health>().canGetHurt)
		{
			collision.transform.parent = this.transform;

			if (GameSave.gameSave.powerup3 == 2) {

				collision.gameObject.GetComponent<pointSystem> ().accumulateGroundPoints = true;
			}
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.transform.parent = null;

			if (GameSave.gameSave.powerup3 == 2) {
				collision.gameObject.GetComponent<pointSystem> ().accumulateGroundPoints = false;
			}
		}
	}

	public IEnumerator Destroy ()
	{
		moveForward = false;
		if (!once) {
			hurt.Play ();
			once = true;
		}

		gameObject.GetComponent<MeshRenderer> ().enabled = false;
		gameObject.transform.GetChild (0).gameObject.SetActive (false);
		gameObject.transform.GetChild (1).gameObject.SetActive (false);
		gameObject.transform.GetChild (2).gameObject.SetActive (true);

		yield return new WaitForSeconds (1);
		Destroy (gameObject.transform.parent.gameObject);
	}
}