using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour {

	public int damageToGive;
	public GameObject damageBurst;
	public Transform hitPoint;
	public GameObject damageNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//If the sword colliders touch an eenmy it destroys it.
	void OnTriggerEnter2D(Collider2D collision){
		
		if (collision.gameObject.tag == "Enemy"){
			//Destroy (collision.gameObject);
			//I get the health manager and i put the damage
			collision.gameObject.GetComponent<EnemyHealthManager> ().HurtEnemy(damageToGive);
			Debug.Log ("It's an enemy");
			//Creates the particle in the world
			Instantiate (damageBurst, hitPoint.position, hitPoint.rotation);
			//Shows the damageNumber
			var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive;
		}
	}
}
