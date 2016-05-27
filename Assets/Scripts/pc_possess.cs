using UnityEngine;
using System.Collections;

public class pc_possess : MonoBehaviour {
	//this script should be attached to a pc's collider
	//triggers switch from ghost to real world

	private GastlyController thePlayer;

	private string levelToLoad;
	private string exitPoint;

	/*levelToLoad and exit point depend on the name of the current scene
	adjust the suffix to reflect the intended change
	ghost world scenes convention: LOCATION_ghost
	real world scenes convention: LOCATION_live
	*/

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//player object must have a collider to interact
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "gastly_main") 
		{
			Application.LoadLevel(levelToLoad); 
			thePlayer.startPoint = exitPoint;
		}
	}
}
