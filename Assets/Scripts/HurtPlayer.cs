using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	public int damageToGive;
	public GameObject damageNumber;
    private int currentDamage;

    private PlayerStats playerstats;

	// Use this for initialization
	void Start () {
        playerstats = FindObjectOfType<PlayerStats>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

	//Collision between colliders
	void OnCollisionEnter2D(Collision2D collider) {
        currentDamage = damageToGive - playerstats.currentDefense;
        //If the damage to the player it's less than 0 doesn't make damage
        if(currentDamage < 0) {
            currentDamage = 0;
        }

        //If the two colliders touch Insta kill
        if (collider.gameObject.tag == "Player" && collider.gameObject.name == "Player") {
			collider.gameObject.GetComponent<PlayerHealthManager> ().HurtPlayer (currentDamage);
			//Shows the damageNumber
			var clone = (GameObject)Instantiate(damageNumber, collider.transform.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers> ().damageNumber = currentDamage;
			Debug.Log ("You Hit me, man...");
		}
	}
}
