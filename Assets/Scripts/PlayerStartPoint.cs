using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

	private PlayerController thePlayer;
	private CameraController theCamera;

	public Vector2 startDirection;

	//Where the player starts
	public string pointName;

	// Use this for initialization
	void Start () {

		//Finds and object that haves the player attached
		thePlayer = FindObjectOfType<PlayerController> ();

		if (thePlayer.startPoint == pointName) {		
			//I make the player start where the start point is
			thePlayer.transform.position = transform.position;
			//Last player position
			thePlayer.lastMovement = startDirection;


			//Finds and object that haves the player attached
			theCamera = FindObjectOfType<CameraController> ();
			//The posistion it the same, but the z it's the camera position
			theCamera.transform.position = new Vector3 (transform.position.x, transform.position.y, theCamera.transform.position.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
