using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movementscript : MonoBehaviour 

{

	//private Vector2 destination;
<<<<<<< HEAD
	public float sightLength = 1.2f;
	public float sightStart = 0.5f;
	public float speed;
	public float strength = 100f;

	public Canvas defeatcanvas;

	public Vector3 targetPos;
	public Vector3 lastPos;

	void Start () 
	{
//		destination.x = this.gameObject.transform.position.x;
//		destination.y = this.gameObject.transform.position.y;
		lastPos = transform.position;
		targetPos = lastPos;
	}
		
	void Update ()
	{
		if (lastPos == targetPos)
		{

			Vector3 dir = Vector3.zero;

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
				dir = Vector3.down;
			}

			if (Input.GetAxis ("Vertical") > 0)
			{
				dir = Vector3.up;
			}
			RaycastHit2D sight = Physics2D.Linecast (transform.position + (dir * sightStart), transform.position + (dir * sightLength));
			Debug.DrawLine (transform.position + (dir * sightStart), transform.position + (dir * sightLength), Color.red, 1.5f);

			if (sight.collider != null)
			{
				targetPos = sight.collider.GetComponent<Transform> ().position;
			}
		}

		else
		{

			if (transform.position != targetPos)
			{
				transform.position = Vector3.MoveTowards (transform.position, targetPos, Time.deltaTime);
			}

			else
			{
				lastPos = targetPos;
			}
		}
=======
	public float speed;
	public float strength = 100f;
	public Canvas defeatcanvas;

//	void Start () 
//	{
//		destination.x = this.gameObject.transform.position.x;
//		destination.y = this.gameObject.transform.position.y;
//	}
		
	void Update () 
	{
>>>>>>> refs/remotes/origin/Level
		/*if (Input.GetKey (KeyCode.W)) 
			{
				transform.Translate (Vector3.up * Time.deltaTime);
			}
		if (Input.GetKey (KeyCode.S)) 
			{
				transform.Translate (-Vector3.up * Time.deltaTime);
			}
		if (Input.GetKey (KeyCode.A)) 
			{
				transform.Translate (Vector3.right * Time.deltaTime);
			}
		if (Input.GetKey (KeyCode.D)) 
			{
				transform.Translate (-Vector3.right * Time.deltaTime);
			}*/


<<<<<<< HEAD
//
//		if (Input.GetAxis ("Vertical") != 0)
//		{
//			transform.Translate (Vector3.up * Time.deltaTime * Input.GetAxis ("Vertical"));
//		}
//
//		if (Input.GetAxis ("Horizontal") != 0)
//		{
//			transform.Translate (Vector3.right * Time.deltaTime * Input.GetAxis ("Horizontal"));
//		}
=======

		if (Input.GetAxis ("Vertical") != 0)
		{
			transform.Translate (Vector3.up * Time.deltaTime * Input.GetAxis ("Vertical"));
		}

		if (Input.GetAxis ("Horizontal") != 0)
		{
			transform.Translate (Vector3.right * Time.deltaTime * Input.GetAxis ("Horizontal"));
		}
>>>>>>> refs/remotes/origin/Level

		//		if (this.gameObject.transform.position != new Vector3(destination.x, destination.y, -0.5)
		//			{
		//
		//			}

//				if (Input.GetButtonDown ("Rage")) 
//					{
//						//do this thing.
//					}
	}



	public void OnCollisionStay2D(Collision2D anObstacle)

	{
			
		if (anObstacle.gameObject.name == "Knight_Sprite(Clone)" && strength > 0)

		{
			float strmod;
			if (strength * .01 < .5) 
			{strmod = .5f;} 
			else {strmod = strength * .01f;}
			strength -= strmod;
			Debug.Log ("Mino-man's STR: " + strength);

			knightscript knightscript = GameObject.Find ("Knight_Sprite(Clone)").GetComponent<knightscript>();
			// damage enemy strength
			knightscript.enemystrength -= 1f;
			// Display enemy total
			Debug.Log ("Knight's STR: " + knightscript.enemystrength);
//				Text currentscore = GameObject.Find ("Player Score").GetComponent<Text>();
//				scenemanagerscript aScript = GameObject.Find ("ship").GetComponent<scenemanagerscript> ();
//				aScript.changescore += 100;
//				currentscore.text = "Score: " + aScript.changescore.ToString ();
		}

		else if (anObstacle.gameObject.name == "Princess_Sprite(Clone)" && strength > 0) 
			// if alive
		{
			float strmod;
			if (strength * .01 < .25) 
			{strmod = .5f;} 
			else {strmod = strength * .005f;}
			strength -= strmod;
			Debug.Log ("Mino-man's STR: " + strength);

			princessscript princessscript = GameObject.Find ("Princess_Sprite(Clone)").GetComponent<princessscript>();
			// damage enemy strength
			princessscript.enemystrength -= 1f;
			// Display enemy total
			Debug.Log ("Princess's's STR: " + princessscript.enemystrength);
		} 
			// if strength is below 0
		else 
			
		{ //stop all other routines,playdeath animation 2-3 seconds
			// show defeat canvas
			defeatcanvas.enabled = true;
			// destroy mino-man gameobject
			Destroy (gameObject, 3f);

			//pause game?? Time.timeScale = 0;
		}

/*		else 

		{
//			SpriteRenderer rendDisable = GameObject.Find ("Knight_Sprite(Clone)").GetComponent<SpriteRenderer> ();
//			rendDisable.enabled = false;

//			Destroy (anObstacle.gameObject, 1f);
			Destroy (gameObject, 1f);
		}*/

	}

}