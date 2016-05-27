using UnityEngine;
using System.Collections;

public class DamageEnemy : MonoBehaviour {

	public int damageGiven;

	//assign type/struct GameObject so you can pass a prefab i.e. particle system
	public GameObject damageBurst;

	public Transform hitPoint;
	public GameObject damageNumber;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Enemy") 
		{
			//Auto 1 hit KO
			//Destroy (other.gameObject);

			//<> calls another script, use dot method to call functions from said script
			other.gameObject.GetComponent <EnemyHealthManager>().DamageEnemy (damageGiven);

			//get particle system, e.g. make the particles appear when contact is made
			Instantiate (damageBurst, hitPoint.position, hitPoint.rotation);

			//create an object to use in  the game
			//transform into a gameObject with GameObject at beginning og variable assignment
			var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler (Vector3.zero));
			clone.GetComponent <FloatingNumbers>().damageNumber = damageGiven;
		}
	}
}
