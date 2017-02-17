using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public int playerCurrentLevel;

	public int currentExp;

	//Array for level up
	public int[] toLevelUp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//If the xp it's greater than the level up condition it will level up
		if (currentExp >= toLevelUp[playerCurrentLevel]) {
			playerCurrentLevel++;
		}
	}
	//Recives the Xp when the player kills an enemy
	public void AddExpirience (int expToAdd) {
		currentExp += expToAdd;
	}
}
