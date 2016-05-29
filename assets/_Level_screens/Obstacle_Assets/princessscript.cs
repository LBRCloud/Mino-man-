using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class princessscript : MonoBehaviour 
{
	public float enemystrength = 20f;
	public Vector3 obstacleLoc;


	void FixedUpdate()
	{
		// update location
		obstacleLoc = transform.position;
		
		if (enemystrength < 0f) 

		{
			enemySpawn enemySpawn = GameObject.Find ("Game Manager").GetComponent<enemySpawn> ();
			// don't spawn where i died
			enemySpawn.nospawnondeadobstacle = transform.position;
			enemySpawn.existingEnemies -= 1;
			enemySpawn.princessdeathCount += 1;
			Destroy (gameObject);
		}
	}
}