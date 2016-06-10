using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class knightscript : MonoBehaviour 
{
	public float knightstrength = 50f;
	public Vector3 obstacleLoc;

	//MOVEMENT VAR
	public int knightdirnum;
	public float dirtimer = 10f;
	public bool knightengaged = false;

	//knight direction
	public Vector3 knightdir;

	//raycast as linecast start and end points (from transform position)
	public float knightsightLength = 1.2f;
	public float knightsightStart = .7f;

	void Start ()
	{
		knightpath ();
	}

	void FixedUpdate()
	{
		// update location
		obstacleLoc = transform.position;

		if (knightstrength < 0f) 
		
		{
			// KNIGHT DEATH
			knightengaged = false;

			enemySpawn enemySpawn = GameObject.Find ("Game Manager").GetComponent<enemySpawn> ();
			enemySpawn.existingEnemies -= 1;

			Movementscript Movementscript = GameObject.Find ("Mino-man_Sprite").GetComponent<Movementscript>();
			Movementscript.pausemove = true;

			Destroy (gameObject);
		}
		// KNIGHT DIRECTION

		if (knightengaged)
		{
			// FACE MINO WHEN ENGAGED
			Vector3 Minoman = GameObject.Find ("Mino-man_Sprite").transform.position;
//			Vector3 Vecdif = (Minoman - transform.position).normalized;
//			float angle = Mathf.Atan2 (Minoman.y, Minoman.x) * Mathf.Rad2Deg;
//			transform.rotation = Quaternion.Euler (0f, 0f, angle -90);
			if (Minoman.x < transform.position.x)
			{
				transform.localEulerAngles = new Vector3 (0, 0, -90);
				Debug.Log ("West to face Minoman");
			}
			if (Minoman.x > transform.position.x)
			{
				transform.localEulerAngles = new Vector3 (0, 0, 90);
				Debug.Log ("East to face Minoman");
			}
			if (Minoman.y < transform.position.y)
			{
				transform.localEulerAngles = new Vector3 (0, 0, 0);
				Debug.Log ("South to face Minoman");
			}
			if (Minoman.y > transform.position.y)
			{
				transform.localEulerAngles = new Vector3 (0, 0, -180);
				Debug.Log ("North to face Minoman");
			}
		}
			
		else
		{
		// DECISION TIME FOR DIRECTION
		dirtimer -= Time.deltaTime;
		if (dirtimer <= 0) 
			{
				dirtimer = 10f;
				// DECIDING DIRECTION
				knightpath ();
				RaycastHit2D knightsight = Physics2D.Linecast (transform.position + (knightdir * knightsightStart), transform.position + (knightdir * knightsightLength));
				Debug.DrawLine (transform.position + (knightdir * knightsightStart), transform.position + (knightdir * knightsightLength), Color.blue, 1.5f);
			}
		}
	}



	void knightpath ()
	{
		knightdirnum = Random.Range (1, 5);

		if (knightdirnum == 1) 
		{
			transform.localEulerAngles = new Vector3 (0, 0, 0);
			knightdir = Vector3.down;
			Debug.Log ("South");
		}
		if (knightdirnum == 2) 
		{
			transform.localEulerAngles = new Vector3 (0, 0, -90);
			knightdir = Vector3.left;
			Debug.Log ("West");
		}
		if (knightdirnum == 3) 
		{
			transform.localEulerAngles = new Vector3 (0, 0, -180);
			knightdir = Vector3.up;
			Debug.Log ("North");
		}
		if (knightdirnum == 4) 
		{
			transform.localEulerAngles = new Vector3 (0, 0, 90);
			knightdir = Vector3.right;
			Debug.Log ("East");
		}
	}

}