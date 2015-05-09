using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {
	int inventorySize = 10;
	int inventoryOccupied;
	GameObject headSlot;
	GameObject suitSlot;
	GameObject leftHand;
	GameObject rightHand;
	GameObject backSlot;
	List<GameObject> itemInInventory = new List<GameObject>();
	GameObject inLeftHand;
	GameObject inRightHand;

	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		pickupObjectToHand();
	}
	//picks up object to selected hand if empty
	void pickupObjectToHand(){
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			if (hit.collider != null) {
				if (hit.collider.gameObject.tag == "Object"){
					if(rightHand == null){
						inRightHand = hit.collider.gameObject;
					}

				}
			}
			
		}
	}
	//Adds object to an empty UI slot or backpack;
	void pickupObjectToEmptySlot(){
		RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
		if (hit.collider != null) {
			itemInInventory.Add (hit.collider.gameObject);
			inventoryOccupied++;
			Debug.Log (inventoryOccupied);
		}
	}

	void checkBacpack(){
	}
}