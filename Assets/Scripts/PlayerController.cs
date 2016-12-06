using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Speed of the player
	public float moveSpeed;

	//Player animator
	private Animator playerAnim;

	// Use this for initialization
	void Start () {

		//I get the animator in the player
		playerAnim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {

//Here i make an tranlate to move the player getting the axis

		//Moving to the right and the left
		if(Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f){
			transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
		}

		//Moving up and Down
		if(Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f){
			transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));
		}

		playerAnim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		playerAnim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
	}
}
