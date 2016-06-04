using UnityEngine;
using System.Collections;

public class strengthicon : MonoBehaviour 

{
	public GameObject StrengthIcon;

	//minoman's current strength icon
	public int curstricon;
	public Sprite[] striconstorage;
	public SpriteRenderer ingamesprite;

		void Update ()
	{
		Movementscript Movementscript = GameObject.Find ("Mino-man_Sprite").GetComponent<Movementscript>();
		curstricon = (int)Mathf.Floor (Movementscript.strength / 5) -1;
		Sprite strengthicon = gameObject.GetComponent<SpriteRenderer> ().sprite = striconstorage [curstricon];
		ingamesprite.sprite = strengthicon;
		//Debug.Log ("this happened");
	}


}
