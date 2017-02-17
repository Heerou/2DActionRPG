using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Speed of the player
	public float moveSpeed;
	private float currentMoveSpeed;
	public float diagonalMoveModifier;

	//Player animator
	private Animator playerAnim;
	//Player RigidBody
	private Rigidbody2D playerRigidBody;
	//If the player is facing to some direction
	private bool playerMoving;
	//Record the las direction of the player
	public Vector2 lastMovement;
	//If the player exist. static makes that only the one that have the script added has the bool
	private static bool playerExists;
	//If the player it's attacking
	private bool playerAttack;
	public float playerAttackTime;
	private float playerAttackTimeCounter;

	//Start point of the player
	public string startPoint;

	// Use this for initialization
	void Start () {

		//I get the animator in the player
		playerAnim = GetComponent<Animator> ();

		playerRigidBody = GetComponent<Rigidbody2D> ();

		if (!playerExists) {
			playerExists = true;
			//Doesn't destroy object when the scene loads
			DontDestroyOnLoad (transform.gameObject);
		}
		else {
			Destroy (gameObject);
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		playerMoving = false;

		//If the player it's not attacking he does not move
		if (!playerAttack) {		
			//Here i make an tranlate to move the player getting the axis

			//Moving to the right and the left
			if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
				//transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));

				//With the rigid body i don't need the tranlate and this removes the bounce with the collider
				playerRigidBody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * currentMoveSpeed, playerRigidBody.velocity.y);
				playerMoving = true;
				lastMovement = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
			}

			//Moving up and Down
			if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
				//transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));

				playerRigidBody.velocity = new Vector2 (playerRigidBody.velocity.x, Input.GetAxisRaw ("Vertical") * currentMoveSpeed);
				playerMoving = true;
				lastMovement = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
			}

			//If the player it's not moving it stops
			if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f)
				playerRigidBody.velocity = new Vector2 (0f, playerRigidBody.velocity.y);

			if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f)
				playerRigidBody.velocity = new Vector2 (playerRigidBody.velocity.x, 0f);

			//If i press Z he attacks
			if (Input.GetKeyDown (KeyCode.Z)) {
				playerAttackTimeCounter = playerAttackTime;
				playerAttack = true;
				playerRigidBody.velocity = Vector2.zero;
				playerAnim.SetBool ("PlayerAttacking", true);
			}

			//Takes the valor of the axis and return in absolute, so i know if it's 1 or 0
			if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) > 0.5f && Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0.5f) {
				//If there's any movement will slow 'cause we're moving diagonal
				currentMoveSpeed = moveSpeed * diagonalMoveModifier;
			}
			else {
				currentMoveSpeed = moveSpeed;
			}
		}

		//When the counter it's greater he will go back to 0
		if(playerAttackTimeCounter > 0){
			playerAttackTimeCounter -= Time.deltaTime;
		}
		//Resets the player Animation
		if (playerAttackTimeCounter <= 0){
			playerAttack = false;
			playerAnim.SetBool ("PlayerAttacking", false);
		}

		//Here it's where i ser the animator
		playerAnim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		playerAnim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		playerAnim.SetBool ("PlayerMoving", playerMoving);
		playerAnim.SetFloat ("LastMoveX", lastMovement.x);
		playerAnim.SetFloat ("LastMoveY", lastMovement.y);
	}
}
