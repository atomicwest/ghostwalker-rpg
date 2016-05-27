using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {

	public int damageInf;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "playerT") 
		{
			other.gameObject.GetComponent <PlayerHealthManager>().DamagerPlayer(damageInf);
		}
	}
}
