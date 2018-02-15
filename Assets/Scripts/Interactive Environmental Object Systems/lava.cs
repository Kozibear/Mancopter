using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour {

	public float lavaNumber;

	public Renderer rend;

	public float alphaValue;

	public bool reduceAlpha;
	public bool increaseAlpha;

	public float flashes;
	public bool currentlyFlashing;

	// Use this for initialization
	void Start () {

		rend = this.GetComponent<Renderer> ();

		alphaValue = 1f;

		rend.material.SetColor ("_Color", new Color (1, 1, 1, alphaValue));

		flashes = 3;
		currentlyFlashing = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (!currentlyFlashing) {
			rend.material.SetColor ("_Color", new Color (1, 1, 1, alphaValue));
		}

		if (reduceAlpha && alphaValue > 0) {
			alphaValue -= 0.055f;
		}
		if (reduceAlpha && alphaValue <= 0) {
			alphaValue = 0;
		}

		if (increaseAlpha && alphaValue < 1) {
			alphaValue += 0.055f;
		}

		if (increaseAlpha && alphaValue >= 1) {
			alphaValue = 1;
		}
			
		if (ButtonsRotationsController.Make1Invisible && lavaNumber == 1) {
			reduceAlpha = true;
			increaseAlpha = false;
		} 

		if (!ButtonsRotationsController.Make1Invisible && lavaNumber == 1) {
			increaseAlpha = true;
			reduceAlpha = false;
		}


		if (ButtonsRotationsController.Make2Invisible && lavaNumber == 2) {
			reduceAlpha = true;
			increaseAlpha = false;
		} 

		if (!ButtonsRotationsController.Make2Invisible && lavaNumber == 2) {
			increaseAlpha = true;
			reduceAlpha = false;
		} 


		if (ButtonsRotationsController.Make3Invisible && lavaNumber == 3) {
			reduceAlpha = true;
			increaseAlpha = false;
		} 

		if (!ButtonsRotationsController.Make3Invisible && lavaNumber == 3) {
			increaseAlpha = true;
			reduceAlpha = false;
		} 


		if (ButtonsRotationsController.Make4Invisible && lavaNumber == 4) {
			reduceAlpha = true;
			increaseAlpha = false;
		} 

		if (!ButtonsRotationsController.Make4Invisible && lavaNumber == 4) {
			increaseAlpha = true;
			reduceAlpha = false;
		} 


		if (ButtonsRotationsController.Make5Invisible && lavaNumber == 5) {
			reduceAlpha = true;
			increaseAlpha = false;
		} 

		if (!ButtonsRotationsController.Make5Invisible && lavaNumber == 5) {
			increaseAlpha = true;
			reduceAlpha = false;
		} 


		if (ButtonsRotationsController.Make6Invisible && lavaNumber == 6) {
			reduceAlpha = true;
			increaseAlpha = false;
		} 

		if (!ButtonsRotationsController.Make6Invisible && lavaNumber == 6) {
			increaseAlpha = true;
			reduceAlpha = false;
		} 
	}

	public IEnumerator Flashing()
	{
		currentlyFlashing = true;

		yield return new WaitForSeconds (0.2f);

		rend.material.SetColor ("_Color", new Color (0, 1, 0, 1));

		yield return new WaitForSeconds (0.2f);

		flashes -= 1;
		rend.material.SetColor ("_Color", new Color (1, 1, 1, alphaValue));

		if (flashes != 0) {
			StartCoroutine (Flashing());
		} 
		else {
			flashes = 3;
			currentlyFlashing = false;
			yield return null;
		}
	}
}
