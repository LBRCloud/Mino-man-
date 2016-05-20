using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movementscript : MonoBehaviour 

{

	// last updated position and target position
	public Vector3 targetPos;
	public Vector3 lastupdatedpos;

	//raycast as linecast start and end points (from transform position)
	public float sightLength = 1.2f;
	public float sightStart = .7f;


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
	//minoman enemy armor
	public float knightArmor = .75f;





	void Start () 
	{
		//set lastupdatedpos Vector3 as targetPos at start.
		lastupdatedpos = transform.position;
		targetPos = lastupdatedpos;
	}
		
	void Update ()
	{

		// if strength is below 0, MINOMAN DIES
		if (strength < 0)
		{ //stop all other routines,playdeath animation 2-3 seconds
			// show defeat canvas
			defeatcanvas.enabled = true;
			// destroy mino-man gameobject
			Destroy (gameObject, 2f);

			//pause game?? Time.timeScale = 0;
		}


		// if strength is below 100, STRENGTH REGEN 
		if (strength < 100)
		{
			//regen timer
			regentimer -= Time.deltaTime;
			//Debug.Log (regentimer);

			if (regentimer < 0)
			{
				//regen
				strength += strregen;
				regentimer = .04f;
				Debug.Log ("Mino-man's STR: " + strength);
				// strength reset to 100 when it goes above 100
			}
		}
		else if (strength > 100)
		{
			strength = 100;
			regentimer = .2f;
			Debug.Log ("Mino-man's STR: " + strength);
		}



		// if target is at last "updated" position (position changes finished)
		if (lastupdatedpos == targetPos)
		{
			// controller reset to zero position.
			Vector3 dir = Vector3.zero;

			// if controller is being used set the direction variable respectfully, also set transform direction.
			if (Input.GetAxis ("Horizontal") < 0)
			{
				dir = Vector3.left;
				minoman.transform.localEulerAngles = new Vector3 (0, 0, -90);
			}

			if (Input.GetAxis ("Horizontal") > 0)
			{
				dir = Vector3.right;
				minoman.transform.localEulerAngles = new Vector3 (0, 0, 90);
			}

			if (Input.GetAxis ("Vertical") < 0)
			{
				dir = Vector3.down ;
				minoman.transform.localEulerAngles = new Vector3 (0, 0, 0);
			}

			if (Input.GetAxis ("Vertical") > 0)
			{
				dir = Vector3.up;
				minoman.transform.localEulerAngles = new Vector3 (0, 0, 180);
			}

			// set raycast as linecast from transform position, setting start and end points
			RaycastHit2D sight = Physics2D.Linecast (transform.position + (dir * sightStart), transform.position + (dir * sightLength));
			Debug.DrawLine (transform.position + (dir * sightStart), transform.position + (dir * sightLength), Color.red, 1.5f);



			// if the raycast as linecast has detected a collider (basically if raycast found any collider,
			// the first one it runs into) 
			// A: Did it hit something?
			if (sight.collider != null) {
				
				if (sight.collider.gameObject.tag == "Princess")
				{
					//Debug.Log ("its a hit!");

					//loss of strength
					strengthmodifier ();
					strength -= strmod;

					//loss of enemy strength
					princessscript princessscript = GameObject.Find ("Princess_Sprite(Clone)").GetComponent<princessscript>();
					princessscript.enemystrength -= minodmgout;
					Debug.Log ("Princess's's STR: " + princessscript.enemystrength);
					Debug.Log ("Mino-man's STR: " + strength);
				}


				else if (sight.collider.gameObject.tag == "Knight")
				{
					//Debug.Log ("its a hit!");

					//loss of strength
					strengthmodifier ();
					strength -= strmod;

					//loss of enemy strength
					knightscript knightscript = GameObject.Find ("Knight_Sprite(Clone)").GetComponent<knightscript>();
					knightscript.enemystrength -= minodmgout * knightArmor;
					Debug.Log ("Knight's STR: " + knightscript.enemystrength);
					Debug.Log ("Mino-man's STR: " + strength);
				}
				// A: What did it hit?
				else
				{
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
			if (transform.position != targetPos)
			{
				transform.position = Vector3.MoveTowards (transform.position, targetPos, Time.deltaTime * minomanSpeed);
			}

			// if for any reason lastupdated position variable isn't = to the traget position, and the current transform
			// posiiton makes it to the target position then change the last  updated position to the target
			// position variable. (this stops movement).
			else
			{
				lastupdatedpos = targetPos;
			}
		}


//				if (Input.GetButtonDown ("Rage")) 
//					{
//						//do this thing.
//					}
	}

	void strengthmodifier ()
	{
		if (strength * .01 < .5) 
		{strmod = .5f;} 
		else 
		{strmod = strength * .01f;}
	}




}