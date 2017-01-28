using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	public int damageToGive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Collision between colliders
	void OnCollisionEnter2D(Collision2D collider) {

		//If the two colliders touch Insta kill
		if (collider.gameObject.tag == "Player" && collider.gameObject.name == "Player") {
			collider.gameObject.GetComponent<PlayerHealthManager> ().HurtPlayer (damageToGive);
			Debug.Log ("You Hit me, man...");
		}
	}
}
