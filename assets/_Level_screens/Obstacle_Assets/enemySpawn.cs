using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class enemySpawn : MonoBehaviour
{
	
	//ASSET REFERENCES
	public Transform[] spawnplacement; //spawn points
	public GameObject KnightSprite;
	public GameObject PrincessSprite;
	public GameObject StairwaySprite;
	public GameObject InstantiatethisObstacle;
	public GameObject Icon;


	// GAMEPLAY
	public float timeRemaining; // time until next obstacle spawn
	public int existingEnemies; // obstacle count
	public int ranspawnint; // which obstacle to spawn
	public int numprincess = 0; // princess spawn rate variable
	public int princessdeathCount; // how many princesses have died
	public int levelObjective = 3; // level objective, how many princesses must die



	void Start ()
	{
		timeRemaining = 5f;
		Instantiate (Icon);
	}
	


	void FixedUpdate ()
	{
		if (timeRemaining > 0) 
		{
			timeRemaining -= Time.deltaTime;
		}
		else
		{
			timeRemaining = 5f;
			if (existingEnemies <= 4) 
			{
				ObstacleInstantiate ();
			}
		}

		if (princessdeathCount == levelObjective)

		{
			//spawn stairwell
			princessdeathCount += 1;
			Instantiate (StairwaySprite, spawnplacement [Random.Range
				(0, spawnplacement.Length)].position , Quaternion.identity);
			// stop spawning princesses
			numprincess = 1;
		}

	}



	void ObstacleInstantiate ()
	{
		// LIST OF BAD SPAWN POINTS
		List<Vector3> BadSpawnPoints = new List<Vector3> ();


		// PLACE TARGET POSITION IN LIST
		Movementscript Movementscript = GameObject.Find ("Mino-man_Sprite").GetComponent<Movementscript>();
		BadSpawnPoints.Add (Movementscript.targetPos);

		// CREATE AN ARRAY FOR SURROUNDING COLLIDERS
		Collider2D[] TargetRadiusCast = Physics2D.OverlapCircleAll (Movementscript.targetPos, 1.5f);

		// PLACE SURROUNDING COLLIDERS IN LIST
		foreach (Collider2D col in TargetRadiusCast)
		{
			// CHECK FOR TAGS
			if (col.CompareTag ("Tiles"))
			{
				// ADD TAG SPAWN POINTS TO BAD LIST
				BadSpawnPoints.Add (col.transform.position);
			}
		}

		// CREATE SPAWN POINT FOR OBSTACLE 
		int newspawnnumber = Random.Range (0, spawnplacement.Length);
		Vector3 AnySpawnPoint = spawnplacement [newspawnnumber].position;


		// DISALLOW PRINCESS IF ONE IS IN SCENE?
		GameObject princessalive = GameObject.Find ("Princess_Sprite(Clone)");
		if (princessalive)
		{
			// DISALLOW
			numprincess = 1;
		}
		else
		{
			// ALLOW
			numprincess = 0;
		}

		// CHOOSE RANDOM OBSTACLE
		ranspawnint = Random.Range (numprincess, 4);

		if (ranspawnint > 0) 
		{
			InstantiatethisObstacle = KnightSprite;
		} 
		else 
		{
			InstantiatethisObstacle = PrincessSprite;
		}
			

		// SPAWN OBSTACLE
		if (!BadSpawnPoints.Contains (AnySpawnPoint))
		{
			Instantiate (InstantiatethisObstacle, AnySpawnPoint, Quaternion.identity);
			existingEnemies += 1;
		}
			

	}
}