using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptedTerrainStraight : MonoBehaviour {

    private float recordTime;
	public bool moveOnce;

	public AudioSource explodeBomb;

    // Use this for initialization
    void Start () {
        recordTime = Time.time;
		moveOnce = true;
		GameSave.gameSave.Load ();

		explodeBomb.Play ();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (GameSave.gameSave.powerup13 != 2) {
			
			if (Time.time >= recordTime + 6f) {
				this.transform.parent.GetComponent<StraightTerrainCorrupter> ().canThrowBomb = true;
				Destroy (gameObject);
			}
		} 
		else {
			
			if (Time.time >= recordTime + 0.5f) {
				this.transform.parent.GetComponent<StraightTerrainCorrupter> ().canThrowBomb = true;
				Destroy (gameObject);
			}
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		/*
		//upon collision with a ground object
		if (collision.gameObject.tag == "ground" && moveOnce) {
			//if the y value of this object is not equal to the ground's y location + half of the ground's height, we make it this value
			if (this.transform.position.y != collision.transform.position.y + (collision.transform.localScale.y / 2)) 
			{
				this.transform.position = new Vector3(this.transform.position.x, (collision.transform.position.y + collision.transform.localScale.y / 2), this.transform.position.z);
			}

			moveOnce = false;
		}
		*/
	}
}
