using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class princessscript : MonoBehaviour 
{
	public float enemystrength = 20f;
	public Vector3 obstacleLoc;
	public bool princessengaged = false;

	void FixedUpdate()
	{
		// update location
		obstacleLoc = transform.position;
		
		if (enemystrength < 0f) 

		{
			//PRINCESS DEATH
			princessengaged = false;
			enemySpawn enemySpawn = GameObject.Find ("Game Manager").GetComponent<enemySpawn> ();
			// don't spawn where i died
			enemySpawn.existingEnemies -= 1;
			enemySpawn.princessdeathCount += 1;

			Movementscript Movementscript = GameObject.Find ("Mino-man_Sprite").GetComponent<Movementscript>();
			Movementscript.pausemove = true;
			if (Movementscript.ragecount == 0)
			{
				Movementscript.ragecount = 1;
			}


			Destroy (gameObject);
		}
	}
}