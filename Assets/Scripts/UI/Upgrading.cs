using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrading : MonoBehaviour {

	public Button item1;
	public Button item2;
	public Button item3;
	public Button item4;
	public Button item5;
	public Button item6;
	public Button item7;
	public Button item8;
	public Button item9;
	public Button item10;
	public Button item11;
	public Button item12;
	public Button item13;
	public Button item14;
	public Button item15;
	public Button item16;
	public Button item17;
	public Button item18;
	public Button item19;
	public Button item20;

	public Sprite greenLock;
	public Sprite redLock;
	public Sprite equippedItem;

	public Text itemDescription;
	public Text currentPoints;

	public float points;

	public float cost1;
	public float cost2;
	public float cost3;
	public float cost4;
	public float cost5;
	public float cost6;
	public float cost7;
	public float cost8;
	public float cost9;
	public float cost10;
	public float cost11;
	public float cost12;
	public float cost13;
	public float cost14;
	public float cost15;
	public float cost16;
	public float cost17;
	public float cost18;
	public float cost19;
	public float cost20;

	public GameObject sceneManager;

	// Use this for initialization
	void Start () {
		item1.onClick.AddListener (clickItem1);
		item2.onClick.AddListener (clickItem2);
		item3.onClick.AddListener (clickItem3);
		item4.onClick.AddListener (clickItem4);
		item5.onClick.AddListener (clickItem5);
		item6.onClick.AddListener (clickItem6);
		item7.onClick.AddListener (clickItem7);
		item8.onClick.AddListener (clickItem8);
		item9.onClick.AddListener (clickItem9);
		item10.onClick.AddListener (clickItem10);
		item11.onClick.AddListener (clickItem11);
		item12.onClick.AddListener (clickItem12);
		item13.onClick.AddListener (clickItem13);
		item14.onClick.AddListener (clickItem14);
		item15.onClick.AddListener (clickItem15);
		item16.onClick.AddListener (clickItem16);
		item17.onClick.AddListener (clickItem17);
		item18.onClick.AddListener (clickItem18);
		item19.onClick.AddListener (clickItem19);
		item20.onClick.AddListener (clickItem20);

		itemDescription.text = "";
	}
	
	void clickItem1()
	{
		if (GameSave.gameSave.powerup1 == 0 && points >= cost1) {
			GameSave.gameSave.powerup1 = 1;
			GameSave.gameSave.Save ();
			points -= cost1;
		}
		else if (GameSave.gameSave.powerup1 == 1) {

			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup1 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}

		}
		else if (GameSave.gameSave.powerup1 == 2) {
			GameSave.gameSave.powerup1 = 1;
			GameSave.gameSave.Save ();
		}
	}

	void clickItem2()
	{
		if (GameSave.gameSave.powerup2 == 0 && points >= cost2) {
			GameSave.gameSave.powerup2 = 1;
			GameSave.gameSave.Save ();
			points -= cost2;
		}
		else if (GameSave.gameSave.powerup2 == 1) {
			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup2 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}
		}
		else if (GameSave.gameSave.powerup2 == 2) {
			GameSave.gameSave.powerup2 = 1;
			GameSave.gameSave.Save ();
		}
	}

	void clickItem3()
	{
		if (GameSave.gameSave.powerup3 == 0 && points >= cost3) {
			GameSave.gameSave.powerup3 = 1;
			GameSave.gameSave.Save ();
			points -= cost3;
		}
		else if (GameSave.gameSave.powerup3 == 1) {
			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup3 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}
		}
		else if (GameSave.gameSave.powerup3 == 2) {
			GameSave.gameSave.powerup3 = 1;
			GameSave.gameSave.Save ();
		}
	}

	void clickItem4()
	{
		if (GameSave.gameSave.powerup4 == 0 && points >= cost4) {
			GameSave.gameSave.powerup4 = 1;
			GameSave.gameSave.Save ();
			points -= cost4;
		}
		else if (GameSave.gameSave.powerup4 == 1) {
			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup4 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}
		}
		else if (GameSave.gameSave.powerup4 == 2) {
			GameSave.gameSave.powerup4 = 1;
			GameSave.gameSave.Save ();
		}
	}

	void clickItem5()
	{
		if (GameSave.gameSave.powerup5 == 0 && points >= cost5) {
			GameSave.gameSave.powerup5 = 1;
			GameSave.gameSave.Save ();
			points -= cost5;
		}
		else if (GameSave.gameSave.powerup5 == 1) {
			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup5 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}
		}
		else if (GameSave.gameSave.powerup5 == 2) {
			GameSave.gameSave.powerup5 = 1;
			GameSave.gameSave.Save ();
		}
	}

	void clickItem6()
	{
		if (GameSave.gameSave.powerup6 == 0 && points >= cost6) {
			GameSave.gameSave.powerup6 = 1;
			GameSave.gameSave.Save ();
			points -= cost6;
		}
		else if (GameSave.gameSave.powerup6 == 1) {
			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup6 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}
		}
		else if (GameSave.gameSave.powerup6 == 2) {
			GameSave.gameSave.powerup6 = 1;
			GameSave.gameSave.Save ();
		}
	}

	void clickItem7()
	{
		if (GameSave.gameSave.powerup7 == 0 && points >= cost7) {
			GameSave.gameSave.powerup7 = 1;
			GameSave.gameSave.Save ();
			points -= cost7;
		}
		else if (GameSave.gameSave.powerup7 == 1) {
			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup7 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}
		}
		else if (GameSave.gameSave.powerup7 == 2) {
			GameSave.gameSave.powerup7 = 1;
			GameSave.gameSave.Save ();
		}
	}

	void clickItem8()
	{
		if (GameSave.gameSave.powerup8 == 0 && points >= cost8) {
			GameSave.gameSave.powerup8 = 1;
			GameSave.gameSave.Save ();
			points -= cost8;
		}
		else if (GameSave.gameSave.powerup8 == 1) {
			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup8 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}
		}
		else if (GameSave.gameSave.powerup8 == 2) {
			GameSave.gameSave.powerup8 = 1;
			GameSave.gameSave.Save ();
		}
	}

	void clickItem9()
	{
		if (GameSave.gameSave.powerup9 == 0 && points >= cost9) {
			GameSave.gameSave.powerup9 = 1;
			GameSave.gameSave.Save ();
			points -= cost9;
		}
		else if (GameSave.gameSave.powerup9 == 1) {
			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup9 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}
		}
		else if (GameSave.gameSave.powerup9 == 2) {
			GameSave.gameSave.powerup9 = 1;
			GameSave.gameSave.Save ();
		}
	}

	void clickItem10()
	{
		if (GameSave.gameSave.powerup10 == 0 && points >= cost10) {
			GameSave.gameSave.powerup10 = 1;
			GameSave.gameSave.Save ();
			points -= cost10;
		}
		else if (GameSave.gameSave.powerup10 == 1) {
			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup10 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}
		}
		else if (GameSave.gameSave.powerup1 == 2) {
			GameSave.gameSave.powerup10 = 1;
			GameSave.gameSave.Save ();
		}
	}

	void clickItem11()
	{
		if (GameSave.gameSave.powerup11 == 0 && points >= cost11) {
			GameSave.gameSave.powerup11 = 1;
			GameSave.gameSave.Save ();
			points -= cost11;
		}
		else if (GameSave.gameSave.powerup11 == 1) {
			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup11 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}
		}
		else if (GameSave.gameSave.powerup11 == 2) {
			GameSave.gameSave.powerup11 = 1;
			GameSave.gameSave.Save ();
		}
	}

	void clickItem12()
	{
		if (GameSave.gameSave.powerup12 == 0 && points >= cost12) {
			GameSave.gameSave.powerup12 = 1;
			GameSave.gameSave.Save ();
			points -= cost12;
		}
		else if (GameSave.gameSave.powerup12 == 1) {
			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup12 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}
		}
		else if (GameSave.gameSave.powerup12 == 2) {
			GameSave.gameSave.powerup12 = 1;
			GameSave.gameSave.Save ();
		}
	}

	void clickItem13()
	{
		if (GameSave.gameSave.powerup13 == 0 && points >= cost13) {
			GameSave.gameSave.powerup13 = 1;
			GameSave.gameSave.Save ();
			points -= cost13;
		}
		else if (GameSave.gameSave.powerup13 == 1) {
			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup13 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}
		}
		else if (GameSave.gameSave.powerup13 == 2) {
			GameSave.gameSave.powerup13 = 1;
			GameSave.gameSave.Save ();
		}
	}

	void clickItem14()
	{
		if (GameSave.gameSave.powerup14 == 0 && points >= cost14) {
			GameSave.gameSave.powerup14 = 1;
			GameSave.gameSave.Save ();
			points -= cost14;
		}
		else if (GameSave.gameSave.powerup14 == 1) {
			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup14 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}
		}
		else if (GameSave.gameSave.powerup14 == 2) {
			GameSave.gameSave.powerup14 = 1;
			GameSave.gameSave.Save ();
		}
	}


	void clickItem15()
	{
		if (GameSave.gameSave.powerup15 == 0 && points >= cost15) {
			GameSave.gameSave.powerup15 = 1;
			GameSave.gameSave.Save ();
			points -= cost15;
		}
		else if (GameSave.gameSave.powerup15 == 1) {
			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup15 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}
		}
		else if (GameSave.gameSave.powerup15 == 2) {
			GameSave.gameSave.powerup15 = 1;
			GameSave.gameSave.Save ();
		}
	}

	void clickItem16()
	{
		if (GameSave.gameSave.powerup16 == 0 && points >= cost16) {
			GameSave.gameSave.powerup16 = 1;
			GameSave.gameSave.Save ();
			points -= cost16;
		}
		else if (GameSave.gameSave.powerup16 == 1) {
			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup16 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}
		}
		else if (GameSave.gameSave.powerup16 == 2) {
			GameSave.gameSave.powerup16 = 1;
			GameSave.gameSave.Save ();
		}
	}

	void clickItem17()
	{
		if (GameSave.gameSave.powerup17 == 0 && points >= cost17) {
			GameSave.gameSave.powerup17 = 1;
			GameSave.gameSave.Save ();
			points -= cost17;
		}
		else if (GameSave.gameSave.powerup17 == 1) {
			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup17 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}
		}
		else if (GameSave.gameSave.powerup17 == 2) {
			GameSave.gameSave.powerup17 = 1;
			GameSave.gameSave.Save ();
		}
	}

	void clickItem18()
	{
		if (GameSave.gameSave.powerup18 == 0 && points >= cost18) {
			GameSave.gameSave.powerup18 = 1;
			GameSave.gameSave.Save ();
			points -= cost18;
		}
		else if (GameSave.gameSave.powerup18 == 1) {
			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup18 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}
		}
		else if (GameSave.gameSave.powerup18 == 2) {
			GameSave.gameSave.powerup18 = 1;
			GameSave.gameSave.Save ();
		}
	}

	void clickItem19()
	{
		if (GameSave.gameSave.powerup19 == 0 && points >= cost19) {
			GameSave.gameSave.powerup19 = 1;
			GameSave.gameSave.Save ();
			points -= cost19;
		}
		else if (GameSave.gameSave.powerup19 == 1) {
			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup19 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}
		}
		else if (GameSave.gameSave.powerup19 == 2) {
			GameSave.gameSave.powerup19 = 1;
			GameSave.gameSave.Save ();
		}
	}

	void clickItem20()
	{
		if (GameSave.gameSave.powerup20 == 0 && points >= cost20) {
			GameSave.gameSave.powerup20 = 1;
			GameSave.gameSave.Save ();
			points -= cost20;
		}
		else if (GameSave.gameSave.powerup20 == 1) {
			if (sceneManager.GetComponent<sceneManagerSplash> ().checkEquippedNumber ()) {
				GameSave.gameSave.powerup20 = 2;
				GameSave.gameSave.Save ();
			} 
			else {
			}
		}
		else if (GameSave.gameSave.powerup20 == 2) {
			GameSave.gameSave.powerup20 = 1;
			GameSave.gameSave.Save ();
		}
	}

	public void hoverItem1()
	{
		itemDescription.text = "Cost: X";
	}

	public void hoverItem2()
	{
		itemDescription.text = "Cost: X";
	}

	public void hoverItem3()
	{
		itemDescription.text = "Cost: X";
	}

	public void hoverItem4()
	{
		itemDescription.text = "Cost: X";
	}

	public void hoverItem5()
	{
		itemDescription.text = "Cost: X";
	}

	public void hoverItem6()
	{
		itemDescription.text = "Cost: X";
	}

	public void hoverItem7()
	{
		itemDescription.text = "Cost: X";
	}

	public void hoverItem8()
	{
		itemDescription.text = "Cost: X";
	}

	public void hoverItem9()
	{
		itemDescription.text = "Cost: X";
	}

	public void hoverItem10()
	{
		itemDescription.text = "Cost: X";
	}

	public void hoverItem11()
	{
		itemDescription.text = "Cost: X";
	}

	public void hoverItem12()
	{
		itemDescription.text = "Cost: X";
	}

	public void hoverItem13()
	{
		itemDescription.text = "Cost: X";
	}

	public void hoverItem14()
	{
		itemDescription.text = "Cost: X";
	}

	public void hoverItem15()
	{
		itemDescription.text = "Cost: X";
	}

	public void hoverItem16()
	{
		itemDescription.text = "Cost: X";
	}

	public void hoverItem17()
	{
		itemDescription.text = "Cost: X";
	}

	public void hoverItem18()
	{
		itemDescription.text = "Cost: X";
	}

	public void hoverItem19()
	{
		itemDescription.text = "Cost: X";
	}

	public void hoverItem20()
	{
		itemDescription.text = "Cost: X";
	}

	public void exitHover () 
	{
		itemDescription.text = "";
	}

	// Update is called once per frame
	void FixedUpdate () {

		currentPoints.text = "Points: " + points.ToString ();

		//1
		if (GameSave.gameSave.powerup1 == 0) {
			if (points < cost1) {
				item1.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost1) {
				item1.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup1 == 1) {
			item1.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup1 == 2) {
			item1.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}

		//2
		if (GameSave.gameSave.powerup2 == 0) {
			if (points < cost2) {
				item2.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost2) {
				item2.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup2 == 1) {
			item2.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup2 == 2) {
			item2.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}

		//3
		if (GameSave.gameSave.powerup3 == 0) {
			if (points < cost3) {
				item3.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost3) {
				item3.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup3 == 1) {
			item3.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup3 == 2) {
			item3.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}

		//4
		if (GameSave.gameSave.powerup4 == 0) {
			if (points < cost4) {
				item4.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost4) {
				item4.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup4 == 1) {
			item4.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup4 == 2) {
			item4.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}

		//5
		if (GameSave.gameSave.powerup5 == 0) {
			if (points < cost5) {
				item5.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost5) {
				item5.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup5 == 1) {
			item5.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup5 == 2) {
			item5.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}

		//6
		if (GameSave.gameSave.powerup6 == 0) {
			if (points < cost6) {
				item6.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost6) {
				item6.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup6 == 1) {
			item6.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup6 == 2) {
			item6.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}

		//7
		if (GameSave.gameSave.powerup7 == 0) {
			if (points < cost7) {
				item7.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost7) {
				item7.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup7 == 1) {
			item7.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup7 == 2) {
			item7.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}

		//8
		if (GameSave.gameSave.powerup8 == 0) {
			if (points < cost8) {
				item8.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost8) {
				item8.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup8 == 1) {
			item8.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup8 == 2) {
			item8.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}

		//9
		if (GameSave.gameSave.powerup9 == 0) {
			if (points < cost9) {
				item9.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost9) {
				item9.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup9 == 1) {
			item9.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup9 == 2) {
			item9.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}

		//10
		if (GameSave.gameSave.powerup10 == 0) {
			if (points < cost10) {
				item10.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost10) {
				item10.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup10 == 1) {
			item10.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup10 == 2) {
			item10.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}

		//11
		if (GameSave.gameSave.powerup11 == 0) {
			if (points < cost11) {
				item11.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost11) {
				item11.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup11 == 1) {
			item11.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup11 == 2) {
			item11.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}

		//12
		if (GameSave.gameSave.powerup12 == 0) {
			if (points < cost12) {
				item12.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost12) {
				item12.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup12 == 1) {
			item12.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup12 == 2) {
			item12.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}

		//13
		if (GameSave.gameSave.powerup13 == 0) {
			if (points < cost13) {
				item13.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost13) {
				item13.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup13 == 1) {
			item13.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup13 == 2) {
			item13.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}

		//14
		if (GameSave.gameSave.powerup14 == 0) {
			if (points < cost14) {
				item14.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost14) {
				item14.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup14 == 1) {
			item14.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup14 == 2) {
			item14.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}

		//15
		if (GameSave.gameSave.powerup15 == 0) {
			if (points < cost15) {
				item15.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost15) {
				item15.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup15 == 1) {
			item15.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup15 == 2) {
			item15.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}

		//16
		if (GameSave.gameSave.powerup16 == 0) {
			if (points < cost16) {
				item16.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost16) {
				item16.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup16 == 1) {
			item16.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup16 == 2) {
			item16.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}

		//17
		if (GameSave.gameSave.powerup17 == 0) {
			if (points < cost17) {
				item17.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost17) {
				item17.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup17 == 1) {
			item17.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup17 == 2) {
			item17.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}

		//18
		if (GameSave.gameSave.powerup18 == 0) {
			if (points < cost18) {
				item18.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost18) {
				item18.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup18 == 1) {
			item18.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup18 == 2) {
			item18.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}

		//19
		if (GameSave.gameSave.powerup19 == 0) {
			if (points < cost19) {
				item19.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost19) {
				item19.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup19 == 1) {
			item19.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup19 == 2) {
			item19.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}

		//20
		if (GameSave.gameSave.powerup20 == 0) {
			if (points < cost20) {
				item20.transform.GetChild (1).GetComponent<Image> ().sprite = redLock;
			}

			if (points >= cost20) {
				item20.transform.GetChild (1).GetComponent<Image> ().sprite = greenLock;
			}
		}
		else if (GameSave.gameSave.powerup20 == 1) {
			item20.transform.GetChild (1).GetComponent<Image> ().sprite = null;
		}
		else if (GameSave.gameSave.powerup20 == 2) {
			item20.transform.GetChild (1).GetComponent<Image> ().sprite = equippedItem;
		}
			
	}

	void OnEnable() {
		GameSave.gameSave.Load();

		currentPoints.text = "Points: " + points.ToString ();
	
	}
}
