using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sceneManagerSplash : MonoBehaviour {

	public GameObject SplashScreen;
	public GameObject UpgradeScreen;
	public GameObject HighScoreScreen;

	public float[] currentPowerups;
	public bool[] resetBoolArray;

	public AudioSource click;

	public Button button1;
	public Button button2;
	public Button button3;
	public Button button4;
	public Button button5;
	public Button button6;
	public Button button7;
	public Button button8;
	public Button button9;

	public float numberEquipped;

	// Use this for initialization
	void Start () {

		button1.onClick.AddListener (playClick);
		button2.onClick.AddListener (playClick);
		button3.onClick.AddListener (playClick);
		button4.onClick.AddListener (playClick);
		button5.onClick.AddListener (playClick);
		button6.onClick.AddListener (playClick);
		button7.onClick.AddListener (playClick);
		button8.onClick.AddListener (playClick);
		button9.onClick.AddListener (playClick);

		GameSave.gameSave.Load();

		currentPowerups = new float[] {GameSave.gameSave.powerup1, GameSave.gameSave.powerup2, GameSave.gameSave.powerup3, GameSave.gameSave.powerup4, GameSave.gameSave.powerup5, GameSave.gameSave.powerup6, GameSave.gameSave.powerup7, GameSave.gameSave.powerup8, GameSave.gameSave.powerup9, GameSave.gameSave.powerup10, GameSave.gameSave.powerup11, GameSave.gameSave.powerup12, GameSave.gameSave.powerup13, GameSave.gameSave.powerup14, GameSave.gameSave.powerup15, GameSave.gameSave.powerup16, GameSave.gameSave.powerup17, GameSave.gameSave.powerup18, GameSave.gameSave.powerup19, GameSave.gameSave.powerup20};
		resetBoolArray = new bool[20];

		UpgradeScreen.transform.GetChild (0).GetComponent<Upgrading> ().points = GameSave.gameSave.mostRecentScore;

		if (GameSave.gameSave.mostRecentScore > 0) {

			if (GameSave.gameSave.mostRecentScore > GameSave.gameSave.highscore1) {
				GameSave.gameSave.highscore5 = GameSave.gameSave.highscore4;
				GameSave.gameSave.highscore4 = GameSave.gameSave.highscore3;
				GameSave.gameSave.highscore3 = GameSave.gameSave.highscore2;
				GameSave.gameSave.highscore2 = GameSave.gameSave.highscore1;
				GameSave.gameSave.highscore1 = GameSave.gameSave.mostRecentScore;
				GameSave.gameSave.mostRecentScore = 0;

				GameSave.gameSave.highscore5Items = GameSave.gameSave.highscore4Items;
				GameSave.gameSave.highscore4Items = GameSave.gameSave.highscore3Items;
				GameSave.gameSave.highscore3Items = GameSave.gameSave.highscore2Items;
				GameSave.gameSave.highscore2Items = GameSave.gameSave.highscore1Items;
				GameSave.gameSave.highscore1Items = resetBoolArray;

				for (int i = 0; i < GameSave.gameSave.highscore1Items.Length; i++) {
					if (GameSave.gameSave.highscore1Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore1Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore1Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore1Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore1Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore1Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore1Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore1Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore1Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore1Items [i] = true;
						}
					}
				}

			} 
			else if (GameSave.gameSave.mostRecentScore > GameSave.gameSave.highscore2 && GameSave.gameSave.mostRecentScore <= GameSave.gameSave.highscore1) {
				GameSave.gameSave.highscore5 = GameSave.gameSave.highscore4;
				GameSave.gameSave.highscore4 = GameSave.gameSave.highscore3;
				GameSave.gameSave.highscore3 = GameSave.gameSave.highscore2;
				GameSave.gameSave.highscore2 = GameSave.gameSave.mostRecentScore;
				GameSave.gameSave.mostRecentScore = 0;

				GameSave.gameSave.highscore5Items = GameSave.gameSave.highscore4Items;
				GameSave.gameSave.highscore4Items = GameSave.gameSave.highscore3Items;
				GameSave.gameSave.highscore3Items = GameSave.gameSave.highscore2Items;
				GameSave.gameSave.highscore2Items = resetBoolArray;

				for (int i = 0; i < GameSave.gameSave.highscore2Items.Length; i++) {
					if (GameSave.gameSave.highscore2Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore2Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore2Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore2Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore2Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore2Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore2Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore2Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore2Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore2Items [i] = true;
						}
					}
				}
			}
			else if (GameSave.gameSave.mostRecentScore > GameSave.gameSave.highscore3 && GameSave.gameSave.mostRecentScore <= GameSave.gameSave.highscore2) {
				GameSave.gameSave.highscore5 = GameSave.gameSave.highscore4;
				GameSave.gameSave.highscore4 = GameSave.gameSave.highscore3;
				GameSave.gameSave.highscore3 = GameSave.gameSave.mostRecentScore;
				GameSave.gameSave.mostRecentScore = 0;

				GameSave.gameSave.highscore5Items = GameSave.gameSave.highscore4Items;
				GameSave.gameSave.highscore4Items = GameSave.gameSave.highscore3Items;
				GameSave.gameSave.highscore3Items = resetBoolArray;

				for (int i = 0; i < GameSave.gameSave.highscore3Items.Length; i++) {
					if (GameSave.gameSave.highscore3Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore3Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore3Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore3Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore3Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore3Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore3Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore3Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore3Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore3Items [i] = true;
						}
					}
				}
			}
			else if (GameSave.gameSave.mostRecentScore > GameSave.gameSave.highscore4 && GameSave.gameSave.mostRecentScore <= GameSave.gameSave.highscore3) {
				GameSave.gameSave.highscore5 = GameSave.gameSave.highscore4;
				GameSave.gameSave.highscore4 = GameSave.gameSave.mostRecentScore;
				GameSave.gameSave.mostRecentScore = 0;

				GameSave.gameSave.highscore5Items = GameSave.gameSave.highscore4Items;
				GameSave.gameSave.highscore4Items = resetBoolArray;

				for (int i = 0; i < GameSave.gameSave.highscore4Items.Length; i++) {
					if (GameSave.gameSave.highscore4Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore4Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore4Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore4Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore4Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore4Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore4Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore4Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore4Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore4Items [i] = true;
						}
					}
				}
			}
			else if (GameSave.gameSave.mostRecentScore > GameSave.gameSave.highscore5 && GameSave.gameSave.mostRecentScore <= GameSave.gameSave.highscore4) {
				GameSave.gameSave.highscore5 = GameSave.gameSave.mostRecentScore;
				GameSave.gameSave.mostRecentScore = 0;

				GameSave.gameSave.highscore5Items = resetBoolArray;

				for (int i = 0; i < GameSave.gameSave.highscore5Items.Length; i++) {
					if (GameSave.gameSave.highscore5Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore5Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore5Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore5Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore5Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore5Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore5Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore5Items [i] = true;
						}
					}
					else if (GameSave.gameSave.highscore5Items [i] == false) {
						if (currentPowerups [i] == 2) {
							GameSave.gameSave.highscore5Items [i] = true;
						}
					}
				}
			}

			GameSave.gameSave.Save ();

			SplashScreen.gameObject.SetActive (false);
			UpgradeScreen.gameObject.SetActive (false);
			HighScoreScreen.gameObject.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		currentPowerups = new float[] {GameSave.gameSave.powerup1, GameSave.gameSave.powerup2, GameSave.gameSave.powerup3, GameSave.gameSave.powerup4, GameSave.gameSave.powerup5, GameSave.gameSave.powerup6, GameSave.gameSave.powerup7, GameSave.gameSave.powerup8, GameSave.gameSave.powerup9, GameSave.gameSave.powerup10, GameSave.gameSave.powerup11, GameSave.gameSave.powerup12, GameSave.gameSave.powerup13, GameSave.gameSave.powerup14, GameSave.gameSave.powerup15, GameSave.gameSave.powerup16, GameSave.gameSave.powerup17, GameSave.gameSave.powerup18, GameSave.gameSave.powerup19, GameSave.gameSave.powerup20};

	}

	void playClick () {
		click.Play ();
	}

	public bool checkEquippedNumber () {

		numberEquipped = 0;

		for (int i = 0; i < currentPowerups.Length; i++) {
			if (currentPowerups [i] == 2) {
				numberEquipped++;
			}
		}

		if (numberEquipped >= 5) {
			return false;
		} 
		else {
			return true;
		}
	}
}
