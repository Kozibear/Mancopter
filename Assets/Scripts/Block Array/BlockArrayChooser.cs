using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockArrayChooser : MonoBehaviour {

	public GameObject blockArray1;
	public GameObject blockArray2;
	public GameObject blockArray3;
	public GameObject blockArray4;
	public GameObject blockArray5;
	public GameObject blockArray6;
	public GameObject blockArray7;
	public GameObject blockArray8;
	public GameObject blockArray9;
	public GameObject blockArray10;
	public GameObject blockArray11;
	public GameObject blockArray12;

	public GameObject lava1;
	public GameObject lava2;
	public GameObject lava3;
	public GameObject lava4;
	public GameObject lava5;
	public GameObject lava6;

	public float blockArraySelection;

	public bool changeNumber;

	// Use this for initialization
	void Start () {

		blockArraySelection = 1;
		blockArray1.GetComponent<BlockArrayControl> ().thisArray = true;

		changeNumber = false;
	}
	
	public void ChooseNextArray() {
		blockArray1.GetComponent<BlockArrayControl> ().thisArray = false;
		blockArray2.GetComponent<BlockArrayControl> ().thisArray = false;
		blockArray3.GetComponent<BlockArrayControl> ().thisArray = false;
		blockArray4.GetComponent<BlockArrayControl> ().thisArray = false;
		blockArray5.GetComponent<BlockArrayControl> ().thisArray = false;
		blockArray6.GetComponent<BlockArrayControl> ().thisArray = false;
		blockArray7.GetComponent<BlockArrayControl> ().thisArray = false;
		blockArray8.GetComponent<BlockArrayControl> ().thisArray = false;
		blockArray9.GetComponent<BlockArrayControl> ().thisArray = false;
		blockArray10.GetComponent<BlockArrayControl> ().thisArray = false;
		blockArray11.GetComponent<BlockArrayControl> ().thisArray = false;
		blockArray12.GetComponent<BlockArrayControl> ().thisArray = false;

		blockArraySelection = Random.Range (1, 13);

		if (blockArraySelection == 7 || blockArraySelection == 11) {
			lava1.GetComponent<lava> ().StartCoroutine ("Flashing");
		}
		else if (blockArraySelection == 4 || blockArraySelection == 9) {
			lava2.GetComponent<lava> ().StartCoroutine ("Flashing");
		}
		else if (blockArraySelection == 3 || blockArraySelection == 8) {
			lava3.GetComponent<lava> ().StartCoroutine ("Flashing");
		}
		else if (blockArraySelection == 2 || blockArraySelection == 5) {
			lava4.GetComponent<lava> ().StartCoroutine ("Flashing");
		}
		else if (blockArraySelection == 1 || blockArraySelection == 12) {
			lava5.GetComponent<lava> ().StartCoroutine ("Flashing");
		}
		else if (blockArraySelection == 6 || blockArraySelection == 10) {
			lava6.GetComponent<lava> ().StartCoroutine ("Flashing");
		}

		blockArray1.GetComponent<BlockArrayControl> ().canCheckArraySelection = true;
		blockArray2.GetComponent<BlockArrayControl> ().canCheckArraySelection = true;
		blockArray3.GetComponent<BlockArrayControl> ().canCheckArraySelection = true;
		blockArray4.GetComponent<BlockArrayControl> ().canCheckArraySelection = true;
		blockArray5.GetComponent<BlockArrayControl> ().canCheckArraySelection = true;
		blockArray6.GetComponent<BlockArrayControl> ().canCheckArraySelection = true;
		blockArray7.GetComponent<BlockArrayControl> ().canCheckArraySelection = true;
		blockArray8.GetComponent<BlockArrayControl> ().canCheckArraySelection = true;
		blockArray9.GetComponent<BlockArrayControl> ().canCheckArraySelection = true;
		blockArray10.GetComponent<BlockArrayControl> ().canCheckArraySelection = true;
		blockArray11.GetComponent<BlockArrayControl> ().canCheckArraySelection = true;
		blockArray12.GetComponent<BlockArrayControl> ().canCheckArraySelection = true;

		if (blockArraySelection == 1) {
			blockArray1.GetComponent<BlockArrayControl> ().thisArray = true;
		}

		else if (blockArraySelection == 2) {
			blockArray2.GetComponent<BlockArrayControl> ().thisArray = true;
		}

		else if (blockArraySelection == 3) {
			blockArray3.GetComponent<BlockArrayControl> ().thisArray = true;
		}

		else if (blockArraySelection == 4) {
			blockArray4.GetComponent<BlockArrayControl> ().thisArray = true;
		}

		else if (blockArraySelection == 5) {
			blockArray5.GetComponent<BlockArrayControl> ().thisArray = true;
		}

		else if (blockArraySelection == 6) {
			blockArray6.GetComponent<BlockArrayControl> ().thisArray = true;
		}

		else if (blockArraySelection == 7) {
			blockArray7.GetComponent<BlockArrayControl> ().thisArray = true;
		}

		else if (blockArraySelection == 8) {
			blockArray8.GetComponent<BlockArrayControl> ().thisArray = true;
		}

		else if (blockArraySelection == 9) {
			blockArray9.GetComponent<BlockArrayControl> ().thisArray = true;
		}

		else if (blockArraySelection == 10) {
			blockArray10.GetComponent<BlockArrayControl> ().thisArray = true;
		}

		else if (blockArraySelection == 11) {
			blockArray11.GetComponent<BlockArrayControl> ().thisArray = true;
		}

		else if (blockArraySelection == 12) {
			blockArray12.GetComponent<BlockArrayControl> ().thisArray = true;
		}
	}

	void FixedUpdate () {
		if (Time.timeSinceLevelLoad >= blockArray1.GetComponent<BlockArrayControl> ().recordTime + blockArray1.GetComponent<BlockArrayControl> ().timeUntilNextSelection) {
			ChooseNextArray ();

			blockArray1.GetComponent<BlockArrayControl> ().recordTime = Time.timeSinceLevelLoad;
		}
	}
}
