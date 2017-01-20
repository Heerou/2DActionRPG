using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	// Use this for initialization
	void Start () {

		slimeRigidbody = GetComponent<Rigidbody2D>();

		timeBetweenMoveCounter = timeBetweenMove;
		timeToMoveCounter = timeToMove;
		
	}
	
	// Update is called once per frame
	void Update () {

		if(moving){

			timeToMoveCounter -= Time.deltaTime;
			slimeRigidbody.velocity = moveDirection;

			if (timeBetweenMoveCounter < 0f){
				moving = false;
				timeBetweenMoveCounter = timeBetweenMove;
			}
		}
		else{

			timeBetweenMoveCounter -= Time.deltaTime;
			slimeRigidbody.velocity = Vector2.zero;

			if(timeBetweenMoveCounter < 0f){
				moving = true;
				timeToMoveCounter = timeToMove;

				moveDirection = new Vector3 (Random.Range(-1f, 1f)* moveSpeed, Random.Range(-1f, 1f)*moveSpeed, 0f);
			}
		}
		
	}
}
