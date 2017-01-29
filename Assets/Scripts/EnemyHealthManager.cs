using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyMaxHealth;
	public int enemyCurrentHealth;

	// Use this for initialization
	void Start () {
		//Setting the initial health
		enemyCurrentHealth = enemyMaxHealth;
	}

	// Update is called once per frame
	void Update () {
		if(enemyCurrentHealth <= 0) {
			Destroy (gameObject);
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
