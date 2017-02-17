using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider healthBar;
	public Text HPtext;
	public PlayerHealthManager playerHealth;
	private static bool UIExist;

	private PlayerStats thePlayerStats;
	public Text levelText;

	// Use this for initialization
	void Start () {

		if(!UIExist) {
			UIExist = true;
			//Doesn't destroy object when the scene loads
			DontDestroyOnLoad (transform.gameObject);
		}
		else {
			Destroy (gameObject);
		}

		thePlayerStats = GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Player health in the bar, reference to the PlayerHealthManager
		healthBar.maxValue = playerHealth.playerMaxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;

		HPtext.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
		levelText.text = "Level: " + thePlayerStats.playerCurrentLevel;
	}
}
