using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class knightscript : MonoBehaviour 
{
	public float enemystrength = 50f;
	public Vector3 obstacleLoc;

	void FixedUpdate()
	{
		// update location
		obstacleLoc = transform.position;

		if (enemystrength < 0f) 
		
		{
			enemySpawn enemySpawn = GameObject.Find ("Game Manager").GetComponent<enemySpawn> ();
			enemySpawn.existingEnemies -= 1;

			Movementscript Movementscript = GameObject.Find ("Mino-man_Sprite").GetComponent<Movementscript>();
			Movementscript.pausemove = true;

			Destroy (gameObject);
		}
	}
}