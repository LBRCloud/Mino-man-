using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public Transform[] spawnPoints;
	public GameObject apple;

	public float timerDuration = 1f;
	public float timer;

	// Use this for initialization
	void Start () {
		SpawnApple();

		timer = timerDuration;
	}
	
	// Update is called once per frame
	void Update () {
		if(timer <= 0) {
			SpawnApple ();
			timer = timerDuration;
		} else {
			timer -= Time.deltaTime;
		}
	}

	void SpawnApple() {
		int spawnNum = Random.Range(0, spawnPoints.Length);
		Vector3 spawnPos = spawnPoints[spawnNum].position;
		Instantiate (apple, spawnPos, Quaternion.identity);
	}
}
