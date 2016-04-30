using UnityEngine;
using System.Collections;

public class selfDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject, 10f);
	}
	public void OnCollisionEnter2D(Collision2D anObject)
	{
		//add points
		if (anObject.gameObject.name == "ship") {

			SpriteRenderer rendDisable = GameObject.Find ("ship").GetComponent<SpriteRenderer> ();
			rendDisable.enabled = false;
			ParticleSystem shipPart = GameObject.Find ("Shipparticle").GetComponent<ParticleSystem> ();
			shipPart.Play ();

			Destroy (anObject.gameObject, 1f);
			Destroy (gameObject, 1f);
			
		} 

		else if (anObject.gameObject.name == "beam(Clone)") 

		{
			Destroy (anObject.gameObject);
			//gameObject.collider2D = (false);
			Destroy (gameObject);
		}
	}


}
