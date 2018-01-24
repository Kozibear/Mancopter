using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveData : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when the player goes over our position, we save the current position
        if(collision.tag == "Player")
        {
            PlayerPrefs.SetInt("playerAtCheckpoint", 1);
            PlayerPrefs.SetFloat("playerSavedPositionX", this.transform.position.x);
            PlayerPrefs.SetFloat("playerSavedPositionY", this.transform.position.y);
            PlayerPrefs.Save();
        }
    }
}
