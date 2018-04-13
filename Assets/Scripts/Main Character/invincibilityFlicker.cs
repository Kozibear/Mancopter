using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincibilityFlicker : MonoBehaviour {

	public SpriteRenderer spriteRenderer;

	public Color transparentColor;

	public bool alternateTransparency;

	// Use this for initialization
	void Start () {
		spriteRenderer = this.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		/*
		if (Health.spritesDamageFlash && gameTimer.gameTime > 0) {
			
			if (alternateTransparency) {
				transparentColor = spriteRenderer.color;
				transparentColor.a = 0.6f;
				spriteRenderer.color = transparentColor;
				alternateTransparency = false;
			}
			else if (!alternateTransparency) {
				transparentColor = spriteRenderer.color;
				transparentColor.a = 0.9f;
				spriteRenderer.color = transparentColor;
				alternateTransparency = true;
			}
		}
		if (!Health.spritesDamageFlash) {
			
			transparentColor = spriteRenderer.color;
			transparentColor.a = 1f;
			spriteRenderer.color = transparentColor;
		}
		*/

		this.GetComponent<SpriteRenderer> ().color = spriteRenderer.color;
	}
}
