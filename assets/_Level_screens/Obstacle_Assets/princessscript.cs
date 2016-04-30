using UnityEngine;
using System.Collections;

public class princessscript : MonoBehaviour 
{
	public float enemystrength = 20f;

	void Update()
	{
		if (enemystrength < 0f) 

		{
			Destroy (gameObject, .01f);
		}
	}
}