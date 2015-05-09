using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {
	int inventorySize = 10;
	int inventoryOccupied;
	bool headSlot;
	bool suitSlot;
	bool leftHand;
	bool rightHand;
	List<GameObject> itemInInventory = new List<GameObject>(); 
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		mouseClick();
	}

	void mouseClick(){
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			if (hit.collider != null) {
				if (hit.collider.gameObject.tag == "Object"){
					itemInInventory.Add(hit.collider.gameObject);
					inventoryOccupied++;
					Debug.Log (inventoryOccupied);
				}
			}
			
		}
	}
}