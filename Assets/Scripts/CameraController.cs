using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	//Follow the player
	public GameObject followTarget;
	private Vector3 targetPosition;
	public float moveSpeed;
	//If the camera exist. static makes that only the one that have the script added has the bool
	private static bool cameraExists;

	// Use this for initialization
	void Start () {

		if (!cameraExists) {

			cameraExists = true;
			//Doesn't destroy object when the scene loads
			DontDestroyOnLoad (transform.gameObject);
		}
		else {
			Destroy (gameObject);
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		//Position of the camera
		targetPosition = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		//the camera will follow the player
		transform.position = Vector3.Lerp (transform.position, targetPosition, moveSpeed * Time.deltaTime);
	}
}
