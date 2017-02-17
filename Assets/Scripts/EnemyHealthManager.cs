using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyMaxHealth;
	public int enemyCurrentHealth;

	private PlayerStats theplayerStats;

	//Exp to give when the player kills an enemy
	public int expToGive;

	// Use this for initialization
	void Start () {
		//Setting the initial health
		enemyCurrentHealth = enemyMaxHealth;
		theplayerStats = FindObjectOfType<PlayerStats> ();
	}

	// Update is called once per frame
	void Update () {
		if(enemyCurrentHealth <= 0) {
			Destroy (gameObject);
			//Sends the Exp to the player
			theplayerStats.AddExpirience (expToGive);
		}
	}

	public void HurtEnemy(int damageToGive) {
		//When the enemy touch the slime it hurts
		enemyCurrentHealth -= damageToGive;
	}

	public void SetMaxHealth () {
		enemyCurrentHealth = enemyMaxHealth;
	}
}
