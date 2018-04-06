using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovementEffects : MonoBehaviour {

	public Vector3 originalLocation;
	public Vector3 modifiedLocation;

	public float thisBlocksNumber;

	public float recordTime;
	public bool checkTheTime;

	public GameObject bombChucker;
	public float timeUntilBombchuckers;
	public bool canSummonBombChucker;
	public bool noBombs;

	public GameObject spike;
	public float timeUntilSpike;
	public bool canSummonSpike;
	public bool noSpikes;

	public GameObject firePillar;
	public float timeUntilPillar;
	public bool canSummonPillar;

	public float coinFlip;

	public bool doubleEXP;
	public bool canDoubleEXP;

	public GameObject Player;

	public float offsetX;
	public float offsetY;
	public float offsetZ;

	public float WallNumber;

	public Renderer rend;

	// Use this for initialization
	void Start () {
		checkTheTime = true;

		timeUntilBombchuckers = 90;
		canSummonBombChucker = false;
		noBombs = false;

		timeUntilSpike = 110;
		canSummonSpike = false;

		timeUntilPillar = 180;
		canSummonPillar = false;

		doubleEXP = false;
		canDoubleEXP = true;

		rend = this.GetComponent<Renderer> ();
	}
	
	void FixedUpdate () {

		if (ButtonsRotationsController.playSpaceRotating == false) {
			this.GetComponent<BoxCollider2D> ().enabled = true;
		}
		if (ButtonsRotationsController.playSpaceRotating == true) {
			this.GetComponent<BoxCollider2D> ().enabled = false;
		}

		if (ButtonsRotationsController.Make1Invisible && WallNumber == 1) {
			rend.enabled = false;
		}

		if (!ButtonsRotationsController.Make1Invisible && WallNumber == 1) {
			rend.enabled = true;
		}


		if (ButtonsRotationsController.Make2Invisible && WallNumber == 2) {
			rend.enabled = false;
		}

		if (!ButtonsRotationsController.Make2Invisible && WallNumber == 2) {
			rend.enabled = true;
		}


		if (ButtonsRotationsController.Make3Invisible && WallNumber == 3) {
			rend.enabled = false;
		}

		if (!ButtonsRotationsController.Make3Invisible && WallNumber == 3) {
			rend.enabled = true;
		}


		if (ButtonsRotationsController.Make4Invisible && WallNumber == 4) {
			rend.enabled = false;
		}

		if (!ButtonsRotationsController.Make4Invisible && WallNumber == 4) {
			rend.enabled = true;
		}


		if (ButtonsRotationsController.Make5Invisible && WallNumber == 5) {
			rend.enabled = false;
		}

		if (!ButtonsRotationsController.Make5Invisible && WallNumber == 5) {
			rend.enabled = true;
		}


		if (ButtonsRotationsController.Make6Invisible && WallNumber == 6) {
			rend.enabled = false;
		}

		if (!ButtonsRotationsController.Make6Invisible && WallNumber == 6) {
			rend.enabled = true;
		}

		/*
		//if this block's number is not currently selected, we move it from it's original position to down below
		if ((this.transform.parent.GetComponent<BlockArrayControl>().selectedBlockNumber != thisBlocksNumber && this.transform.parent.GetComponent<BlockArrayControl>().thisArray == true) || (this.transform.parent.GetComponent<BlockArrayControl>().selectedBlockNumber != thisBlocksNumber && this.transform.parent.GetComponent<BlockArrayControl>().thisArray == false)) {
			*/

		//if this block's number is chosen...
		if (this.transform.parent.GetComponent<BlockArrayControl>().selectedBlockNumber == thisBlocksNumber && this.transform.parent.GetComponent<BlockArrayControl>().thisArray == true) {

			//first, if we were given the opportunity to summon a bomb, we check to see if we summon one;
			//NOTE: As defined in the BlockArrayControl script, whether we can summon a bomb, a spike or a fire pillar is random, but equal
			if (this.transform.parent.GetComponent<BlockArrayControl>().canSummonBombChucker) {
				if (this.transform.parent.GetComponent<BlockArrayControl> ().firstTimeBombChucker) {
					GameObject BombChucker = Instantiate (bombChucker, transform.position + new Vector3 (0, 0.8f, 0), transform.rotation);
					BombChucker.transform.parent = this.transform;
					BombChucker.GetComponent<stationaryBombChucker> ().Player = Player;

					this.transform.parent.GetComponent<BlockArrayControl> ().firstTimeBombChucker = false;

				} else if (gameTimer.gameTime < 360) {
					coinFlip = Random.Range (1, 101);
					if (coinFlip <= 15) {

						GameObject BombChucker = Instantiate (bombChucker, transform.position + new Vector3 (0, 0.8f, 0), transform.rotation);
						BombChucker.transform.parent = this.transform;
						BombChucker.GetComponent<stationaryBombChucker> ().Player = Player;
					} 
				} else if (gameTimer.gameTime >= 360) {
					coinFlip = Random.Range (1, 101);
					if (coinFlip <= 20) {

						GameObject BombChucker = Instantiate (bombChucker, transform.position + new Vector3 (0, 0.8f, 0), transform.rotation);
						BombChucker.transform.parent = this.transform;
						BombChucker.GetComponent<stationaryBombChucker> ().Player = Player;
					} 
				} 
					
				this.transform.parent.GetComponent<BlockArrayControl>().canSummonBombChucker = false;
			}

			/*
			//second, if we were given the opportunity to summon a spike, we check to see if we summon one;
			if (this.transform.parent.GetComponent<BlockArrayControl>().canSummonSpike) {

				if (this.transform.parent.GetComponent<BlockArrayControl> ().firstTimeSpike) {

					GameObject Spike = Instantiate (spike, transform.position + new Vector3 (0, 0.8f, 0), transform.rotation);
					Spike.transform.parent = this.transform;
					this.transform.parent.GetComponent<BlockArrayControl> ().firstTimeSpike = false;
					buttonArray.newSpikeAllowed = false;

				} else if (gameTimer.gameTime < 440 && buttonArray.newSpikeAllowed) { //we dont' summon another spike if one is already on the field

					coinFlip = Random.Range (1, 101);
					if (coinFlip <= 15) {

						GameObject Spike = Instantiate (spike, transform.position + new Vector3 (0, 0.8f, 0), transform.rotation);
						Spike.transform.parent = this.transform;
						buttonArray.newSpikeAllowed = false;
					} 
				} else if (gameTimer.gameTime >= 440 && buttonArray.newSpikeAllowed) {

					coinFlip = Random.Range (1, 101);
					if (coinFlip <= 20) {

						GameObject Spike = Instantiate (spike, transform.position + new Vector3 (0, 0.8f, 0), transform.rotation);
						Spike.transform.parent = this.transform;
						buttonArray.newSpikeAllowed = false;
					} 
				}

				this.transform.parent.GetComponent<BlockArrayControl>().canSummonSpike = false;
			}
			*/

			//third, if we were given the opportunity to summon a pillar of fire, we check to see if we summon one;
			if (this.transform.parent.GetComponent<BlockArrayControl>().canSummonPillar) {
				
				if (this.transform.parent.GetComponent<BlockArrayControl> ().firstTimePillar) {

						GameObject FirePillar = Instantiate (firePillar, transform.position + new Vector3 (0, 0.8f, 0), transform.rotation);
					FirePillar.transform.parent = this.transform;
					this.transform.parent.GetComponent<BlockArrayControl> ().firstTimePillar = false;

				} else if (gameTimer.gameTime < 440) {

					coinFlip = Random.Range (1, 101);
					if (coinFlip <= 15) {

						GameObject FirePillar = Instantiate (firePillar, transform.position + new Vector3 (0, 0.8f, 0), transform.rotation);
						FirePillar.transform.parent = this.transform;
					} 

				} else if (gameTimer.gameTime >= 440) {

					coinFlip = Random.Range (1, 101);
					if (coinFlip <= 20) {

						GameObject FirePillar = Instantiate (firePillar, transform.position + new Vector3 (0, 0.8f, 0), transform.rotation);
						FirePillar.transform.parent = this.transform;
					} 
				} 

				this.transform.parent.GetComponent<BlockArrayControl>().canSummonPillar = false;
			}


			if (!checkTheTime) {
				recordTime = Time.time;
				checkTheTime = true;
			}

			if (checkTheTime && Time.time >= recordTime+0f && Time.time < recordTime+1f) {
				transform.Translate(Vector3.up * Time.deltaTime * 2f);
			}
		}
		else {

			if (checkTheTime) {
				recordTime = Time.time;
				checkTheTime = false;
			}
			
			if (Time.time >= recordTime+(gameTimer.startingWait-1) && Time.time < recordTime+(gameTimer.startingWait)) {

				transform.Translate(Vector3.down * Time.deltaTime * 2f);
			}
			
			if (Time.time >= recordTime+3.4f) {
				doubleEXP = false;
			}

			//slightly after we begin lowering it, we destroy the bomb chucker
			if (Time.time >= recordTime + 3.4f) {
			}

		} 
			
	}

	//we have to make the player a child of the block it lands on, so that it won't be awkward when it jumps off of a descending block
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			//Makes this object the parent of the colliding "player" object
			collision.transform.parent = this.transform;
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.transform.parent = this.transform;

			//while the player is on the block, they receive points
				collision.gameObject.GetComponent<pointSystem>().accumulateGroundPoints = true;

			//if we're currently standing on a previously-spiked block, our points are doubled
			if (doubleEXP && canDoubleEXP) {
				collision.gameObject.GetComponent<pointSystem>().pointMultiplier *= 2;
				canDoubleEXP = false;
			}
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.transform.parent = null;

			//when the player is no longer on the block, they stop receiving points
				collision.gameObject.GetComponent<pointSystem>().accumulateGroundPoints = false;

			//we halve our EXP earnings
			if (doubleEXP && !canDoubleEXP) {
				collision.gameObject.GetComponent<pointSystem>().pointMultiplier /= 2;
				canDoubleEXP = true;
			}
		}
	}
}