using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class UIMenu : MonoBehaviour {

	public Text attackStat;
	public Text defenseStat;
	public Text specialStat;
	public Text nextExp;
	public Text hp;
	private PlayerStats statsMain;
	private PlayerHealthManager numHP;
	private int currentLvl;
	private int currentExp;

	private static bool UIExists = false;	

	//this string should contain the name of the previous level
	//but for demo will contain the main level
	private string mainlevel = "main";
	
	// Use this for initialization
	void Start () {
		numHP = GetComponent<PlayerHealthManager> ();
		statsMain = GetComponent<PlayerStats> ();

		//destroy the previous UI
		if (!UIExists) {
			UIExists = true;
			DontDestroyOnLoad (transform.gameObject);
		}
		else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {


		currentLvl = statsMain.currentLevel;
		currentExp = statsMain.currentExp;
		hp.text = "HP: " + numHP.playerCurrentHealth;
		attackStat.text = "Attack: " + statsMain.currentAttack;
		defenseStat.text = "Defense: " + statsMain.currentDefense;
		specialStat.text = "Special: " + statsMain.currentSpecial;

		//to pass experience needed, must get value of array at 
		//the next level array
		nextExp.text = "Exp to Level: " + (statsMain.LevelUp[currentLvl+1] - currentExp) ;

		if (Input.GetKeyDown (KeyCode.C)) 
		{
			Application.LoadLevel (mainlevel);
		}

	}
}
