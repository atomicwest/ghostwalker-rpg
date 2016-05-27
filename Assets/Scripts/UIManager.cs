using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	//attach slider and slider text to this script

	public Slider healthBar;
	public Text HPText;

	//you can use the name of the script as a type
	public PlayerHealthManager playerHealth;


	//for duplicating the UI in other scenes
	private static bool UIExists;

	//use for adding stats display
	private PlayerStats statsmain;
	public Text levelText;

	// Use this for initialization
	void Start () {
		if (!UIExists) {
			UIExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject); 
		}

		statsmain = GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.maxValue = playerHealth.playerMaxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;
		HPText.text = "SP: " + healthBar.value + "/" + healthBar.maxValue;
		levelText.text = "Lvl: " + statsmain.currentLevel; 
	}
}
