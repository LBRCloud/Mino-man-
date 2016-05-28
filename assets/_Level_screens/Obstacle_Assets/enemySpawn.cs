using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour
{
	public float timeRemaining;
	public GameObject KnightSprite;
	public GameObject PrincessSprite;
	public GameObject InstantiatethisObstacle;
	public int ranspawnint;

	public int existingEnemies;
	public Transform[] spawnplacement;


	void Start ()
	{
		timeRemaining = 5f;
		ObstacleInstantiate ();
	}
	

	void Update ()
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

	}

	void ObstacleInstantiate ()
	{
		//int non-inclusive of top number, never top number
		ranspawnint = Random.Range (0, 4);
		if (ranspawnint > 0) 
		{
			InstantiatethisObstacle = KnightSprite;
		} 

		else 
		{
			InstantiatethisObstacle = PrincessSprite;
		}
		Movementscript Movementscript = GameObject.Find ("Mino-man_Sprite").GetComponent<Movementscript>();
		Vector3 nospawnonmino = Movementscript.targetPos;
		int newspawnnumber = Random.Range (0, spawnplacement.Length);
		if (spawnplacement [newspawnnumber].position != nospawnonmino) 
		{
			Instantiate (InstantiatethisObstacle, spawnplacement [Random.Range (0, spawnplacement.Length)].position, Quaternion.identity);
			existingEnemies += 1;
		}
	}

}