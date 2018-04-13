using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsRotationsController : MonoBehaviour {

	public Button XAxisUp;
	public Button XAxisDown;
	public Button YAxisLeft;
	public Button YAxisRight;
	public Button ZAxisClockwise;
	public Button ZAxisCounterClockwise;

	public bool rotateUpBool;
	public bool rotateDownBool;
	public bool rotateLeftBool;
	public bool rotateRightBool;
	public bool rotateClockwiseBool;
	public bool rotateCounterClockwiseBool;

	public bool canRotate;

	public GameObject PlayCube;

	public Quaternion targetRotation;

	public GameObject CubeParent;

	public GameObject player;
	public GameObject rotor1;
	public GameObject rotor2;
	public GameObject rotor3;
	public GameObject rotor4;

	public GameObject UpWallCheck;
	public GameObject DownWallCheck;
	public GameObject LeftWallCheck;
	public GameObject RightWallCheck;

	public static bool Make1Invisible;
	public static bool Make2Invisible;
	public static bool Make3Invisible;
	public static bool Make4Invisible;
	public static bool Make5Invisible;
	public static bool Make6Invisible;

	public Vector2 playerStoredVelocity;

	public static bool playSpaceRotating;

	public AudioSource cantRotate;

	public Color redColor;
	public Color normalColor;
	public Color buttonColor;

	// Use this for initialization
	void Start () {
		XAxisUp.onClick.AddListener (rotateUp);
		XAxisDown.onClick.AddListener (rotateDown);
		YAxisLeft.onClick.AddListener (rotateLeft);
		YAxisRight.onClick.AddListener (rotateRight);
		ZAxisClockwise.onClick.AddListener (rotateClockwise);
		ZAxisCounterClockwise.onClick.AddListener (rotateCounterClockwise);

		targetRotation = PlayCube.transform.rotation;

		Make1Invisible = true;
		Make2Invisible = false;
		Make3Invisible = false;
		Make4Invisible = false;
		Make5Invisible = false;
		Make6Invisible = false;

		playSpaceRotating = false;

		redColor = new Color (1, 0, 0, 1);
		normalColor = new Color (1, 1, 1, 1);

		buttonColor = normalColor;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<CopterBasicMovements> ().touchingObject || player.GetComponent<CopterBasicMovements> ().insideObject) {
			canRotate = false;
		} 
		else {
			canRotate = true;
		}

		if (rotateUpBool) {
			CubeParent.transform.localRotation = Quaternion.RotateTowards(CubeParent.transform.rotation, targetRotation, 4f);
			//player.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor1.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor2.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor3.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor4.GetComponent<Rigidbody2D> ().isKinematic = true;
			//player.GetComponent<CopterBasicMovements> ().rb2d.velocity = Vector3.zero;
			player.GetComponent<CopterBasicMovements> ().playSpaceRotating = true;
			playSpaceRotating = true;
		}
			
		if (rotateDownBool) {
			CubeParent.transform.rotation = Quaternion.RotateTowards(CubeParent.transform.rotation, targetRotation, 4f);
			//player.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor1.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor2.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor3.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor4.GetComponent<Rigidbody2D> ().isKinematic = true;
			//player.GetComponent<CopterBasicMovements> ().rb2d.velocity = Vector3.zero;
			player.GetComponent<CopterBasicMovements> ().playSpaceRotating = true;
			playSpaceRotating = true;
		}

		if (rotateLeftBool) {
			CubeParent.transform.rotation = Quaternion.RotateTowards(CubeParent.transform.rotation, targetRotation, 4f);
			//player.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor1.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor2.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor3.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor4.GetComponent<Rigidbody2D> ().isKinematic = true;
			//player.GetComponent<CopterBasicMovements> ().rb2d.velocity = Vector3.zero;
			player.GetComponent<CopterBasicMovements> ().playSpaceRotating = true;
			playSpaceRotating = true;
		}

		if (rotateRightBool) {
			CubeParent.transform.rotation = Quaternion.RotateTowards(CubeParent.transform.rotation, targetRotation, 4f);
			//player.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor1.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor2.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor3.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor4.GetComponent<Rigidbody2D> ().isKinematic = true;
			//player.GetComponent<CopterBasicMovements> ().rb2d.velocity = Vector3.zero;
			player.GetComponent<CopterBasicMovements> ().playSpaceRotating = true;
			playSpaceRotating = true;
		}

		if (rotateClockwiseBool) {
			CubeParent.transform.rotation = Quaternion.RotateTowards(CubeParent.transform.rotation, targetRotation, 4f);
			//player.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor1.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor2.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor3.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor4.GetComponent<Rigidbody2D> ().isKinematic = true;
			//player.GetComponent<CopterBasicMovements> ().rb2d.velocity = Vector3.zero;
			player.GetComponent<CopterBasicMovements> ().playSpaceRotating = true;
			playSpaceRotating = true;
		}

		if (rotateCounterClockwiseBool) {
			CubeParent.transform.rotation = Quaternion.RotateTowards(CubeParent.transform.rotation, targetRotation, 4f);
			//player.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor1.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor2.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor3.GetComponent<Rigidbody2D> ().isKinematic = true;
			//rotor4.GetComponent<Rigidbody2D> ().isKinematic = true;
			//player.GetComponent<CopterBasicMovements> ().rb2d.velocity = Vector3.zero;
			player.GetComponent<CopterBasicMovements> ().playSpaceRotating = true;
			playSpaceRotating = true;
		}

		if (CubeParent.transform.rotation == targetRotation) {

			if (PlayCube.transform.parent != null) {
				//player.GetComponent<CopterBasicMovements> ().rb2d.velocity = playerStoredVelocity;
			}

			PlayCube.transform.parent = null; //we unparent the parent cube object
			CubeParent.transform.rotation = Quaternion.Euler(0, 0, 0);

			//player.GetComponent<Rigidbody2D> ().isKinematic = false;
			//rotor1.GetComponent<Rigidbody2D> ().isKinematic = false;
			//rotor2.GetComponent<Rigidbody2D> ().isKinematic = false;
			//rotor3.GetComponent<Rigidbody2D> ().isKinematic = false;
			//rotor4.GetComponent<Rigidbody2D> ().isKinematic = false;
			player.GetComponent<CopterBasicMovements> ().playSpaceRotating = false;

			rotateUpBool = false;
			rotateDownBool = false;
			rotateLeftBool = false;
			rotateRightBool = false;
			rotateClockwiseBool = false;
			rotateCounterClockwiseBool = false;

			playSpaceRotating = false;
		}

		XAxisUp.GetComponent<Image> ().color = buttonColor;
		XAxisDown.GetComponent<Image> ().color = buttonColor;
		YAxisLeft.GetComponent<Image> ().color = buttonColor;
		YAxisRight.GetComponent<Image> ().color = buttonColor;
		ZAxisClockwise.GetComponent<Image> ().color = buttonColor;
		ZAxisCounterClockwise.GetComponent<Image> ().color = buttonColor;

		if (canRotate && !rotateUpBool && !rotateDownBool && !rotateLeftBool && !rotateRightBool && !rotateClockwiseBool && !rotateCounterClockwiseBool) {
			buttonColor = normalColor;

		} 
		else {
			buttonColor = redColor;
		}
	}

	void rotateUp () {
		if (canRotate && !rotateUpBool && !rotateDownBool && !rotateLeftBool && !rotateRightBool && !rotateClockwiseBool && !rotateCounterClockwiseBool) {

			//We make this wall start to become invisible
			makeInvisible (UpWallCheck);

			PlayCube.transform.parent = CubeParent.transform;

			targetRotation = CubeParent.transform.rotation * Quaternion.Euler (-90, 0, 0);

			playerStoredVelocity = player.GetComponent<CopterBasicMovements> ().rb2d.velocity;

			rotateUpBool = true;

			buttonColor = normalColor;
		} else {
			cantRotate.Play ();
			buttonColor = redColor;
		}
	}

	void rotateDown () {
		if (canRotate && !rotateUpBool && !rotateDownBool && !rotateLeftBool && !rotateRightBool && !rotateClockwiseBool && !rotateCounterClockwiseBool) {

			makeInvisible(DownWallCheck);

			PlayCube.transform.parent = CubeParent.transform;

			targetRotation = CubeParent.transform.rotation * Quaternion.Euler (90, 0, 0);

			playerStoredVelocity = player.GetComponent<CopterBasicMovements> ().rb2d.velocity;

			rotateDownBool = true;

			buttonColor = normalColor;
		} else {
			cantRotate.Play ();
			buttonColor = redColor;
		}
	}

	void rotateLeft () {
		if (canRotate && !rotateUpBool && !rotateDownBool && !rotateLeftBool && !rotateRightBool && !rotateClockwiseBool && !rotateCounterClockwiseBool) {

			makeInvisible(LeftWallCheck);

			PlayCube.transform.parent = CubeParent.transform;

			targetRotation = CubeParent.transform.rotation * Quaternion.Euler (0, -90, 0);

			playerStoredVelocity = player.GetComponent<CopterBasicMovements> ().rb2d.velocity;

			rotateLeftBool = true;

			buttonColor = normalColor;
		} else {
			cantRotate.Play ();
			buttonColor = redColor;
		}
	}

	void rotateRight () {
		if (canRotate && !rotateUpBool && !rotateDownBool && !rotateLeftBool && !rotateRightBool && !rotateClockwiseBool && !rotateCounterClockwiseBool) {

			makeInvisible(RightWallCheck);

			PlayCube.transform.parent = CubeParent.transform;

			targetRotation = CubeParent.transform.rotation * Quaternion.Euler (0, 90, 0);

			playerStoredVelocity = player.GetComponent<CopterBasicMovements> ().rb2d.velocity;

			rotateRightBool = true;

			buttonColor = normalColor;
		} else {
			cantRotate.Play ();
			buttonColor = redColor;
		}
	}

	void rotateClockwise () {
		if (canRotate && !rotateUpBool && !rotateDownBool && !rotateLeftBool && !rotateRightBool && !rotateClockwiseBool && !rotateCounterClockwiseBool) {

			PlayCube.transform.parent = CubeParent.transform;

			targetRotation = CubeParent.transform.rotation * Quaternion.Euler (0, 0, 90);

			playerStoredVelocity = player.GetComponent<CopterBasicMovements> ().rb2d.velocity;

			rotateClockwiseBool = true;

			buttonColor = normalColor;
		} else {
			cantRotate.Play ();
			buttonColor = redColor;
		}
	}

	void rotateCounterClockwise () {
		if (canRotate && !rotateUpBool && !rotateDownBool && !rotateLeftBool && !rotateRightBool && !rotateClockwiseBool && !rotateCounterClockwiseBool) {

			PlayCube.transform.parent = CubeParent.transform;

			targetRotation = CubeParent.transform.rotation * Quaternion.Euler (0, 0, -90);

			playerStoredVelocity = player.GetComponent<CopterBasicMovements> ().rb2d.velocity;

			rotateCounterClockwiseBool = true;

			buttonColor = normalColor;
		} else {
			cantRotate.Play ();
			buttonColor = redColor;
		}
	}

	void makeInvisible(GameObject wallCheck) {
		if (wallCheck.GetComponent<SideVisibilityChecker> ().currentWallNumber == 1) {

			Make1Invisible = true;
			Make2Invisible = false;
			Make3Invisible = false;
			Make4Invisible = false;
			Make5Invisible = false;
			Make6Invisible = false;
		}
		else if (wallCheck.GetComponent<SideVisibilityChecker> ().currentWallNumber == 2) {

			Make1Invisible = false;
			Make2Invisible = true;
			Make3Invisible = false;
			Make4Invisible = false;
			Make5Invisible = false;
			Make6Invisible = false;

		}
		else if (wallCheck.GetComponent<SideVisibilityChecker> ().currentWallNumber == 3) {

			Make1Invisible = false;
			Make2Invisible = false;
			Make3Invisible = true;
			Make4Invisible = false;
			Make5Invisible = false;
			Make6Invisible = false;

		}
		else if (wallCheck.GetComponent<SideVisibilityChecker> ().currentWallNumber == 4) {

			Make1Invisible = false;
			Make2Invisible = false;
			Make3Invisible = false;
			Make4Invisible = true;
			Make5Invisible = false;
			Make6Invisible = false;

		}
		else if (wallCheck.GetComponent<SideVisibilityChecker> ().currentWallNumber == 5) {

			Make1Invisible = false;
			Make2Invisible = false;
			Make3Invisible = false;
			Make4Invisible = false;
			Make5Invisible = true;
			Make6Invisible = false;

		}
		else if (wallCheck.GetComponent<SideVisibilityChecker> ().currentWallNumber == 6) {

			Make1Invisible = false;
			Make2Invisible = false;
			Make3Invisible = false;
			Make4Invisible = false;
			Make5Invisible = false;
			Make6Invisible = true;

		}
	}
}
