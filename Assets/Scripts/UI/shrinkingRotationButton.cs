using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shrinkingRotationButton : MonoBehaviour {

	public Button thisButton;

	public float reduction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		this.transform.localScale -= new Vector3 (reduction, reduction, reduction);

		if (this.transform.localScale.x <= 0.1f) {
			Destroy (gameObject);
		}
	}

	public void addToReduction () {
		reduction += 0.0005f;
	}

	public void takeFromReduction () {
		if (reduction != 0) {
			reduction -= 0.0005f;

			if (reduction < 0) {
				reduction = 0;
			}
		}


	}
}
