using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameSave : MonoBehaviour {

	public static GameSave gameSave;

	//for the most recent score made by the player:
	public float mostRecentScore;

	//for the top 5 high scores:
	public float highscore1;
	public float highscore2;
	public float highscore3;
	public float highscore4;
	public float highscore5;

	//for the top 5 high scores' items used:
	public bool[] highscore1Items;
	public bool[] highscore2Items;
	public bool[] highscore3Items;
	public bool[] highscore4Items;
	public bool[] highscore5Items;

	//for whether the powerups are currently not purchased, purchased, or active
	//0 = not purchased, 1 = purchased, 2 = purchased and active
	public float powerup1;
	public float powerup2;
	public float powerup3;
	public float powerup4;
	public float powerup5;
	public float powerup6;
	public float powerup7;
	public float powerup8;
	public float powerup9;
	public float powerup10;
	public float powerup11;
	public float powerup12;
	public float powerup13;
	public float powerup14;
	public float powerup15;
	public float powerup16;
	public float powerup17;
	public float powerup18;
	public float powerup19;
	public float powerup20;

	public bool upgradeScreenExplanationRead;

	public bool ControlsScreen;

	void Awake () {
		//if the gameSave variable has not been assigned, we don't destroy it, and we make it reference this.
		if (gameSave == null) {
			DontDestroyOnLoad (gameObject);
			gameSave = this;
		} 
		//if control does exist, and this is not it, destroy it
		else if (gameSave != this) {
			Destroy (gameObject);
		}

	}
	
	void FixedUpdate() {
	}

	//write to a file:
	public void Save () {
		BinaryFormatter bf = new BinaryFormatter(); //we create a binary formatter
		FileStream file = File.Create(Application.persistentDataPath + "/playerSaveData.dat"); //the file in which we'll save the game data

		playerData data = new playerData ();

		data.mostRecentScore = mostRecentScore;

		data.highscore1 =  highscore1;
		data.highscore2 =  highscore2;
		data.highscore3 =  highscore3;
		data.highscore4 =  highscore4;
		data.highscore5 =  highscore5;

		data.highscore1Items = highscore1Items;
		data.highscore2Items = highscore2Items;
		data.highscore3Items = highscore3Items;
		data.highscore4Items = highscore4Items;
		data.highscore5Items = highscore5Items;

		data.powerup1 = powerup1;
		data.powerup2 = powerup2;
		data.powerup3 = powerup3;
		data.powerup4 = powerup4;
		data.powerup5 = powerup5;
		data.powerup6 = powerup6;
		data.powerup7 = powerup7;
		data.powerup8 = powerup8;
		data.powerup9 = powerup9;
		data.powerup10 = powerup10;
		data.powerup11 = powerup11;
		data.powerup12 = powerup12;
		data.powerup13 = powerup13;
		data.powerup14 = powerup14;
		data.powerup15 = powerup15;
		data.powerup16 = powerup16;
		data.powerup17 = powerup17;
		data.powerup18 = powerup18;
		data.powerup19 = powerup19;
		data.powerup20 = powerup20;

		data.upgradeScreenExplanationRead = upgradeScreenExplanationRead;

		data.ControlsScreen = ControlsScreen;
	
		bf.Serialize (file, data); //we serialize our data to the above file
		file.Close(); //at the end, we close the file
	}

	//read from a file:
	public void Load () {

		if (File.Exists (Application.persistentDataPath + "/playerSaveData.dat")) {

			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerSaveData.dat", FileMode.Open);
			playerData data = (playerData)bf.Deserialize (file);
			file.Close ();

			mostRecentScore = data.mostRecentScore;

			highscore1 = data.highscore1;
			highscore2 = data.highscore2;
			highscore3 = data.highscore3;
			highscore4 = data.highscore4;
			highscore5 = data.highscore5;

			highscore1Items = data.highscore1Items;
			highscore2Items = data.highscore2Items;
			highscore3Items = data.highscore3Items;
			highscore4Items = data.highscore4Items;
			highscore5Items = data.highscore5Items;

			powerup1 = data.powerup1;
			powerup2 = data.powerup2;
			powerup3 = data.powerup3;
			powerup4 = data.powerup4;
			powerup5 = data.powerup5;
			powerup6 = data.powerup6;
			powerup7 = data.powerup7;
			powerup8 = data.powerup8;
			powerup9 = data.powerup9;
			powerup10 = data.powerup10;
			powerup11 = data.powerup11;
			powerup12 = data.powerup12;
			powerup13 = data.powerup13;
			powerup14 = data.powerup14;
			powerup15 = data.powerup15;
			powerup16 = data.powerup16;
			powerup17 = data.powerup17;
			powerup18 = data.powerup18;
			powerup19 = data.powerup19;
			powerup20 = data.powerup20;

			upgradeScreenExplanationRead = data.upgradeScreenExplanationRead;

			ControlsScreen = data.ControlsScreen;

		}
	}
}

[Serializable] //this tells unity that I can save the following to a file
class playerData {

	//for the most recent score made by the player:
	public float mostRecentScore;

	//for the top 5 high scores:
	public float highscore1;
	public float highscore2;
	public float highscore3;
	public float highscore4;
	public float highscore5;

	//for the top 5 high scores' items used:
	public bool[] highscore1Items;
	public bool[] highscore2Items;
	public bool[] highscore3Items;
	public bool[] highscore4Items;
	public bool[] highscore5Items;

	//for whether the powerups are currently active or not:
	public float powerup1;
	public float powerup2;
	public float powerup3;
	public float powerup4;
	public float powerup5;
	public float powerup6;
	public float powerup7;
	public float powerup8;
	public float powerup9;
	public float powerup10;
	public float powerup11;
	public float powerup12;
	public float powerup13;
	public float powerup14;
	public float powerup15;
	public float powerup16;
	public float powerup17;
	public float powerup18;
	public float powerup19;
	public float powerup20;

	public bool upgradeScreenExplanationRead;

	public bool ControlsScreen;

}