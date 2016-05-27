using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {
	//copy  the body from player health manager script

	public int MaxHealth;
	public int CurrentHealth;

	private PlayerStats thePlayerStats;

	public int expGiven;

	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;

		thePlayerStats = FindObjectOfType<PlayerStats>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (CurrentHealth <= 0) 
		{
			//gameObject.SetActive (false);

			Destroy (gameObject);
			thePlayerStats.AddExperience(expGiven);
			
		}
	}
	
	public void DamageEnemy(int damageGiven) 
	{
		CurrentHealth -= damageGiven;
	}
	
	public void SetMaxHealth()
	{
		CurrentHealth = MaxHealth;
	}
}
