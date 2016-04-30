using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class defeatcanvasscript : MonoBehaviour 

{

	public Canvas usable;
	 
	void Start ()

	{
		usable.enabled = false;
	}
	
	void Update () 

	{
		
		if (Input.GetKey("escape"))
			{
				Application.Quit();
			}
		if (Input.GetKey("enter"))
			{
				SceneManager.LoadScene("Level_1");
			}
			
	}

	public void FleeGame ()

	{
		Application.Quit ();
	}

	public void EnterGame ()

	{
		SceneManager.LoadScene("Level_1");
	}

}
