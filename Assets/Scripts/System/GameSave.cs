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

	//for whether the powerups are currently active or not:
	public bool powerup1;
	public bool powerup2;
	public bool powerup3;
	public bool powerup4;
	public bool powerup5;
	public bool powerup6;
	public bool powerup7;
	public bool powerup8;
	public bool powerup9;
	public bool powerup10;
	public bool powerup11;
	public bool powerup12;
	public bool powerup13;
	public bool powerup14;
	public bool powerup15;
	public bool powerup16;
	public bool powerup17;
	public bool powerup18;
	public bool powerup19;
	public bool powerup20;

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

	//for whether the powerups are currently active or not:
	public bool powerup1;
	public bool powerup2;
	public bool powerup3;
	public bool powerup4;
	public bool powerup5;
	public bool powerup6;
	public bool powerup7;
	public bool powerup8;
	public bool powerup9;
	public bool powerup10;
	public bool powerup11;
	public bool powerup12;
	public bool powerup13;
	public bool powerup14;
	public bool powerup15;
	public bool powerup16;
	public bool powerup17;
	public bool powerup18;
	public bool powerup19;
	public bool powerup20;
}
