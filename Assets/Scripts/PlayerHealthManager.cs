using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHealth;
	public int playerCurrentHealth;

	// Use this for initialization
	void Start () {
		playerCurrentHealth = playerMaxHealth;

	}
	
	// Update is called once per frame
	void Update () {
		if (playerCurrentHealth <= 0) 
		{
			gameObject.SetActive (false);

			//gamemanager script will go here

		}
	}

	public void DamagerPlayer(int damageGiven) 
	{
		playerCurrentHealth -= damageGiven;
	}

	public void SetMaxHealth()
	{
		playerCurrentHealth = playerMaxHealth;
	}
}
