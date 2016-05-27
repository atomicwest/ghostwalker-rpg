using UnityEngine;
using System.Collections;

public class LoadGastlyLevel : MonoBehaviour {
	
	public string levelToLoad;
	
	public string exitPoint;
	
	private GastlyController thePlayer;
	
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<GastlyController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "gastly_main") 
		{
			Application.LoadLevel(levelToLoad); 
			thePlayer.startPoint = exitPoint;
		}
	}
}
