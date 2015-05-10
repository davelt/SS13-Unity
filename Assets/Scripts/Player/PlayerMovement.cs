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

	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector2 syncStartPosition = Vector3.zero;
	private Vector2 syncEndPosition = Vector3.zero;

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
		if (GetComponent<NetworkView>().isMine) {
			move ();
		} else
		{
			SyncedMovement();
		}
	}

	void move(){
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
	//changes sprite when player is turning
	public void ChangeMovementSprite ()
	{
		
		if (Input.GetKeyDown ("d")) {
			spriteRenderer.sprite = movRight;
			isFacing = "Right";
		} else if (Input.GetKeyDown ("w")) {
			spriteRenderer.sprite = movUp;
			isFacing = "Up";

		} else if (Input.GetKeyDown ("a")) {
			spriteRenderer.sprite = movLeft;
			isFacing = "Left";
		} else if (Input.GetKeyDown ("s")) {
			spriteRenderer.sprite = movDown;
			isFacing = "Down";
		}
	}
	//returns vertical and horzontal positions of the player
	public float GetVertical(){
		var vertical = Input.GetAxis("Vertical");
		return vertical;
	}
	public float GetHorizontal(){
		var horizontal = Input.GetAxis("Horizontal");
		return horizontal;
	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		Vector3 syncPosition = Vector3.zero;
		Vector3 syncVelocity = Vector3.zero;
		if (stream.isWriting)
		{
			syncPosition = GetComponent<Rigidbody>().position;
			stream.Serialize(ref syncPosition);
			
			syncVelocity = GetComponent<Rigidbody>().velocity;
			stream.Serialize(ref syncVelocity);
		}
		else
		{
			stream.Serialize(ref syncPosition);
			stream.Serialize(ref syncVelocity);
			
			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;
			
			syncEndPosition = syncPosition + syncVelocity * syncDelay;
			syncStartPosition = GetComponent<Rigidbody>().position;
		}
	}

	private void SyncedMovement()
	{
		syncTime += Time.deltaTime;
		GetComponent<Rigidbody>().position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
	}
}