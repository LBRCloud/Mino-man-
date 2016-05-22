using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour
{
	public float timeRemaining = 5f;
	public float timeRemainingPrincess = 15f;

	public float timerKnight;
	public float timerPrincess;

	public float countdown;

	public GameObject knight;
	public GameObject princess;

	public int existingEnemies;

	public Transform[] spawn;



	// Use this for initialization
	void Start ()
	{

		SpawnKnight ();

		SpawnPrincess ();

		timerPrincess = timeRemainingPrincess;

		timerKnight = timeRemaining;

		countdown = timeRemaining;

	}
	

	void Update ()
	{
		if (timerKnight > 0) 
		{
		
			timerKnight -= Time.deltaTime;

		}

		//Else check if there are 5 enemies or not
		else
		{
			
			timerKnight = timeRemaining;

			countdown = timeRemaining;

			//If there are 5 existing enemies, then wait for something to change
			if (existingEnemies == 5)
			{

				StartCoroutine ("Checker");

			}

			//Else call Spawn
			else
			{

				SpawnKnight ();

			}
		}


		if (timerPrincess > 0) 
		{

			timerPrincess -= Time.deltaTime;

		}

		//Else check if there are 5 enemies or not
		else
		{

			timerPrincess = timeRemainingPrincess;

			countdown = timeRemaining;

			//If there are 5 existing enemies, then wait for something to change
			if (existingEnemies == 5)
			{

				StartCoroutine ("Checker");

			}

			//Else call Spawn
			else
			{

				SpawnPrincess ();

			}
		}

	}

	//this method spawns an enemy and makes note of it
	void SpawnKnight()
	{
		
		Instantiate (knight, spawn[Random.Range (0,spawn.Length)].position, Quaternion.identity);
		existingEnemies += 1;

	}

	void SpawnPrincess()
	{
		
		Instantiate (princess, spawn [Random.Range (0, spawn.Length)].position, Quaternion.identity);
		existingEnemies += 1;

	}

	IEnumerator Checker()
	{

		yield return new WaitForSeconds (countdown);

	}
}