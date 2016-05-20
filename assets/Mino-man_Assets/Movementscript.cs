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
	public float sightStart = 1f;


	public Canvas defeatcanvas;



	// minoman's pace
	public float minomanSpeed = 1f;
	// minoman's strength
	public float strength = 100f;
	// minoman's strength regen
	public float regentimer = 60f;
	public float strregen = .1f;
	// minoman's strength modifier
	public float strmod;
	// minoman's collision
	public bool isColliding;




	void Start () 
	{
		//set lastupdatedpos Vector3 as targetPos at start.
		lastupdatedpos = transform.position;
		targetPos = lastupdatedpos;
		// minoman's coliison set to false at start
		isColliding = false;
	}
		
	void Update ()
	{

		// if strength is below 0
		if (strength < 0)
		{ //stop all other routines,playdeath animation 2-3 seconds
			// show defeat canvas
			defeatcanvas.enabled = true;
			// destroy mino-man gameobject
			Destroy (gameObject, 3f);

			//pause game?? Time.timeScale = 0;
		}
//		if (strength < 100)
//		{
//			//regen timer
//			regentimer -= Time.deltaTime;
//
//			if (regentimer < 0)
//			{
//				//regen
//				strength += strregen;
//				regentimer = 60f;
//				// strength reset to 100 when it goes above 100
//				if (strength > 100)
//				{
//					strength = 100;
//					regentimer = 360f;
//				}
//
//				else if (strength == 100)
//				{
//					regentimer = 360f;
//				}
//				Debug.Log ("Mino-man's STR: " + strength);
//
//			}
//				
//			
//		}
		// if target is at last "updated" position (position changes finished)
		if (lastupdatedpos == targetPos)
		{
			// controller reset to zero position.
			Vector3 dir = Vector3.zero;

			// if controller is being used set the direction variable respectfully 
			if (Input.GetAxis ("Horizontal") < 0)
			{
				dir = Vector3.left;
			}

			if (Input.GetAxis ("Horizontal") > 0)
			{
				dir = Vector3.right;
			}

			if (Input.GetAxis ("Vertical") < 0)
			{
				dir = Vector3.down ;
			}

			if (Input.GetAxis ("Vertical") > 0)
			{
				dir = Vector3.up;
			}

			// set raycast as linecast from transform position, setting start and end points
			RaycastHit2D sight = Physics2D.Linecast (transform.position + (dir * sightStart), transform.position + (dir * sightLength));
			Debug.DrawLine (transform.position + (dir * sightStart), transform.position + (dir * sightLength), Color.red, 1.5f);

			// if the raycast as linecast has a collider (basically if raycast exists) 
			if (sight.collider != null)
			{


				// change the Vector3 target position to the raycast position.
				targetPos = sight.collider.GetComponent<Transform> ().position;
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


//	public void OnCollisionEnter2D(Collision2D anObstacle)
//	{
//		//freeze obstacle
//		//anObstacle.rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
//		//minomanis colliding with something
//		isColliding = true;
//		Debug.Log ("col");
//	}
//
//	public void OnCollisionExit2D(Collision2D anObstacle)
//	{
//		//unfreeze obstacle
//		anObstacle.rigidbody.constraints = RigidbodyConstraints2D.None;
//		//minoman is no longer colliding with something
//		isColliding = false;
//		Debug.Log ("not col");
//	}
//		if (anObstacle.gameObject.name == "Knight_Sprite(Clone)")
//
//		{
//			strengthmodifier ();
//			strength -= strmod;
//			Debug.Log ("Mino-man's STR: " + strength);
//
//			knightscript knightscript = GameObject.Find ("Knight_Sprite(Clone)").GetComponent<knightscript>();
//			// damage enemy strength
//			knightscript.enemystrength -= 1f;
//			// Display enemy total
//			Debug.Log ("Knight's STR: " + knightscript.enemystrength);
//
//		}
//
//		else if (anObstacle.gameObject.name == "Princess_Sprite(Clone)") 
//
//		{
//			strengthmodifier ();
//			strength -= strmod;
//			Debug.Log ("Mino-man's STR: " + strength);
//
//			princessscript princessscript = GameObject.Find ("Princess_Sprite(Clone)").GetComponent<princessscript>();
//			// damage enemy strength
//			princessscript.enemystrength -= 1f;
//			// Display enemy total
//			Debug.Log ("Princess's's STR: " + princessscript.enemystrength);
//		} 
			
	//}

}