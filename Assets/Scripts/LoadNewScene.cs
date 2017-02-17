using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewScene : MonoBehaviour {

	public string levelToLoad;

	public string exitPoint;
	private PlayerController thePlayerExit;

	// Use this for initialization
	void Start () {
		thePlayerExit = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//I get here the name of the level
	void OnTriggerEnter2D(Collider2D other){

		if(other.gameObject.name == "Player"){
			Application.LoadLevel (levelToLoad);
			thePlayerExit.startPoint = exitPoint;
		}
	}
}
