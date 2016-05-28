using UnityEngine;
using System.Collections;

public class princessscript : MonoBehaviour 
{
	public float enemystrength = 20f;

	void Update()
	{
		if (enemystrength < 0f) 

		{
			enemySpawn enemySpawn = GameObject.Find ("Game Manager").GetComponent<enemySpawn> ();
			enemySpawn.existingEnemies -= 1;
			enemySpawn.princessdeathCount += 1;
			Destroy (gameObject);
		}
	}
}