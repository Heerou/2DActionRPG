using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHealth;
	public int playerCurrentHealth;

	// Use this for initialization
	void Start () {
		//Setting the initial health
		playerCurrentHealth = playerMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(playerCurrentHealth <= 0) {
			gameObject.SetActive (false);
		}
	}

	public void HurtPlayer (int damageToGive) {
		//When the player touch the slime it hurts
		playerCurrentHealth -= damageToGive;
	}

	public void SetMaxHealth () {
		playerCurrentHealth = playerMaxHealth;
	}
}