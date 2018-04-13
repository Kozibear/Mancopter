using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockArrayControl : MonoBehaviour {

	public float selectedBlockNumber;
	public float recordTime;
	public float timeUntilNextSelection;

	public bool gameStarting;

	public static bool firstTimeBombChucker;
	public static bool firstTimeSpike;
	public static bool firstTimePillar;

	public float coinFlip;

	public bool thisArray;

	public bool canCheckArraySelection;

	//we make an array for each block that is representative of the probability of each other block being selected next
	public float[] Block1FollowUpPropabilities;
	public float[] Block2FollowUpPropabilities;
	public float[] Block3FollowUpPropabilities;
	public float[] Block4FollowUpPropabilities;
	public float[] Block5FollowUpPropabilities;
	public float[] Block6FollowUpPropabilities;
	public float[] Block7FollowUpPropabilities;
	public float[] Block8FollowUpPropabilities;
	public float[] Block9FollowUpPropabilities;
	public float[] Block10FollowUpPropabilities;
	public float[] Block11FollowUpPropabilities;
	public float[] Block12FollowUpPropabilities;
	public float[] Block13FollowUpPropabilities;
	public float[] Block14FollowUpPropabilities;
	public float[] Block15FollowUpPropabilities;
	public float[] Block16FollowUpPropabilities;
	public float[] Block17FollowUpPropabilities;
	public float[] Block18FollowUpPropabilities;
	public float[] Block19FollowUpPropabilities;
	public float[] Block20FollowUpPropabilities;
	public float[] Block21FollowUpPropabilities;
	public float[] Block22FollowUpPropabilities;

	public GameObject blockArrayChooser;

	public bool canSummonBombChucker;
	public bool canSummonSpike;
	public bool canSummonPillar;

	// Use this for initialization
	void Start () {
		gameStarting = true;
		selectedBlockNumber = 0;
		timeUntilNextSelection = 5f;

		firstTimeBombChucker = true;
		firstTimeSpike = true;
		firstTimePillar = true;

		thisArray = false;

		canCheckArraySelection = true;

		Block1FollowUpPropabilities = new float[] {4, 5, 6, 7, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 14, 15, 15, 15, 16, 16, 16, 17, 17, 17, 18, 18, 18, 18, 19, 19, 19, 19, 20, 20, 20, 20, 21, 21, 21, 22, 22, 22};
		Block2FollowUpPropabilities = new float[] {5, 6, 7, 8, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15, 15, 15, 16, 16, 16, 17, 17, 17, 18, 18, 18, 19, 19, 19, 19, 20, 20, 20, 20, 21, 21, 21, 21, 22, 22, 22};
		Block3FollowUpPropabilities = new float[] {6, 7, 8, 9, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15, 15, 16, 16, 16, 17, 17, 17, 18, 18, 18, 19, 19, 19, 20, 20, 20, 20, 21, 21, 21, 21, 22, 22, 22, 22};
		Block4FollowUpPropabilities = new float[] {1, 7, 8, 9, 10, 11, 12, 12, 13, 13, 14, 14, 15, 15, 16, 16, 17, 17, 17, 18, 18, 18, 19, 19, 19, 20, 20, 20, 21, 21, 21, 21, 22, 22, 22, 22};
		Block5FollowUpPropabilities = new float[] {1, 2, 8, 9, 10, 11, 12, 13, 13, 14, 14, 15, 15, 16, 16, 17, 17, 18, 18, 18, 19, 19, 19, 20, 20, 20, 21, 21, 21, 22, 22, 22, 22};
		Block6FollowUpPropabilities = new float[] {1, 2, 3, 9, 10, 11, 12, 13, 14, 14, 15, 15, 16, 16, 17, 17, 18, 18, 19, 19, 19, 20, 20, 20, 21, 21, 21, 22, 22, 22};
		Block7FollowUpPropabilities = new float[] {1, 2, 3, 4, 10, 11, 12, 13, 14, 15, 15, 16, 16, 17, 17, 18, 18, 19, 19, 20, 20, 20, 21, 21, 21, 22, 22, 22};
		Block8FollowUpPropabilities = new float[] {1, 2, 3, 4, 5, 11, 12, 13, 14, 15, 16, 16, 17, 17, 18, 18, 19, 19, 20, 20, 21, 21, 21, 22, 22, 22};
		Block9FollowUpPropabilities = new float[] {1, 1, 2, 3, 4, 5, 6, 12, 13, 14, 15, 16, 17, 17, 18, 18, 19, 19, 20, 20, 21, 21, 22, 22, 22};
		Block10FollowUpPropabilities = new float[] {1, 1, 2, 2, 3, 4, 5, 6, 7, 13, 14, 15, 16, 17, 18, 18, 19, 19, 20, 20, 21, 21, 22, 22};
		Block11FollowUpPropabilities = new float[] {1, 1, 2, 2, 3, 3, 4, 5, 6, 7, 8, 14, 15, 16, 17, 18, 19, 19, 20, 20, 21, 21, 22, 22};
		Block12FollowUpPropabilities = new float[] {1, 1, 2, 2, 3, 3, 4, 4, 5, 6, 7, 8, 9, 15, 16, 17, 18, 19, 20, 20, 21, 21, 22, 22};
		Block13FollowUpPropabilities = new float[] {1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 7, 8, 9, 10, 16, 17, 18, 19, 20, 21, 21, 22, 22};
		Block14FollowUpPropabilities = new float[] {1, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 8, 9, 10, 11, 17, 18, 19, 20, 21, 22, 22};
		Block15FollowUpPropabilities = new float[] {1, 1, 1, 2, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 9, 10, 11, 12, 18, 19, 20, 21, 22};
		Block16FollowUpPropabilities = new float[] {1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 10, 11, 12, 13, 19, 20, 21, 22};
		Block17FollowUpPropabilities = new float[] {1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 11, 12, 13, 14, 20, 21, 22};
		Block18FollowUpPropabilities = new float[] {1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 12, 13, 14, 15, 21, 22};
		Block19FollowUpPropabilities = new float[] {1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 13, 14, 15, 16, 22};
		Block20FollowUpPropabilities = new float[] {1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 14, 15, 16, 17};
		Block21FollowUpPropabilities = new float[] {1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 7, 7, 8, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 15, 16, 17, 18};
		Block22FollowUpPropabilities = new float[] {1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 7, 7, 7, 8, 8, 8, 9, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15, 16, 17, 18, 19};
	
		firstTimeBombChucker = true;
		firstTimeSpike = true;
		firstTimePillar = true;
	}
	
	void FixedUpdate() {

		//if the game starts (The preliminary timer is over) we randomly select our first block number
		if (gameStarting && gameTimer.canStart) {

			selectedBlockNumber = Random.Range (1, 23);

			recordTime = Time.timeSinceLevelLoad;

			gameStarting = false;
		}

		if (thisArray && canCheckArraySelection) {

			if (selectedBlockNumber == 1) {
				selectedBlockNumber = Block1FollowUpPropabilities [Random.Range (0, Block1FollowUpPropabilities.Length)];
			} 
			else if (selectedBlockNumber == 2) {
				selectedBlockNumber = Block2FollowUpPropabilities [Random.Range (0, Block2FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 3) {
				selectedBlockNumber = Block3FollowUpPropabilities [Random.Range (0, Block3FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 4) {
				selectedBlockNumber = Block4FollowUpPropabilities [Random.Range (0, Block4FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 5) {
				selectedBlockNumber = Block5FollowUpPropabilities [Random.Range (0, Block5FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 6) {
				selectedBlockNumber = Block6FollowUpPropabilities [Random.Range (0, Block6FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 7) {
				selectedBlockNumber = Block7FollowUpPropabilities [Random.Range (0, Block7FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 8) {
				selectedBlockNumber = Block8FollowUpPropabilities [Random.Range (0, Block8FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 9) {
				selectedBlockNumber = Block9FollowUpPropabilities [Random.Range (0, Block9FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 10) {
				selectedBlockNumber = Block10FollowUpPropabilities [Random.Range (0, Block10FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 11) {
				selectedBlockNumber = Block11FollowUpPropabilities [Random.Range (0, Block11FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 12) {
				selectedBlockNumber = Block12FollowUpPropabilities [Random.Range (0, Block12FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 13) {
				selectedBlockNumber = Block13FollowUpPropabilities [Random.Range (0, Block13FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 14) {
				selectedBlockNumber = Block14FollowUpPropabilities [Random.Range (0, Block14FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 15) {
				selectedBlockNumber = Block15FollowUpPropabilities [Random.Range (0, Block15FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 16) {
				selectedBlockNumber = Block16FollowUpPropabilities [Random.Range (0, Block16FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 17) {
				selectedBlockNumber = Block17FollowUpPropabilities [Random.Range (0, Block17FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 18) {
				selectedBlockNumber = Block18FollowUpPropabilities [Random.Range (0, Block18FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 19) {
				selectedBlockNumber = Block19FollowUpPropabilities [Random.Range (0, Block19FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 20) {
				selectedBlockNumber = Block20FollowUpPropabilities [Random.Range (0, Block20FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 21) {
				selectedBlockNumber = Block21FollowUpPropabilities [Random.Range (0, Block21FollowUpPropabilities.Length)];
			}
			else if (selectedBlockNumber == 22) {
				selectedBlockNumber = Block22FollowUpPropabilities [Random.Range (0, Block22FollowUpPropabilities.Length)];
			}

			//We select what kind of object is going to emerge from our platform:

			//if we're between 30 and 90 seconds, we choose the bomb chucker
			if (selectedBlockNumber != 0 && gameTimer.gameTime >= 30 && gameTimer.gameTime < 90) { //30-90
				
				//GameObject.Find ("Block"+selectedBlockNumber.ToString()).GetComponent<BlockMovementEffects> ().canSummonBombChucker = true;
				canSummonBombChucker = true;
			}

			//if we're over 90 seconds, we choose between the bomb chucker and the pillar
			if (selectedBlockNumber != 0 && gameTimer.gameTime >= 90) { //90

				if (firstTimePillar) {
					//GameObject.Find ("Block" + selectedBlockNumber.ToString ()).GetComponent<BlockMovementEffects> ().canSummonPillar = true;
					canSummonPillar = true;
				} 
				else {
					
					coinFlip = Random.Range (1, 3);

					if (coinFlip == 1) {
						//GameObject.Find ("Block" + selectedBlockNumber.ToString ()).GetComponent<BlockMovementEffects> ().canSummonBombChucker = true;
						canSummonBombChucker = true;
					}
					if (coinFlip == 2) {
						//GameObject.Find ("Block" + selectedBlockNumber.ToString ()).GetComponent<BlockMovementEffects> ().canSummonPillar = true;
						canSummonPillar = true;
					}
				}

			}

			canCheckArraySelection = false;
		}
	}
}


/*
			//if we're between 110 and 180 seconds, we choose between the bomb chucker and the spike
else if (selectedBlockNumber != 0 && gameTimer.gameTime >= 110 && gameTimer.gameTime < 180) {

	if (firstTimeSpike) {
		//GameObject.Find ("Block" + selectedBlockNumber.ToString ()).GetComponent<BlockMovementEffects> ().canSummonSpike = true;
		canSummonSpike = true;
	} 
	else {
		coinFlip = Random.Range (1, 3);

		if (coinFlip == 1) {
			//GameObject.Find ("Block" + selectedBlockNumber.ToString ()).GetComponent<BlockMovementEffects> ().canSummonBombChucker = true;
			canSummonBombChucker = true;
		}
		if (coinFlip == 2) {
			//GameObject.Find ("Block" + selectedBlockNumber.ToString ()).GetComponent<BlockMovementEffects> ().canSummonSpike = true;
			canSummonSpike = true;
		}
	}
}
*/

/*
if (coinFlip == 2) {
	//GameObject.Find ("Block" + selectedBlockNumber.ToString ()).GetComponent<BlockMovementEffects> ().canSummonSpike = true;
	canSummonSpike = true;
}
*/