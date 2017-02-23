using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHealth;
	public int playerCurrentHealth;
	// know if the player it's flashing
	private bool flashActive;
	public float flashLength;
	private float countFlashLength;
	//Reference to the sprite renderer
	private SpriteRenderer playerSpriteRenderer;

	// Use this for initialization
	void Start () {
		//Setting the initial health
		playerCurrentHealth = playerMaxHealth;
		playerSpriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerCurrentHealth <= 0) {
			gameObject.SetActive (false);
		}

		if(flashActive) {
		//Makes the player go flashy
			//If the count it's greater that 1.66 sec the playerSpriteRenderer goes 0
			if(countFlashLength > flashLength * .66f) {
				playerSpriteRenderer.color = new Color (playerSpriteRenderer.color.r, playerSpriteRenderer.color.g, playerSpriteRenderer.color.b, 0.37254902f);
			}
			//If the count it's greater that 1.33 sec the playerSpriteRenderer goes 1
			else if (countFlashLength > flashLength * .33f) {
				playerSpriteRenderer.color = new Color (playerSpriteRenderer.color.r, playerSpriteRenderer.color.g, playerSpriteRenderer.color.b, 1f);
			}
			else if (countFlashLength > 0f) {
				playerSpriteRenderer.color = new Color (playerSpriteRenderer.color.r, playerSpriteRenderer.color.g, playerSpriteRenderer.color.b, 0.37254902f);
			}
			else {
				//Makes the playerSpriteRenderer visible
				playerSpriteRenderer.color = new Color (playerSpriteRenderer.color.r, playerSpriteRenderer.color.g, playerSpriteRenderer.color.b, 1f);
				flashActive = false;
			}

			countFlashLength -= Time.deltaTime;
		}
	}

	public void HurtPlayer (int damageToGive) {
		//When the player touch the slime it hurts
		playerCurrentHealth -= damageToGive;

		flashActive = true;
		countFlashLength = flashLength;
	}

	public void SetMaxHealth () {
		playerCurrentHealth = playerMaxHealth;
	}
}