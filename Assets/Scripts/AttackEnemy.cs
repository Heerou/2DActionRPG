using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//If the sword colliders touch an eenmy it destroys it.
	void OnTriggerEnter2D(Collider2D collision){
		
		if (collision.gameObject.tag == "Enemy"){
			Destroy (collision.gameObject);
			Debug.Log ("It's an enemy");
		}
	}
}
