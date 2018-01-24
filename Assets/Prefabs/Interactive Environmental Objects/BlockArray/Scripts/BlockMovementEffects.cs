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

	// Use this for initialization
	void Start () {
		checkTheTime = true;
		originalLocation = this.transform.position;
		modifiedLocation = new Vector3 (transform.position.x, transform.position.y - 2f, transform.position.z);

		timeUntilBombchuckers = 90;
		canSummonBombChucker = false;
		noBombs = false;

		timeUntilSpike = 110;
		canSummonSpike = false;

		timeUntilPillar = 180;
		canSummonPillar = false;

		doubleEXP = false;
		canDoubleEXP = true;
	}
	
	void FixedUpdate () {

		//if this block's number is not currently selected, we move it from it's original position to down below
		if (GameObject.Find ("BlockArray").GetComponent<BlockArrayControl>().selectedBlockNumber != thisBlocksNumber) {

			if (checkTheTime) {
				recordTime = Time.time;
				checkTheTime = false;
			}


			if (Time.time >= recordTime+1.4f) {
				transform.position = Vector3.MoveTowards (this.transform.position, modifiedLocation, 0.01f);
			}

			//slightly after we begin lowering it, we destroy the bomb chucker
			if (Time.time >= recordTime + 2.4f) {
			}

		} 

		//once we return to our modiFied place below, we wipe any point modifiers
		if (this.transform.position == modifiedLocation) {
			doubleEXP = false;
		}

		//if this block's number is chosen...
		if (GameObject.Find ("BlockArray").GetComponent<BlockArrayControl>().selectedBlockNumber == thisBlocksNumber) {

			//first, if we were given the opportunity to summon a bomb, we check to see if we summon one;
			//NOTE: As defined in the BlockArrayControl script, whether we can summon a bomb, a spike or a fire pillar is random, but equal
			if (canSummonBombChucker) {

				if (GameObject.Find ("BlockArray").GetComponent<BlockArrayControl> ().firstTimeBombChucker) {
					
					GameObject BombChucker = Instantiate (bombChucker, transform.position + new Vector3 (0, 0.8f, 0), transform.rotation);
					BombChucker.transform.parent = this.transform;

					GameObject.Find ("BlockArray").GetComponent<BlockArrayControl> ().firstTimeBombChucker = false;

				} else if (GameObject.Find ("CopterBase").GetComponent<gameTimer> ().gameTime < 360) {
					
					coinFlip = Random.Range (1, 101);
					if (coinFlip <= 15) {

						GameObject BombChucker = Instantiate (bombChucker, transform.position + new Vector3 (0, 0.8f, 0), transform.rotation);
						BombChucker.transform.parent = this.transform;
					} 
				} else if (GameObject.Find ("CopterBase").GetComponent<gameTimer> ().gameTime >= 360) {

					coinFlip = Random.Range (1, 101);
					if (coinFlip <= 20) {

						GameObject BombChucker = Instantiate (bombChucker, transform.position + new Vector3 (0, 0.8f, 0), transform.rotation);
						BombChucker.transform.parent = this.transform;
					} 
				} 
					
				canSummonBombChucker = false;
			}

			//second, if we were given the opportunity to summon a spike, we check to see if we summon one;
			if (canSummonSpike) {

				if (GameObject.Find ("BlockArray").GetComponent<BlockArrayControl> ().firstTimeSpike) {

					GameObject Spike = Instantiate (spike, transform.position + new Vector3 (0, 0.8f, 0), transform.rotation);
					Spike.transform.parent = this.transform;
					GameObject.Find ("BlockArray").GetComponent<BlockArrayControl> ().firstTimeSpike = false;
					GameObject.Find ("buttonArray").GetComponent<buttonArray> ().newSpikeAllowed = false;

				} else if (GameObject.Find ("CopterBase").GetComponent<gameTimer> ().gameTime < 440 && GameObject.Find ("buttonArray").GetComponent<buttonArray> ().newSpikeAllowed) { //we dont' summon another spike if one is already on the field

					coinFlip = Random.Range (1, 101);
					if (coinFlip <= 15) {

						GameObject Spike = Instantiate (spike, transform.position + new Vector3 (0, 0.8f, 0), transform.rotation);
						Spike.transform.parent = this.transform;
						GameObject.Find ("buttonArray").GetComponent<buttonArray> ().newSpikeAllowed = false;
					} 
				} else if (GameObject.Find ("CopterBase").GetComponent<gameTimer> ().gameTime >= 440 && GameObject.Find ("buttonArray").GetComponent<buttonArray> ().newSpikeAllowed) {

					coinFlip = Random.Range (1, 101);
					if (coinFlip <= 20) {

						GameObject Spike = Instantiate (spike, transform.position + new Vector3 (0, 0.8f, 0), transform.rotation);
						Spike.transform.parent = this.transform;
						GameObject.Find ("buttonArray").GetComponent<buttonArray> ().newSpikeAllowed = false;
					} 
				} 

				canSummonSpike = false;
			}

			//third, if we were given the opportunity to summon a pillar of fire, we check to see if we summon one;
			if (canSummonPillar) {
				
				if (GameObject.Find ("BlockArray").GetComponent<BlockArrayControl> ().firstTimePillar) {

					GameObject FirePillar = Instantiate (firePillar, transform.position + new Vector3 (0, 0.8f, 0), transform.rotation);
					FirePillar.transform.parent = this.transform;
					GameObject.Find ("BlockArray").GetComponent<BlockArrayControl> ().firstTimePillar = false;

				} else if (GameObject.Find ("CopterBase").GetComponent<gameTimer> ().gameTime < 440) {

					coinFlip = Random.Range (1, 101);
					if (coinFlip <= 15) {

						GameObject FirePillar = Instantiate (firePillar, transform.position + new Vector3 (0, 0.8f, 0), transform.rotation);
						FirePillar.transform.parent = this.transform;
					} 

				} else if (GameObject.Find ("CopterBase").GetComponent<gameTimer> ().gameTime >= 440) {

					coinFlip = Random.Range (1, 101);
					if (coinFlip <= 20) {

						GameObject FirePillar = Instantiate (firePillar, transform.position + new Vector3 (0, 0.8f, 0), transform.rotation);
						FirePillar.transform.parent = this.transform;
					} 
				} 

				canSummonPillar = false;
			}

			//finally, we make the platform move upwards
			transform.position = Vector3.MoveTowards (this.transform.position, originalLocation, 0.06f);

			checkTheTime = true;
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
			GameObject.Find("CopterBase").GetComponent<pointSystem>().accumulateGroundPoints = true;

			//if we're currently standing on a previously-spiked block, our points are doubled
			if (doubleEXP && canDoubleEXP) {
				GameObject.Find("CopterBase").GetComponent<pointSystem>().pointMultiplier *= 2;
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
			GameObject.Find("CopterBase").GetComponent<pointSystem>().accumulateGroundPoints = false;

			//we halve our EXP earnings
			if (doubleEXP && !canDoubleEXP) {
				GameObject.Find("CopterBase").GetComponent<pointSystem>().pointMultiplier /= 2;
				canDoubleEXP = true;
			}
		}
	}
}