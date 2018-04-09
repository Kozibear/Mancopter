using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightCorrupterBomb : MonoBehaviour {

    public GameObject corruptedTerrain;

    private float recordTime;

    private GameObject[] enemyArray;

    private bool stopMoving;

    // Use this for initialization
    void Start () {
        recordTime = Time.time;

        stopMoving = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //we dont' want to collider with the enemy emitting the bombs!
        enemyArray = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject enemy in enemyArray)
        {
            Physics2D.IgnoreCollision(enemy.GetComponent<BoxCollider2D>(), this.GetComponent<BoxCollider2D>());
        }

        //we make the bomb move towards the destination point object by making it follow the parent's first child, the destination point object
        if(!stopMoving)
        {
			transform.position = Vector3.MoveTowards(this.transform.position, this.transform.parent.transform.GetChild(0).transform.position, 1.65f*Time.deltaTime);
        }
        

        //if we're thrown for too much time, we are just destroyed
        if (Time.time >= recordTime + 10f)
        {
            //we let our parent know, so that it can throw another thing
            this.transform.parent.GetComponent<StraightTerrainCorrupter>().canThrowBomb = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if we touch the player or the ground, we instantiate the explosion in our place

        if (collision.gameObject.tag == "corruptorTriggerArea")
        {
            stopMoving = true;
            GameObject terrain = Instantiate(corruptedTerrain, transform.position + new Vector3(0, -0.65f, 0), transform.rotation);
            //we make the corrupted terrain a child of the greater parent object, so that it too can easily communicate with its parent
            terrain.transform.parent = this.transform.parent;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            stopMoving = true;

            //we let our parent know, so that it can throw another bomb
            this.transform.parent.GetComponent<StraightTerrainCorrupter>().canThrowBomb = true;

            Destroy(gameObject);
        }

    }
}
