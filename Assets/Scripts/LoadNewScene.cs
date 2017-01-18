using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewScene : MonoBehaviour {

	public string levelToLoad;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//I get here the name of the level
	void OnTriggerEnter2D(Collider2D other){

		if(other.gameObject.name == "Player"){
			Application.LoadLevel (levelToLoad);
		}
	}
}
