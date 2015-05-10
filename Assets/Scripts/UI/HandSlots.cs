using UnityEngine;
using System.Collections;

public class HandSlots : MonoBehaviour {
	GameObject lefthand;
	GameObject righthand;
	SpriteRenderer lefthandSprite;
	SpriteRenderer righthandSprite;
	public Sprite leftOn; 
	public Sprite rightOn;
	public Sprite leftOff; 
	public Sprite rightOff;
	private SpriteRenderer spriteRenderer;
	bool leftToggle = false;


	// Use this for initialization
	void Start () {
		lefthand = GameObject.Find ("lefthand_slot");
		righthand = GameObject.Find ("righthand_slot");
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		SelectHand();
	}

	void SelectHand(){
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			if (hit.collider != null && hit.collider.gameObject.tag == "UI") {
				var hand = hit.collider.gameObject;
				if (hand == lefthand && leftToggle){
					spriteRenderer.sprite = leftOn;
					leftToggle = true;
					rightToggle = false;
				}else if(hand  == lefthand && gameObject.name == "lefthand_slot" && leftToggle == true){
					spriteRenderer.sprite = leftOff;
					leftToggle = false;
					rightToggle = true;
				}

				if(hand == righthand && gameObject.name == "righthand_slot" && rightToggle == false)
				{
					spriteRenderer.sprite = rightOn;
					rightToggle = true;
					leftToggle = false;
				}else if(hand == righthand && gameObject.name == "righthand_slot" && rightToggle == true){
					spriteRenderer.sprite = rightOff;
					leftToggle = true;
					rightToggle = false;
				}
			}
		}

	}
	               

}
