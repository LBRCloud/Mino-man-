using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scenemanagerscript : MonoBehaviour {
	public float timer = .2f;
	public GameObject asteroidPrefab;
	public Vector2 apointinWS;
	public float asteroidSpeed = 1f;


	public Vector3 screenSpot;
	public Vector2 clickSpot;
	public Transform shipBody;
	public float shipLag = 12f;

	public float emitLaser = 2f;
	public GameObject aBeam;
	public float beamSpeed = 1f;

	public int changescore;
	public Text currentscore;

	void Start () 

	{
		ParticleSystem shipPart = GameObject.Find ("Shipparticle").GetComponent<ParticleSystem> ();
		shipPart.Stop();
	}

	// Update is called once per frame
	void Update () 
	{
		shipBody.position = Vector2.MoveTowards(shipBody.position, screenSpot, shipLag * Time.deltaTime);
		// o casefs
		if (Input.GetMouseButton (0))
		{
			clickSpot = Input.mousePosition;
			screenSpot = Camera.main.ScreenToWorldPoint(clickSpot);


		}


		// qwerqwxer
		timer -= Time.deltaTime;
		if (timer <= 0)
		{
			float ranNum = Random.Range (-20, 20);
			apointinWS = new Vector2(ranNum, 50);
			asteroidPrefab.transform.position = apointinWS;
			Instantiate (asteroidPrefab);

			//find location to spawn.
				//find left position, find right position
				//2d world spave coordinates
				//create random position from left to right
			//find asteroid to spawn

			//spawn asteroid at location
			timer = .2f;
		}
		emitLaser -= Time.deltaTime;
		if (emitLaser <= 0) 

		{
			Vector2 front = new Vector2 (shipBody.position.x, shipBody.position.y + 3);
			Instantiate (aBeam, front, Quaternion.identity);
			emitLaser = .5f;
		}


	}
	void OnDestroy ()
	{
		Debug.Log ("the end");
			Debug.Log ("the end is nigh");
			SceneManager.LoadScene("gameover");
	}

}
