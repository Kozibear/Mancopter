using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrupterBomb : MonoBehaviour {

    public float directionForceX;
    public float directionForceY;

    public Rigidbody2D rb2d;

    public GameObject corruptedTerrain;

    private GameObject[] enemyArray;

    private float recordTime;

	// Use this for initialization
	void Start () {
        Vector3 newPush = new Vector3(directionForceX, directionForceY, 0);
        rb2d.AddForce(newPush);

        recordTime = Time.time;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //we dont' want to collider with the enemy emitting the bombs!
        enemyArray = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject enemy in enemyArray)
        {
            Physics2D.IgnoreCollision(enemy.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        }

        //if we're thrown for too much time, we are just destroyed
        if (Time.time >= recordTime + 10f)
        {
            //we let our parent know, so that it can throw another thing
            this.transform.parent.GetComponent<ParabolicTerrainCorrupter>().canThrowBomb = true;
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if we touch the player or the ground, we instantiate the explosion in our place

		if (collision.gameObject.tag == "corruptorTriggerArea")
		{
            GameObject terrain = Instantiate(corruptedTerrain, transform.position + new Vector3(0, -0.45f, 0), transform.rotation);
            //we make the corrupted terrain a child of the greater parent object, so that it too can easily communicate with its parent
            terrain.transform.parent = this.transform.parent;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            //we let our parent know, so that it can throw another thing
            this.transform.parent.GetComponent<ParabolicTerrainCorrupter> ().canThrowBomb = true;

            Destroy(gameObject);
        }

    }
}
