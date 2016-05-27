using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	//use for diagonal movement
	private float currentMoveSpeed;
	public float diagonalMoveMod;

	//include for accessing Animator and .anim sprite sequences
	private Animator anim; 

	private Rigidbody2D myRigidbody;

	private bool playerMoving;

	//make public for PlayerStartPoint script
	public Vector2 lastMove;

	private static bool playerExists;

	private bool attacking; 
	public float attackTime;
	private float attackTimeCounter;

	//where the player will be in the next area
	public string startPoint;

	//needed for stats menu
	private string statsMenu;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		myRigidbody = GetComponent<Rigidbody2D> ();

		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject); 
		}

		DontDestroyOnLoad (transform.gameObject); //e.g. the player object

		statsMenu = "statsMenu";
	}
	
	// Update is called once per frame
	//use this section for such things as updating animations for movement
	void Update () {

		playerMoving = false; 

		if (!attacking) {
			
			//general movement
			//getaxis raw gets the input that is pressed at the moment
			//two conditions, move to right is "> 0.5f", move to left is "<-0.5f"
			if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
				//transform.Translate(new Vector3(Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
				//comment out above for rigidbody
				myRigidbody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * currentMoveSpeed, myRigidbody.velocity.y);
				playerMoving = true;
				lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
			}
			if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
				//transform.Translate (new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
				//comment out above for rigidbody
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, Input.GetAxisRaw ("Vertical") * currentMoveSpeed);
				playerMoving = true;
				lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
			}

			//eliminate the sliding effect after bumping off collider boundaries
			//after commenting out original translate operations
			if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {
				myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);
		
			}

			if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);
			
			}

			//attack
			if (Input.GetKeyDown (KeyCode.Z)) {
				attackTimeCounter = attackTime;
				attacking = true;
				//assuming player will be still when attacking
				//create a new vector object with x=y=0
				myRigidbody.velocity = Vector2.zero;
				anim.SetBool ("Attack", true);
			}

			//open stats menu

			if (Input.GetKeyDown (KeyCode.C)) 
			{
				Application.LoadLevel(statsMenu);
			}

			//diagonal movement correction
			if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
			{
				currentMoveSpeed = moveSpeed * diagonalMoveMod ;
			} else {
				currentMoveSpeed = moveSpeed; 

			}

		}


		if (attackTimeCounter > 0) 
		{
			attackTimeCounter -= Time.deltaTime;
		}

		if (attackTimeCounter <= 0) 
		{
			attacking = false;
			anim.SetBool ("Attack", false);
		}

		//for movement animations
		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool ("playerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
	}

}
