using System.Collections;
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

	public float health = 1;

	// Use this for initialization
	void Start () {

		//we create an array of all our objects with the ground tag (less intensive on unity, and less time-consuming, than individually listing the names of all objects)
		groundArray = GameObject.FindGameObjectsWithTag("ground");

		//for each individual blade object in our bladeArray, we ignore its box collider
		foreach (GameObject ground in groundArray)
		{
			Physics2D.IgnoreCollision(ground.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
		}
			

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


		pufferFish.transform.position = Vector3.MoveTowards(pufferFish.transform.position, endingPoint.transform.position, movementSpeed);

		if (pufferFish.transform.position == endingPoint.transform.position) {
			Destroy (transform.parent.gameObject);
		}

		if (health <= 0) {
			Destroy (transform.parent.gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			//Makes this object the parent of the colliding "player" object
			collision.transform.parent = this.transform;
		}

		if (collision.gameObject.tag == "harmfulobject")
		{
			health -= 1;
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.transform.parent = this.transform;
		}

		if (collision.gameObject.tag == "harmfulobject")
		{
			health -= 1;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.transform.parent = null;
		}
	}
}
