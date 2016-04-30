using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class beamMovement : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject, 3f);
	}

	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y + 2);
	}
	public void OnCollisionEnter2D(Collision2D anObject)
	{
		//add points
		if (anObject.gameObject.name == "Asteroid(Clone)") 
		{
			//get the  Text object
			Text currentscore = GameObject.Find ("Player Score").GetComponent<Text>();
			scenemanagerscript aScript = GameObject.Find ("ship").GetComponent<scenemanagerscript> ();
			aScript.changescore += 100;
			currentscore.text = "Score: " + aScript.changescore.ToString ();
		}
	}
}
