using UnityEngine;
using System.Collections;
[@RequireComponent(typeof(BoxCollider2D))]

public class PlayerMovement : MonoBehaviour
{
	public float walkSpeed = 3f;
	RaycastHit2D hit;
	BoxCollider2D boxCollider;
	public Sprite movLeft; 
	public Sprite movRight; 
	public Sprite movUp; 
	public Sprite movDown; 
	public string isFacing;

	private SpriteRenderer spriteRenderer;


	
	void Start()
	{
		boxCollider = GetComponent<BoxCollider2D>();
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
	}

	void Update () {
		ChangeMovementSprite();
		
	}
		

	void FixedUpdate()
	{


		var direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * walkSpeed * Time.deltaTime;

			hit = Physics2D.BoxCast (transform.position, boxCollider.size, 0, new Vector2 (0, direction.y), Mathf.Abs (direction.y));

		if (hit.collider == null || hit.collider.gameObject.tag == "Object")
		{
			transform.Translate(0, direction.y, 0);
		}
		
			hit = Physics2D.BoxCast (transform.position, boxCollider.size, 0, new Vector2 (direction.x, 0), Mathf.Abs (direction.x));
		
if (hit.collider == null || hit.collider.gameObject.tag == "Object")
		{
			transform.Translate(direction.x, 0, 0);
		}

	}

	public void ChangeMovementSprite ()
	{
		var vertical = GetVertical ();
		var horizontal = GetHorizontal ();

		
		if (horizontal > 0) {
			spriteRenderer.sprite = movRight;
			isFacing = "Right";
		} else if (vertical > 0) {
			spriteRenderer.sprite = movUp;
			isFacing = "Up";

		} else if (horizontal < 0) {
			spriteRenderer.sprite = movLeft;
			isFacing = "Left";
		} else if (vertical < 0) {
			spriteRenderer.sprite = movDown;
			isFacing = "Down";
		}
	}
	public float GetVertical(){
		var vertical = Input.GetAxis("Vertical");
		return vertical;
	}
	public float GetHorizontal(){
		var horizontal = Input.GetAxis("Horizontal");
		return horizontal;
	}

}