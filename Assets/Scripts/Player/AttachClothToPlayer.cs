using UnityEngine;
using System.Collections;

public class AttachClothToPlayer : MonoBehaviour {
	public PlayerMovement playerMovement;
	public Sprite movLeft; 
	public Sprite movRight; 
	public Sprite movUp; 
	public Sprite movDown; 
	private SpriteRenderer spriteRenderer;



	// Use this for initialization
	void Start () {
		GameObject go = GameObject.Find("human_20");
		playerMovement = (PlayerMovement) go.GetComponent(typeof(PlayerMovement));
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update () {
		changeClothDirection();

	}
	//changes facing direction of worn clothing item
	void changeClothDirection(){
		if (playerMovement.isFacing == "Right")
			spriteRenderer.sprite = movRight;
		else if (playerMovement.isFacing == "Up")
			spriteRenderer.sprite = movUp;
		else if (playerMovement.isFacing == "Left")
			spriteRenderer.sprite = movLeft;
		else if (playerMovement.isFacing == "Down")
			spriteRenderer.sprite = movDown;
	}
}
