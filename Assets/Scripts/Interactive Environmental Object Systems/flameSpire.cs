using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameSpire : MonoBehaviour {

	public GameObject pillar;

	public GameObject grandparent;

	public bool bringTheFire;
	public bool onlyOnce1;
	public bool onlyOnce2;

	public float recordTime;
	public float recordTime2;

	// Use this for initialization
	void Start () {
		bringTheFire = false;
		onlyOnce1 = true;
		onlyOnce2 = true;
		recordTime = Time.time;
		recordTime2 = Time.time + 20f;

		grandparent = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//if we step on the block, then we begin recording the time...
		if (bringTheFire == true && onlyOnce1 == true) {
			recordTime2 = Time.time;

			bringTheFire = false;
			onlyOnce1 = false; //so that we don't delay the fire pillar's appearance/make two appear after each other
		}

		//and after about a second, we instantiate the fire pillar (enough above the controller object so that it goes from the bottom to the top of the screen
		if (Time.time >= recordTime2 + 1 && onlyOnce2) {
			GameObject Pillar = Instantiate (pillar, transform.position + new Vector3 (0, 5f, 0), transform.rotation);
			Pillar.transform.parent = grandparent.transform; //we make the fire pillar a child of the block
			onlyOnce2 = false;
		}

			
		//else, if the player never lands in this platform before it dops back in lava, we make it dissapear
		if (Time.time >= recordTime + 6) {

			Destroy(gameObject);
		}

	}

	//the moment the player comes into contact with the pillar, we are allowed to instantiate the flame

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
		if (collision.gameObject.tag == "Player") {
			bringTheFire = true;
		}

	}

}