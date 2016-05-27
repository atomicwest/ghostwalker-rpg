using UnityEngine;
using System.Collections;

//this script is assigned to the UI canvas
public class PlayerStats : MonoBehaviour {

	public int currentLevel;
	public int currentExp;

	public int currentAttack = 100;
	public int currentDefense = 100;
	public int currentSpecial = 100;

	//create array of numbers for amount of experience needed to level up
	//enter number of elements in unity
	//enter the next needed amount of experience in each element, increasing
	//i.e. element 0 = 0, element 1 = 150, element 2 = 300
	public int[] LevelUp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (currentExp >= LevelUp [currentLevel]) 
		{
			currentLevel++;

			//after updating level, update stats with randomized  numbers
			//level up modifier may be different for certain character classes 
			currentAttack = currentAttack + Random.Range(10, 30);
			currentDefense = currentDefense + Random.Range(10, 20);
			currentSpecial = currentSpecial + Random.Range(10, 40);


		}
	}

	public void AddExperience(int experienceAdd)
	{
		currentExp += experienceAdd;
	}

}
