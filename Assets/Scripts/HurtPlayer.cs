using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	public int damageToGive;
	public GameObject damageNumber;

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
			//Shows the damageNumber
			var clone = (GameObject)Instantiate(damageNumber, collider.transform.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive;
			Debug.Log ("You Hit me, man...");
		}
	}
}
