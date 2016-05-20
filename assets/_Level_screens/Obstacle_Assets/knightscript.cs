using UnityEngine;
using System.Collections;

public class knightscript : MonoBehaviour 
{
	public float enemystrength = 50f;

	void Update()
	{
		if (enemystrength < 0f) 
		
		{
			Destroy (gameObject, .01f);
		}
	}
}