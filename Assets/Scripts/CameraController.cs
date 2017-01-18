using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	//Follow the player
	public GameObject followTarget;
	private Vector3 targetPosition;
	public float moveSpeed;

	// Use this for initialization
	void Start () {

		//Don't destroy when the object loads
		DontDestroyOnLoad (transform.gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {

		//Position of the camera
		targetPosition = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		//the camera will follow the player
		transform.position = Vector3.Lerp (transform.position, targetPosition, moveSpeed * Time.deltaTime);
	}
}
