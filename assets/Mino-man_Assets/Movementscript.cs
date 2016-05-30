using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Movementscript : MonoBehaviour 

{

	public Vector3 dir;

	// last updated position and target position
	public Vector3 targetPos;
	public Vector3 lastupdatedpos;

	// last direction
	public int lastdir;

	//raycast as linecast start and end points (from transform position)
	public float sightLength = 1.2f;
	public float sightStart = .7f;

	public bool pausemove = false;
	public float pausemovetimer = .5f;


	public Canvas defeatcanvas;



	// minoman's game object
	public GameObject minoman;
	// minoman's pace
	public float minomanSpeed = 1f;
	// minoman's strength
	public float strength = 100f;
	// minoman's strength regen
	public float regentimer = .2f;
	public float strregen = .5f;
	// minoman's strength modifier
	public float strmod;
	//minoman's damage output
	public float minodmgout = 1f;
	//minoman's current strength icon
	public int curstricon;
	public Sprite[] striconstorage;
	public SpriteRenderer ingamesprite;



	//stair location
	public GameObject stairs;


	void Start () 
	{
		dir = Vector3.zero;
		//set lastupdatedpos Vector3 as targetPos at start.
		lastupdatedpos = transform.position;
		targetPos = lastupdatedpos;
	}


		
	void FixedUpdate ()
	{

		// if strength is below 0
		if (strength < 0) { //stop all other routines,playdeath animation 2-3 seconds
			// show defeat canvas
			defeatcanvas.enabled = true;
			// destroy mino-man gameobject
			Destroy (gameObject, 2f);

			//pause game?? Time.timeScale = 0;
		}


		// STRENGTH REGEN
		if (strength < 100) {
			//regen timer
			regentimer -= Time.deltaTime;
			//Debug.Log (regentimer);

			if (regentimer < 0) {
				//regen
				strength += strregen;
				regentimer = .04f;
				Debug.Log ("Mino-man's STR: " + strength);
				// strength reset to 100 when it goes above 100
			}
		} else if (strength > 100) {
			strength = 100;
			regentimer = .2f;
			Debug.Log ("Mino-man's STR: " + strength);
		}

		if (strength != null) {
			strengthicon ();
		}



		// if target is at last "updated" position (position changes finished)
		if (lastupdatedpos == targetPos) 
		
		{
			// controller reset to zero position.

		
			// if controller is being used set the direction variable respectfully, also set transform direction.
			if (Input.GetAxis ("Horizontal") < 0) 
			
			{
				minoman.transform.localEulerAngles = new Vector3 (0, 0, -90);
				if (lastdir != 2) 
				{
					Debug.Log ("left");
					dir = Vector3.left;
					lastdir = 1;
				}
				else
				{
					Debug.Log ("stop  right");
					dir = Vector3.zero;
					targetPos = lastupdatedpos;
					lastdir = 0;
				}
			}

			if (Input.GetAxis ("Horizontal") > 0) 
			{
				minoman.transform.localEulerAngles = new Vector3 (0, 0, 90);
				if (lastdir != 1) 
				{
					Debug.Log ("right");
					dir = Vector3.right;
					lastdir = 2;
				}
				else
				{
					Debug.Log ("stop left");
					dir = Vector3.zero;
					targetPos = lastupdatedpos;
					lastdir = 0;
				}
			}

			if (Input.GetAxis ("Vertical") < 0) 
			{
				minoman.transform.localEulerAngles = new Vector3 (0, 0, 0);
				if (lastdir != 4) 
				{
					Debug.Log ("down");
					dir = Vector3.down;
					lastdir = 3;
				}
				else
				{
					Debug.Log ("stop up");
					dir = Vector3.zero;
					targetPos = lastupdatedpos;
					lastdir = 0;
				}
			}

			if (Input.GetAxis ("Vertical") > 0) 
			{
				minoman.transform.localEulerAngles = new Vector3 (0, 0, 180);
				if (lastdir != 3) 
				{
					Debug.Log ("up");
					dir = Vector3.up;
					lastdir = 4;
				}
				else
				{
					Debug.Log ("stop down");
					dir = Vector3.zero;
					targetPos = lastupdatedpos;
					lastdir = 0;
				}
			}

			// set raycast as linecast from transform position, setting start and end points
			RaycastHit2D sight = Physics2D.Linecast (transform.position + (dir * sightStart), transform.position + (dir * sightLength));
			Debug.DrawLine (transform.position + (dir * sightStart), transform.position + (dir * sightLength), Color.red, 1.5f);



			// if the raycast as linecast has detected a collider (basically if raycast found any collider,
			// the first one it runs into) 
			// A: Did it hit something?
			if (sight.collider != null) 
			{
				
				if (sight.collider.gameObject.tag == "Princess") {
					//Debug.Log ("its a hit!");

					//loss of strength
					strengthmodifier ();
					strength -= strmod;

					//loss of enemy strength
					princessscript princessscript = sight.collider.gameObject.GetComponent<princessscript> ();
					princessscript.enemystrength -= minodmgout;
					Debug.Log ("Princess's's STR: " + princessscript.enemystrength);
					Debug.Log ("Mino-man's STR: " + strength);

				} else if (sight.collider.gameObject.tag == "Knight") {

					//loss of mino strength
					strengthmodifier ();
					strength -= strmod;

					//loss of enemy strength
					knightscript knightscript = sight.collider.gameObject.GetComponent<knightscript> ();
					knightscript.enemystrength -= minodmgout;
					Debug.Log ("Knight's STR: " + knightscript.enemystrength);
					Debug.Log ("Mino-man's STR: " + strength);
				}
				// A: What did it hit?
				else {

					//Debug.Log (sight.collider.name);
					// change the Vector3 target position to the raycast position.
					targetPos = sight.collider.GetComponent<Transform> ().position;
				}
			}
		} 

		else 
		
		{
			// if transform position is different than the target position, then move towards the position in
			// relationship of seconds * speed
			if (transform.position != targetPos && pausemove == false) 
			
			{
				transform.position = Vector3.MoveTowards (transform.position, targetPos, Time.deltaTime * minomanSpeed);
			}

			//knight dies pause minoman for .2 seconds
			else if (pausemove)
			{
				pausemovetimer -= Time.deltaTime;

				if (pausemovetimer < 0)
				{
					pausemove = false;
					pausemovetimer = .5f;
					dir = Vector3.zero;
					targetPos = lastupdatedpos;
				}
			}

			// if for any reason lastupdated position variable isn't = to the traget position, and the current transform
			// posiiton makes it to the target position then change the last  updated position to the target
			// position variable. (this stops movement).
			else {
				lastupdatedpos = targetPos;
			}
		}

		// NEXT LEVEL
		if (stairs == null) 
		{
			stairs = GameObject.Find ("Stairs(Clone)");

			if (stairs != null) 
			{
				Debug.Log ("STAIRS APPEARED!!!!!!!!");
			}
		}
		else if (targetPos == stairs.transform.position) 
		{
			Debug.Log ("you found the stairs");
			// show defeat canvas
			defeatcanvas.enabled = true;
			// destroy mino-man gameobject
			Destroy (gameObject, 2f);
		}
			
	}
		
	




//				if (Input.GetButtonDown ("Rage")) 
//					{
//						//do this thing.
//					}


	void strengthmodifier ()
	{
		if (strength * .01 < .5) 
		{strmod = .5f;} 
		else 
		{strmod = strength * .01f;}
	}

	void strengthicon ()
	{
		curstricon = (int)Mathf.Floor (strength / 15) -1;
		ingamesprite.sprite = striconstorage [curstricon];
	}



}