using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class enemySpawn : MonoBehaviour
{
	// CREATING LIST OF OBSTACLES
	List<GameObject> ObstacleList = new List<GameObject> ();

	//ASSET REFERENCES
	public Transform[] spawnplacement; //spawn points
	public GameObject KnightSprite;
	public GameObject PrincessSprite;
	public GameObject nextlevel;
	public GameObject InstantiatethisObstacle;

	// OBSTACLE LOCATIONS
	public Vector3 nospawnondeadobstacle = new Vector3 (0, 0, 0);
	public Vector3 nospawnonliveobstacle = new Vector3 (0, 0, 0);

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
			Instantiate (nextlevel, spawnplacement [Random.Range
				(0, spawnplacement.Length)].position, Quaternion.identity);
			// stop spawning princesses
			numprincess = 1;
		}

	}



	void ObstacleInstantiate ()
	{
		//int non-inclusive of top number, never top number
		ranspawnint = Random.Range (numprincess, 4);
		if (ranspawnint > 0) 
		{
			InstantiatethisObstacle = KnightSprite;
		} 

		else 
		{
			InstantiatethisObstacle = PrincessSprite;
		}

		Movementscript Movementscript = GameObject.Find ("Mino-man_Sprite").GetComponent<Movementscript>();
		Vector3 nospawnonmino = Movementscript.lastupdatedpos;

		int newspawnnumber = Random.Range (0, spawnplacement.Length);

		if (spawnplacement [newspawnnumber].position != nospawnonmino &&
			spawnplacement [newspawnnumber].position != nospawnondeadobstacle &&
			spawnplacement [newspawnnumber].position != nospawnonliveobstacle) 
		{
			Instantiate (InstantiatethisObstacle, spawnplacement [newspawnnumber].position, Quaternion.identity);

			existingEnemies += 1;
		}



	}
}