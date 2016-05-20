using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour
{
	public float timeRemaining;

	public float timer;

	public GameObject enemy;

	public int existingEnemies;

	public Transform[] spawn;
	// Use this for initialization
	void Start ()
	{
		
		timer = timeRemaining;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (timer > 0) {
			timer -= Time.deltaTime;
			Debug.Log (timeRemaining);
		}

		//If there are less than 5 knights spawn more
		else
		{
			existingEnemies += 1;
			timer = timeRemaining;
			Instantiate (enemy, spawn[Random.Range (0,spawn.Length)].position, Quaternion.identity);
		}
	}
}