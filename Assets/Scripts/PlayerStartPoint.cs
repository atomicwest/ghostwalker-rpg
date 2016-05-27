using UnityEngine;
using System.Collections;

public class PlayerStartPoint : MonoBehaviour {

	private PlayerController thePlayer;
	private CameraController theCamera;

	//add to specify player position when transitioning between locations
	public Vector2 startDirection;

	public string pointName;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();

		//get the names of start points and check if they match to coordinate start points 
		//in different scenes

		if (thePlayer.startPoint == pointName) 
		{
			thePlayer.transform.position = transform.position;
			//add to specify player position when transitioning between locations
			thePlayer.lastMove = startDirection;

			theCamera = FindObjectOfType<CameraController> ();
			theCamera.transform.position = new Vector3 (transform.position.x, transform.position.y, theCamera.transform.position.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
