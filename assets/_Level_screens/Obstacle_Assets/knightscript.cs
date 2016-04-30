using UnityEngine;
using System.Collections;

public class knightscript : MonoBehaviour 
{
	public float enemystrength = 500f;

	void Update()
	{
		if (enemystrength < 0f) 
		
		{
			Destroy (gameObject, .01f);
		}
	}
}
	
