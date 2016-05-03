using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class secondBreakfast : MonoBehaviour 
{

	//need a place to store the array of spawn points for the entirety of the program.
	public Transform[] spawnPoints = new Transform[16];

	//need a place to store the array of cubes for the entirety of the program.
	public GameObject[] cubeObjects = new GameObject[16];
	public GameObject selectionOne;
	public GameObject selectionTwo;
	public GameObject storageObject;
	public float timeLeft = 60f;
	public Text billboard;
	public GameObject timing;

	void Start () 
	{

		//locate  where to instantiate the cube prefabs(s) and put one on each spawn point.

		// This for loop will continue until cubeObjects length has been reached.
		// It will attempt to mimic a "shuffle" of the index using a random exchange of array elements
		// Instantiating a new cube at each spawn location.
		for (int a = 0; a < cubeObjects.Length; a++) 
		{
			//this saves the presently generated object index for this round. 
			//While the data doesn't move the index will be rewritten.
			GameObject loopobjectMemory = cubeObjects[a];
			// now we will acquire a new "random" number, to select a new index
			//This number needs to be any number that was not the last number
			//and is any number from 0 to the end length of the cubeObjects array.
			int ranNum = Random.Range(a, cubeObjects.Length);
			//Use the new Random # to set the old array index object with the new array index object
			cubeObjects[a] = cubeObjects[ranNum];
			// then replace the new array index object with the old index object.
			cubeObjects[ranNum] = loopobjectMemory;

			// "a" ONLY changes on each for loop, which is why this works.
			// "a" dictates the beginning of the random # generator each time,
			// "a" also represents the numerical array index # that the current for loop is on.
			// 0 then 1 then 2 then 3 and so on until 16.
		}

		for (int b = 0; b < cubeObjects.Length; b++)
		
		{
			Instantiate (cubeObjects[b], spawnPoints[b].position, Quaternion.identity);
		}

			// This will instantiate a new cube at each spawn point.

			// First we need the location of the spawn points
		

	}

	void Update () 
	{
		if (timeLeft <= 0) 
		
		{
			//game over;
		} 
		 
		else 

		{
			timeLeft -= Time.deltaTime;
			timing = GameObject.Find ("scriptobject");
		//	timing.Canvas.Time.text = timeLeft.ToString ();
		}

		if (Input.GetMouseButtonDown (0))
			//This asks every frame if the left mouse button is down.
		
		{
			Ray arayfromCamera = Camera.main.ScreenPointToRay (Input.mousePosition);
			// this create a ray variable to hold the ray info.
			// It instantiates a ray from the main camera to the point that is clicked in screenspace.
			RaycastHit diditHit;

			if (Physics.Raycast (arayfromCamera, out diditHit)) 
 			{				
				//this instantiates the ray.
				selectionTwo = selectionOne;
				//this exchanges the value of hit item into a new variable.
				selectionOne = diditHit.collider.gameObject;
				//this sets selecitionOne as the rayed gameobject
				storageObject = selectionOne;
				diditHit.collider.transform.Rotate (0, 180, 0);

				//this deactivates selectionOne for use.

				if (selectionOne.tag == selectionTwo.tag) 
				{
					selectionOne.SetActive (false);
					selectionTwo.SetActive (false);
				} 

				else 
				{
					selectionOne.transform.Rotate (0, 0, 0);
					selectionTwo.transform.Rotate (0, 0, 0);
					//selectionOne = null;
					//selectionTwo = null;
					Debug.Log ("himom");
				}
			}
		

				//get the collider of the gameobject i hit
				//string hitObject = diditHit.collider.gameObject.name;
				//Transform hitCube = diditHit.collider.gameObject.transform;
				//hitCube.rotation = Quaternion.identity;
				//hitCube.transform.rotation = Quaternion.Euler(0, 180, 0);
				//hitCube.Rotate(Vector3.up * 180, 1f);
			//faceAway = diditHit.collider.gameObject;
			//Transform targetObject = diditHit.collider.gameObject.transform;
			//faceAway.transform.rotation = Quaternion.identity;
			//StartCoroutine ("TurnObject");
			//Debug.Log (faceAway.transform.rotation);
			//string hitObject = faceAway.name;
			//Debug.Log (hitObject);
			//Destroy (diditHit.collider.gameObject);
			//Debug.Log ("+100 points");

		}





	
	}

	IEnumerator TurnObject()

	{
		gameObject.transform.Rotate (Vector3.up * 180);
		yield return null;
	}

	//void desObj()

	//{
	//	Destroy ();
	//}
}
