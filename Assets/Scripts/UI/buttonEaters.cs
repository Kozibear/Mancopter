using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonEaters : MonoBehaviour {

	public Button buttonEater;

	public Button rotationButton1;
	public Button rotationButton2;
	public Button rotationButton3;
	public Button rotationButton4;
	public Button rotationButton5;
	public Button rotationButton6;

	public bool button1;
	public bool button2;
	public bool button3;
	public bool button4;
	public bool button5;
	public bool button6;

	public AudioSource munching;
	public AudioSource hurt;
	public AudioSource cantDamage;

	public float movementSpeed;

	public float health;

	public bool continueMovingForward;
	public bool notDying;
	public bool canSummonCrumb;
	public bool startEating;

	public GameObject crumb;

	public GameObject player;

	public float waitUntilNextClick;

	public float powerupDieTime;

	// Use this for initialization
	void Start () {
		buttonEater.onClick.AddListener (reduceHealth);
		continueMovingForward = true;
		notDying = true;
		canSummonCrumb = true;
		startEating = true;

		powerupDieTime = Time.time + 7.5f;

		GameSave.gameSave.Load ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (GameSave.gameSave.powerup15 == 2 && Time.time >= powerupDieTime) {
			health = 0;
		}

		if (continueMovingForward && notDying) {
			if (button1 && rotationButton1 != null) {
				this.transform.position = Vector3.MoveTowards (this.transform.position, rotationButton1.transform.position, Time.deltaTime * movementSpeed);
				transform.right = rotationButton1.transform.position - transform.position;
			}

			if (button1 && rotationButton1 == null) {
				health = 0;
			}

			if (button2 && rotationButton2 != null) {
				this.transform.position = Vector3.MoveTowards (this.transform.position, rotationButton2.transform.position, Time.deltaTime * movementSpeed);
				transform.right = rotationButton2.transform.position - transform.position;
			}

			if (button2 && rotationButton2 == null) {
				health = 0;
			}

			if (button3 && rotationButton3 != null) {
				this.transform.position = Vector3.MoveTowards (this.transform.position, rotationButton3.transform.position, Time.deltaTime * movementSpeed);
				transform.right = rotationButton3.transform.position - transform.position;
			}

			if (button3 && rotationButton3 == null) {
				health = 0;
			}

			if (button4 && rotationButton4 != null) {
				this.transform.position = Vector3.MoveTowards (this.transform.position, rotationButton4.transform.position, Time.deltaTime * movementSpeed);
				transform.right = rotationButton4.transform.position - transform.position;
			}

			if (button4 && rotationButton4 == null) {
				health = 0;
			}

			if (button5 && rotationButton5 != null) {
				this.transform.position = Vector3.MoveTowards (this.transform.position, rotationButton5.transform.position, Time.deltaTime * movementSpeed);
				transform.right = rotationButton5.transform.position - transform.position;
			}

			if (button5 && rotationButton5 == null) {
				health = 0;
			}

			if (button6 && rotationButton6 != null) {
				this.transform.position = Vector3.MoveTowards (this.transform.position, rotationButton6.transform.position, Time.deltaTime * movementSpeed);
				transform.right = rotationButton6.transform.position - transform.position;
			}

			if (button6 && rotationButton6 == null) {
				health = 0;
			}
		}

		if (button1 && rotationButton1 == null) {
			health = 0;
		}

		if (button2 && rotationButton2 == null) {
			health = 0;
		}

		if (button3 && rotationButton3 == null) {
			health = 0;
		}

		if (button4 && rotationButton4 == null) {
			health = 0;
		}

		if (button5 && rotationButton5 == null) {
			health = 0;
		}

		if (button6 && rotationButton6 == null) {
			health = 0;
		}

		if (!startEating && notDying && canSummonCrumb) {
			StartCoroutine ("EatButton");
			canSummonCrumb = false;
		}

		if (health == 4) {
			transform.localScale = new Vector3 (1.8f, 1.8f, 1.8f);
		}
		else if (health == 3) {
			transform.localScale = new Vector3 (1.5f, 1.5f, 1.5f);
		}
		else if (health == 2) {
			transform.localScale = new Vector3 (1.1f, 1.1f, 1.1f);
		}
		else if (health == 1) {
			transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
		}
		else if (health == 0) {
			notDying = false;
			StartCoroutine ("Destroy");
		}
	}

	void reduceHealth () {
		if (GameSave.gameSave.powerup4 == 2 && Time.time >= waitUntilNextClick) {
			if (player.GetComponent<pointSystem> ().totalPoints >= 15) {
				player.GetComponent<pointSystem> ().previouslyEarnedPoints -= 15;
				health--;
				hurt.Play ();
				waitUntilNextClick = Time.time + 2;
			} else {
				cantDamage.Play ();
			}
		}

		if (GameSave.gameSave.powerup4 == 2 && Time.time < waitUntilNextClick) {
			cantDamage.Play ();
		}

		if (GameSave.gameSave.powerup4 != 2) {
			if (player.GetComponent<pointSystem> ().totalPoints >= 30) {
				player.GetComponent<pointSystem> ().previouslyEarnedPoints -= 30;
				health--;
				hurt.Play ();
			} else {
				cantDamage.Play ();
			}
		}
	}

	public IEnumerator EatButton ()
	{
		GameObject fallingCrumb1 = Instantiate (crumb, this.transform.localPosition, crumb.transform.rotation);
		fallingCrumb1.transform.parent = this.transform.parent;
		fallingCrumb1.transform.position = this.transform.position;
		fallingCrumb1.GetComponent<Rigidbody2D> ().AddForce (Vector3.up * 1000);
		fallingCrumb1.GetComponent<Rigidbody2D> ().AddForce (Vector3.right * 1500);
		fallingCrumb1.GetComponent<Rigidbody2D> ().gravityScale *= 9;

		GameObject fallingCrumb2 = Instantiate (crumb, this.transform.localPosition, crumb.transform.rotation);
		fallingCrumb2.transform.parent = this.transform.parent;
		fallingCrumb2.transform.position = this.transform.position;
		fallingCrumb2.GetComponent<Rigidbody2D> ().AddForce (Vector3.up * 1000);
		fallingCrumb2.GetComponent<Rigidbody2D> ().AddForce (-Vector3.right * 1500);
		fallingCrumb2.GetComponent<Rigidbody2D> ().gravityScale *= 9;

		munching.Play ();

		yield return new WaitForSeconds (1f);

		canSummonCrumb = true;

		yield return null;
	}

	public IEnumerator Destroy ()
	{
		if (button1 && rotationButton1 != null) {
			rotationButton1.GetComponent<shrinkingRotationButton> ().takeFromReduction ();
		}
		if (button2 && rotationButton2 != null) {
			rotationButton2.GetComponent<shrinkingRotationButton> ().takeFromReduction ();
		}
		if (button3 && rotationButton3 != null) {
			rotationButton3.GetComponent<shrinkingRotationButton> ().takeFromReduction ();
		}
		if (button4 && rotationButton4 != null) {
			rotationButton4.GetComponent<shrinkingRotationButton> ().takeFromReduction ();
		}
		if (button5 && rotationButton5 != null) {
			rotationButton5.GetComponent<shrinkingRotationButton> ().takeFromReduction ();
		}
		if (button6 && rotationButton6 != null) {
			rotationButton6.GetComponent<shrinkingRotationButton> ().takeFromReduction ();
		}
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
	}
		
	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.name == "XAxisUp" && button1) {
			continueMovingForward = false;
			if (startEating) {
				rotationButton1.GetComponent<shrinkingRotationButton> ().addToReduction ();
				startEating = false;
			}
		}

		if (coll.gameObject.name == "YAxisRight" && button2) {
			continueMovingForward = false;
			if (startEating) {
				rotationButton2.GetComponent<shrinkingRotationButton> ().addToReduction ();
				startEating = false;
			}
		}

		if (coll.gameObject.name == "YAxisLeft" && button3) {
			continueMovingForward = false;
			if (startEating) {
				rotationButton3.GetComponent<shrinkingRotationButton> ().addToReduction ();
				startEating = false;
			}
		}

		if (coll.gameObject.name == "ZAxisCounterClockwise" && button4) {
			continueMovingForward = false;
			if (startEating) {
				rotationButton4.GetComponent<shrinkingRotationButton> ().addToReduction ();
				startEating = false;
			}
		}

		if (coll.gameObject.name == "ZAxisClockwise" && button5) {
			continueMovingForward = false;
			if (startEating) {
				rotationButton5.GetComponent<shrinkingRotationButton> ().addToReduction ();
				startEating = false;
			}
		}

		if (coll.gameObject.name == "XAxisDown" && button6) {
			continueMovingForward = false;
			if (startEating) {
				rotationButton6.GetComponent<shrinkingRotationButton> ().addToReduction ();
				startEating = false;
			}
		}
	}

	void OnTriggerStay2D (Collider2D coll) {
		if (coll.gameObject == rotationButton1 && button1) {
			continueMovingForward = false;
		}

		if (coll.gameObject == rotationButton2 && button2) {
			continueMovingForward = false;
		}

		if (coll.gameObject == rotationButton3 && button3) {
			continueMovingForward = false;
		}

		if (coll.gameObject == rotationButton4 && button4) {
			continueMovingForward = false;
		}

		if (coll.gameObject == rotationButton5 && button5) {
			continueMovingForward = false;
		}

		if (coll.gameObject == rotationButton6 && button6) {
			continueMovingForward = false;
		}
	}

	void OnTriggerExit2D (Collider2D coll) {
		if (coll.gameObject.tag == "rotationButton") {
			continueMovingForward = true;
		}
	}
}
