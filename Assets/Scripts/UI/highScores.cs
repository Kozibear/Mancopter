using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScores : MonoBehaviour {

	public Text text;

	public Image Item1;
	public Image Item2;
	public Image Item3;
	public Image Item4;
	public Image Item5;

	public Sprite[] ItemSprites;

	public Sprite NoItemSprite;
	public Sprite Item1Sprite;
	public Sprite Item2Sprite;
	public Sprite Item3Sprite;
	public Sprite Item4Sprite;
	public Sprite Item5Sprite;
	public Sprite Item6Sprite;
	public Sprite Item7Sprite;
	public Sprite Item8Sprite;
	public Sprite Item9Sprite;
	public Sprite Item10Sprite;
	public Sprite Item11Sprite;
	public Sprite Item12Sprite;
	public Sprite Item13Sprite;
	public Sprite Item14Sprite;
	public Sprite Item15Sprite;
	public Sprite Item16Sprite;
	public Sprite Item17Sprite;
	public Sprite Item18Sprite;
	public Sprite Item19Sprite;
	public Sprite Item20Sprite;

	public bool firstTime;

	void Awake () {
	}

	void Start () {
		ItemSprites = new Sprite[] {Item1Sprite, Item2Sprite, Item3Sprite, Item4Sprite, Item5Sprite, Item6Sprite, Item7Sprite, Item8Sprite, Item9Sprite, Item10Sprite, Item11Sprite, Item12Sprite, Item13Sprite, Item14Sprite, Item15Sprite, Item16Sprite, Item17Sprite, Item18Sprite, Item19Sprite, Item20Sprite};
	}

	void FixedUpdate () {

		if (!firstTime) {
			GameSave.gameSave.Load ();

			if (this.gameObject.name == "HighScore1") {
				text.text = "1. " + GameSave.gameSave.highscore1;

				for (int i = 0; i < GameSave.gameSave.highscore1Items.Length; i++) {
					if (Item1.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore1Items [i] == true) {
							Item1.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item2.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore1Items [i] == true) {
							Item2.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item3.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore1Items [i] == true) {
							Item3.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item4.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore1Items [i] == true) {
							Item4.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item5.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore1Items [i] == true) {
							Item5.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					}
				}
			}

			if (this.gameObject.name == "HighScore2") {
				text.text = "2. " + GameSave.gameSave.highscore2;

				for (int i = 0; i < GameSave.gameSave.highscore2Items.Length; i++) {
					if (Item1.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore2Items [i] == true) {
							Item1.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item2.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore2Items [i] == true) {
							Item2.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item3.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore2Items [i] == true) {
							Item3.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item4.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore2Items [i] == true) {
							Item4.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item5.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore2Items [i] == true) {
							Item5.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					}
				}
			}
			if (this.gameObject.name == "HighScore3") {
				text.text = "3. " + GameSave.gameSave.highscore3;

				for (int i = 0; i < GameSave.gameSave.highscore3Items.Length; i++) {
					if (Item1.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore3Items [i] == true) {
							Item1.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item2.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore3Items [i] == true) {
							Item2.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item3.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore3Items [i] == true) {
							Item3.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item4.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore3Items [i] == true) {
							Item4.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item5.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore3Items [i] == true) {
							Item5.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					}
				}
			}
			if (this.gameObject.name == "HighScore4") {
				text.text = "4. " + GameSave.gameSave.highscore4;

				for (int i = 0; i < GameSave.gameSave.highscore4Items.Length; i++) {
					if (Item1.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore4Items [i] == true) {
							Item1.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item2.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore4Items [i] == true) {
							Item2.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item3.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore4Items [i] == true) {
							Item3.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item4.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore4Items [i] == true) {
							Item4.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item5.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore4Items [i] == true) {
							Item5.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					}
				}
			}
			if (this.gameObject.name == "HighScore5") {
				text.text = "5. " + GameSave.gameSave.highscore5;

				for (int i = 0; i < GameSave.gameSave.highscore5Items.Length; i++) {
					if (Item1.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore5Items [i] == true) {
							Item1.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item2.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore5Items [i] == true) {
							Item2.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item3.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore5Items [i] == true) {
							Item3.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item4.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore5Items [i] == true) {
							Item4.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item5.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore5Items [i] == true) {
							Item5.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					}
				}
			}

			if (Item1.GetComponent<Image> ().sprite == null) {
				Item1.GetComponent<Image> ().sprite = NoItemSprite;
			}
			if (Item2.GetComponent<Image> ().sprite == null) {
				Item2.GetComponent<Image> ().sprite = NoItemSprite;
			}
			if (Item3.GetComponent<Image> ().sprite == null) {
				Item3.GetComponent<Image> ().sprite = NoItemSprite;
			}
			if (Item4.GetComponent<Image> ().sprite == null) {
				Item4.GetComponent<Image> ().sprite = NoItemSprite;
			}
			if (Item5.GetComponent<Image> ().sprite == null) {
				Item5.GetComponent<Image> ().sprite = NoItemSprite;
			}

			firstTime = true;
		}
	}

	void OnEnable() {

		if (firstTime) {
			
			GameSave.gameSave.Load ();

			if (this.gameObject.name == "HighScore1") {
				text.text = "1. " + GameSave.gameSave.highscore1;

				for (int i = 0; i < GameSave.gameSave.highscore1Items.Length; i++) {
					if (Item1.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore1Items [i] == true) {
							Item1.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item2.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore1Items [i] == true) {
							Item2.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item3.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore1Items [i] == true) {
							Item3.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item4.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore1Items [i] == true) {
							Item4.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item5.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore1Items [i] == true) {
							Item5.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					}
				}
			}

			if (this.gameObject.name == "HighScore2") {
				text.text = "2. " + GameSave.gameSave.highscore2;

				for (int i = 0; i < GameSave.gameSave.highscore2Items.Length; i++) {
					if (Item1.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore2Items [i] == true) {
							Item1.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item2.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore2Items [i] == true) {
							Item2.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item3.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore2Items [i] == true) {
							Item3.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item4.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore2Items [i] == true) {
							Item4.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item5.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore2Items [i] == true) {
							Item5.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					}
				}
			}
			if (this.gameObject.name == "HighScore3") {
				text.text = "3. " + GameSave.gameSave.highscore3;

				for (int i = 0; i < GameSave.gameSave.highscore3Items.Length; i++) {
					if (Item1.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore3Items [i] == true) {
							Item1.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item2.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore3Items [i] == true) {
							Item2.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item3.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore3Items [i] == true) {
							Item3.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item4.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore3Items [i] == true) {
							Item4.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item5.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore3Items [i] == true) {
							Item5.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					}
				}
			}
			if (this.gameObject.name == "HighScore4") {
				text.text = "4. " + GameSave.gameSave.highscore4;

				for (int i = 0; i < GameSave.gameSave.highscore4Items.Length; i++) {
					if (Item1.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore4Items [i] == true) {
							Item1.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item2.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore4Items [i] == true) {
							Item2.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item3.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore4Items [i] == true) {
							Item3.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item4.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore4Items [i] == true) {
							Item4.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item5.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore4Items [i] == true) {
							Item5.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					}
				}
			}
			if (this.gameObject.name == "HighScore5") {
				text.text = "5. " + GameSave.gameSave.highscore5;

				for (int i = 0; i < GameSave.gameSave.highscore5Items.Length; i++) {
					if (Item1.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore5Items [i] == true) {
							Item1.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item2.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore5Items [i] == true) {
							Item2.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item3.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore5Items [i] == true) {
							Item3.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item4.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore5Items [i] == true) {
							Item4.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					} else if (Item5.GetComponent<Image> ().sprite == null) {
						if (GameSave.gameSave.highscore5Items [i] == true) {
							Item5.GetComponent<Image> ().sprite = ItemSprites [i];
						}
					}
				}
			}

			if (Item1.GetComponent<Image> ().sprite == null) {
				Item1.GetComponent<Image> ().sprite = NoItemSprite;
			}
			if (Item2.GetComponent<Image> ().sprite == null) {
				Item2.GetComponent<Image> ().sprite = NoItemSprite;
			}
			if (Item3.GetComponent<Image> ().sprite == null) {
				Item3.GetComponent<Image> ().sprite = NoItemSprite;
			}
			if (Item4.GetComponent<Image> ().sprite == null) {
				Item4.GetComponent<Image> ().sprite = NoItemSprite;
			}
			if (Item5.GetComponent<Image> ().sprite == null) {
				Item5.GetComponent<Image> ().sprite = NoItemSprite;
			}
		}
	}
}