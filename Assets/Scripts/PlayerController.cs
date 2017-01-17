using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Speed of the player
	public float moveSpeed;

	//Player animator
	private Animator playerAnim;
	//Player RigidBody
	private Rigidbody2D playerRigidBody;
	//If the player is facing to some direction
	private bool playerMoving;
	//Record the las direction of the player
	private Vector2 lastMovement;

	// Use this for initialization
	void Start () {

		//I get the animator in the player
		playerAnim = GetComponent<Animator> ();

		playerRigidBody = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		playerMoving = false;

//Here i make an tranlate to move the player getting the axis

		//Moving to the right and the left
		if(Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f){
			//transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));

			//With the rigid body i don't need the tranlate and this removes the bounce with the collider
			playerRigidBody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * moveSpeed, playerRigidBody.velocity.y);
			playerMoving = true;
			lastMovement = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
		}

		//Moving up and Down
		if(Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f){
			//transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));

			playerRigidBody.velocity = new Vector2 (playerRigidBody.velocity.x, Input.GetAxisRaw ("Vertical") * moveSpeed);
			playerMoving = true;
			lastMovement = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
		}

		//If the player it's not moving it stops
		if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f)
			playerRigidBody.velocity = new Vector2 (0f, playerRigidBody.velocity.y);

		if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f)
			playerRigidBody.velocity = new Vector2 (playerRigidBody.velocity.x, 0f );

		//Here it's where i ser the animator
		playerAnim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		playerAnim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		playerAnim.SetBool ("PlayerMoving", playerMoving);
		playerAnim.SetFloat ("LastMoveX", lastMovement.x);
		playerAnim.SetFloat ("LastMoveY", lastMovement.y);
	}
}
