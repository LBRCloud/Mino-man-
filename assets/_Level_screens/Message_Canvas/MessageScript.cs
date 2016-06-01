using UnityEngine;
using System.Collections;

public class MessageScript : MonoBehaviour 

{

	public Canvas usable;



	void Start () 

	{
		StartCoroutine ("message");
	}
		
	IEnumerator message()
	{
		yield return new WaitForSeconds (2f);
		usable.enabled = false;
	}
		
}
