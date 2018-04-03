using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetData : MonoBehaviour {

	public Button resetDataButton;

	public bool[] resetBoolArray;

	public GameObject upgrading;

	// Use this for initialization
	void Start () {
		resetDataButton.onClick.AddListener (resetSaveData);
		resetBoolArray = new bool[20];

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void resetSaveData () {
		GameSave.gameSave.Load ();

		GameSave.gameSave.mostRecentScore = 0;

		GameSave.gameSave.highscore1 = 0;
		GameSave.gameSave.highscore2 = 0;
		GameSave.gameSave.highscore3 = 0;
		GameSave.gameSave.highscore4 = 0;
		GameSave.gameSave.highscore5 = 0;

		GameSave.gameSave.highscore1Items = resetBoolArray;
		GameSave.gameSave.highscore2Items = resetBoolArray;
		GameSave.gameSave.highscore3Items = resetBoolArray;
		GameSave.gameSave.highscore4Items = resetBoolArray;
		GameSave.gameSave.highscore5Items = resetBoolArray;

		GameSave.gameSave.powerup1 = 0;
		GameSave.gameSave.powerup2 = 0;
		GameSave.gameSave.powerup3 = 0;
		GameSave.gameSave.powerup4 = 0;
		GameSave.gameSave.powerup5 = 0;
		GameSave.gameSave.powerup6 = 0;
		GameSave.gameSave.powerup7 = 0;
		GameSave.gameSave.powerup8 = 0;
		GameSave.gameSave.powerup9 = 0;
		GameSave.gameSave.powerup10 = 0;
		GameSave.gameSave.powerup11 = 0;
		GameSave.gameSave.powerup12 = 0;
		GameSave.gameSave.powerup13 = 0;
		GameSave.gameSave.powerup14 = 0;
		GameSave.gameSave.powerup15 = 0;
		GameSave.gameSave.powerup16 = 0;
		GameSave.gameSave.powerup17 = 0;
		GameSave.gameSave.powerup18 = 0;
		GameSave.gameSave.powerup19 = 0;
		GameSave.gameSave.powerup20 = 0;

		GameSave.gameSave.upgradeScreenExplanationRead = false;

		GameSave.gameSave.ControlsScreen = false;

		GameSave.gameSave.Save ();

		upgrading.GetComponent<Upgrading> ().points = 0;
	}
}
