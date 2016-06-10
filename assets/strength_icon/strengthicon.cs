using UnityEngine;
using System.Collections;

public class strengthicon : MonoBehaviour 

{
	//minoman's current strength icon
	public int curstricon;
	public Sprite[] striconstorage;
	public SpriteRenderer ingamesprite;
	public GameObject Rage1;
	public GameObject Rage2;

	void Start ()
	{
		Instantiate (Rage1);
		Instantiate (Rage2);
		Rage1.GetComponent<Renderer> ().enabled = false;
		Rage2.GetComponent<Renderer> ().enabled = false;
	}

	void Update ()
	{
		Movementscript Movementscript = GameObject.Find ("Mino-man_Sprite").GetComponent<Movementscript>();
		curstricon = (int)Mathf.Floor (Movementscript.strength / 5) -1;
		if (Movementscript.ragecount == 0)
		{
			GameObject.Find ("Rageflame1_Icon(Clone)").GetComponent<Renderer> ().enabled = false;
			GameObject.Find ("Rageflame2_Icon(Clone)").GetComponent<Renderer> ().enabled = false;
		}
		else
		{
			GameObject.Find ("Rageflame1_Icon(Clone)").GetComponent<Renderer> ().enabled = true;
			GameObject.Find ("Rageflame2_Icon(Clone)").GetComponent<Renderer> ().enabled = true;
		}
		Sprite strengthicon = gameObject.GetComponent<SpriteRenderer> ().sprite = striconstorage [curstricon];
		ingamesprite.sprite = strengthicon;
		//Debug.Log ("this happened");
	}


}
