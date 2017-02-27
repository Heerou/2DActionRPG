using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public int playerCurrentLevel;

	public int currentExp;

	//Array for level up
	public int[] toLevelUp;

    //Stats when the player levels up
    public int[] hpLevels;
    public int[] attackLevels;
    public int[] defenseLevels;

    //Current player stats
    public int currentHP;
    public int currentAttack;
    public int currentDefense;

    private PlayerHealthManager playerHealthManager;

	// Use this for initialization
	void Start () {
        currentHP = hpLevels[1];
        currentAttack = attackLevels[1];
        currentDefense = defenseLevels[1];

        playerHealthManager = FindObjectOfType<PlayerHealthManager> ();

    }
	
	// Update is called once per frame
	void Update () {
		//If the xp it's greater than the level up condition it will level up
		if (currentExp >= toLevelUp[playerCurrentLevel]) {
            //playerCurrentLevel++;
            LevelUp();
		}
	}
	//Recives the Xp when the player kills an enemy
	public void AddExpirience (int expToAdd) {
		currentExp += expToAdd;
	}

    public void LevelUp() {
        playerCurrentLevel++;
        currentHP = hpLevels[playerCurrentLevel];

        playerHealthManager.playerMaxHealth = currentHP;
        playerHealthManager.playerCurrentHealth += currentHP - hpLevels[playerCurrentLevel - 1];

        currentAttack = attackLevels[playerCurrentLevel];
        currentDefense = defenseLevels[playerCurrentLevel];
    }
}
