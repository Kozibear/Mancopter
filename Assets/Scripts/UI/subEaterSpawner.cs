using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class subEaterSpawner : MonoBehaviour {

	public GameObject buttonEater;

	public GameObject Player;

	public Button thisButton;

	public float thisSpawnerNumber;

	public float randomNumber;

	public float minRandomNumber;
	public float maxRandomNumber;

	// Use this for initialization
	void Start () {
		minRandomNumber = 1;
		maxRandomNumber = 3;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (gameTimer.gameTime < 100) {
			maxRandomNumber = 3; //3
		}
			
		if (gameTimer.gameTime >= 100 && gameTimer.gameTime < 200) {
			maxRandomNumber = 4;
		}

		if (gameTimer.gameTime >= 200) {
			maxRandomNumber = 5;
		}
	}

	public void spawnEater () {
		
		if (thisSpawnerNumber == 1) {
			
			GameObject ButtonEater = Instantiate (buttonEater, transform.position, transform.rotation);
			ButtonEater.transform.parent = this.transform.parent;
			ButtonEater.transform.position = this.transform.position;

			ButtonEater.gameObject.GetComponent<buttonEaters> ().player = Player;
			ButtonEater.gameObject.GetComponent<buttonEaters> ().rotationButton1 = thisButton;
			ButtonEater.gameObject.GetComponent<buttonEaters> ().button1 = true;

			randomNumber = Mathf.Floor( Random.Range (minRandomNumber, maxRandomNumber));
			if (randomNumber == 1) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 1;
			}
			else if (randomNumber == 2) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 2;
			}
			else if (randomNumber == 3) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 3;
			}
			else if (randomNumber == 4) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 4;
			}
		}

		else if (thisSpawnerNumber == 2) {
			
			GameObject ButtonEater = Instantiate (buttonEater, transform.position, transform.rotation);
			ButtonEater.transform.parent = this.transform.parent;
			ButtonEater.transform.position = this.transform.position;

			ButtonEater.gameObject.GetComponent<buttonEaters> ().player = Player;
			ButtonEater.gameObject.GetComponent<buttonEaters> ().rotationButton2 = thisButton;
			ButtonEater.gameObject.GetComponent<buttonEaters> ().button2 = true; 

			randomNumber = Mathf.Floor( Random.Range (minRandomNumber, maxRandomNumber));
			if (randomNumber == 1) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 1;
			}
			else if (randomNumber == 2) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 2;
			}
			else if (randomNumber == 3) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 3;
			}
			else if (randomNumber == 4) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 4;
			}
		}

		else if (thisSpawnerNumber == 3) {
			
			GameObject ButtonEater = Instantiate (buttonEater, transform.position, transform.rotation);
			ButtonEater.transform.parent = this.transform.parent;
			ButtonEater.transform.position = this.transform.position;

			ButtonEater.gameObject.GetComponent<buttonEaters> ().player = Player;
			ButtonEater.gameObject.GetComponent<buttonEaters> ().rotationButton3 = thisButton;
			ButtonEater.gameObject.GetComponent<buttonEaters> ().button3 = true;

			randomNumber = Mathf.Floor( Random.Range (minRandomNumber, maxRandomNumber));
			if (randomNumber == 1) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 1;
			}
			else if (randomNumber == 2) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 2;
			}
			else if (randomNumber == 3) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 3;
			}
			else if (randomNumber == 4) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 4;
			}
		}

		else if (thisSpawnerNumber == 4) {
			
			GameObject ButtonEater = Instantiate (buttonEater, transform.position, transform.rotation);
			ButtonEater.transform.parent = this.transform.parent;
			ButtonEater.transform.position = this.transform.position;

			ButtonEater.gameObject.GetComponent<buttonEaters> ().player = Player;
			ButtonEater.gameObject.GetComponent<buttonEaters> ().rotationButton4 = thisButton;
			ButtonEater.gameObject.GetComponent<buttonEaters> ().button4 = true;

			randomNumber = Mathf.Floor( Random.Range (minRandomNumber, maxRandomNumber));
			if (randomNumber == 1) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 1;
			}
			else if (randomNumber == 2) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 2;
			}
			else if (randomNumber == 3) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 3;
			}
			else if (randomNumber == 4) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 4;
			}
		}

		else if (thisSpawnerNumber == 5) {
			
			GameObject ButtonEater = Instantiate (buttonEater, transform.position, transform.rotation);
			ButtonEater.transform.parent = this.transform.parent;
			ButtonEater.transform.position = this.transform.position;

			ButtonEater.gameObject.GetComponent<buttonEaters> ().player = Player;
			ButtonEater.gameObject.GetComponent<buttonEaters> ().rotationButton5 = thisButton;
			ButtonEater.gameObject.GetComponent<buttonEaters> ().button5 = true;

			randomNumber = Mathf.Floor( Random.Range (minRandomNumber, maxRandomNumber));
			if (randomNumber == 1) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 1;
			}
			else if (randomNumber == 2) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 2;
			}
			else if (randomNumber == 3) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 3;
			}
			else if (randomNumber == 4) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 4;
			}
		}

		else if (thisSpawnerNumber == 6) {
			
			GameObject ButtonEater = Instantiate (buttonEater, transform.position, transform.rotation);
			ButtonEater.transform.parent = this.transform.parent;
			ButtonEater.transform.position = this.transform.position;

			ButtonEater.gameObject.GetComponent<buttonEaters> ().player = Player;
			ButtonEater.gameObject.GetComponent<buttonEaters> ().rotationButton6 = thisButton;
			ButtonEater.gameObject.GetComponent<buttonEaters> ().button6 = true;

			randomNumber = Mathf.Floor( Random.Range (minRandomNumber, maxRandomNumber));
			if (randomNumber == 1) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 1;
			}
			else if (randomNumber == 2) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 2;
			}
			else if (randomNumber == 3) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 3;
			}
			else if (randomNumber == 4) {
				ButtonEater.gameObject.GetComponent<buttonEaters> ().health = 4;
			}
		}
	}
}
