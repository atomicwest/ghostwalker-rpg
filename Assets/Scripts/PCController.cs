using UnityEngine;
using System.Collections;

public class PCController : MonoBehaviour {
/*
	private bool IsPoss;

	public float moveSpeed;
	
	private Rigidbody2D myRigidbody;
	
	private bool moving; //default false 
	
	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;
	
	private Vector3 moveDirection;
	
	public float waitToReload;
	private bool reloading; 
	private GameObject thePlayer;
	
	// Use this for initialization
	void Start () {
		
		myRigidbody = GetComponent<Rigidbody2D>();
		
		//timeBetweenMoveCounter = timeBetweenMove;
		//timeToMoveCounter = timeToMove;
		
		timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeBetweenMove * 1.25f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (moving) {
			timeToMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = moveDirection;
			
			if(timeToMoveCounter < 0f)
			{
				moving = false;
				//timeBetweenMoveCounter = timeBetweenMove;
				
				//below adds more randomness to enemy movement
				timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			}
			
		} else {
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;
			
			if (timeBetweenMoveCounter < 0f) 
			{
				moving = true; 
				//timeToMoveCounter = timeToMove;
				
				//below adds more randomness to enemy movement
				timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeBetweenMove * 1.25f);
				
				moveDirection = new Vector3(Random.Range (-1f, 1f) * moveSpeed, Random.Range(-1f,1f) * moveSpeed, 0f);
			}
		}
		
		if (reloading) 
		{
			waitToReload -= Time.deltaTime;
			if(waitToReload < 0) 
			{
				Application.LoadLevel(Application.loadedLevel);
				thePlayer.SetActive(true);
			}
		}
		
	}
	
	
	//function for player hit/respawn
	void OnCollisionEnter2D(Collision2D other) {
		
		/*
		//when the attached pc hits the player
		if (other.gameObject.name == "playerT")
		{
			//Destroy(other.gameObject);
			other.gameObject.SetActive(false);

			//set player to be active again
			reloading = true;

			thePlayer = other.gameObject;
		} 	*/
		
	}

	/*
	 * when possession is called, the camera position transfers over
	 * player controller should also transfer over
	 * /
	
}

*/