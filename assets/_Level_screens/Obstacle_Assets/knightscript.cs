using UnityEngine;
using System.Collections;

public class knightscript : MonoBehaviour 
{
	public float enemystrength = 50f;

	void Update()
	{
		if (enemystrength < 0f) 
		
		{
			enemySpawn enemySpawn = GameObject.Find ("Game Manager").GetComponent<enemySpawn> ();
			enemySpawn.existingEnemies -= 1;
			Destroy (gameObject, .01f);
		}
	}
}