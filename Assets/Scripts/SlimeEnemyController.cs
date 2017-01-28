using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy Movement
public class SlimeEnemyController : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody2D slimeRigidbody;

	//if the slime it's moving
	private bool moving;
	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;

	//Direction where it moves
	private Vector3 moveDirection;

	//Time to reload the level
	public float waitToReload;
	private bool reloading;
	private GameObject thePlayer;

	// Use this for initialization
	void Start () {

		slimeRigidbody = GetComponent<Rigidbody2D>();

		//timeBetweenMoveCounter = timeBetweenMove;
		//timeToMoveCounter = timeToMove;

		//The counter will random for random movement
		timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		/*
		 * If moving it's true will be set in false but will deteminate the time to the next move,
		 * now moving it's false will freez the velocity of the enemy, will set moving to true, will
		 * the range to the next move and the direction and the distance of the enemy movement.
		*/

		if(moving) {

			timeToMoveCounter -= Time.deltaTime;
			slimeRigidbody.velocity = moveDirection;

			if (timeToMoveCounter < 0f) {
				moving = false;
				//timeBetweenMoveCounter = timeBetweenMove;
				timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			}
		}
		else {

			timeBetweenMoveCounter -= Time.deltaTime;
			slimeRigidbody.velocity = Vector2.zero;

			if(timeBetweenMoveCounter < 0f) {
				moving = true;
				//timeToMoveCounter = timeToMove;
				timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);

				moveDirection = new Vector3(Random.Range(-1.0f, 1.0f) * moveSpeed, Random.Range(-1.0f, 1.0f) * moveSpeed, 0);
			}
		}


		//If it's true reload the level
		if(reloading) {
			
			waitToReload -= Time.deltaTime;
			if(waitToReload < 0) {
				Application.LoadLevel (Application.loadedLevel);
				thePlayer.SetActive (true);
			}
		}
		
	}

	//Collision between colliders
	void OnCollisionEnter2D(Collision2D collider) {

		//If the two colliders touch Insta kill
		/*
		if (collider.gameObject.tag == "Player" && collider.gameObject.name == "Player") {
			//Deactivates the player
			collider.gameObject.SetActive (false);
			Debug.Log ("You Hit me, man...");
			reloading = true;
			thePlayer = collider.gameObject;
		}*/
	}
}
