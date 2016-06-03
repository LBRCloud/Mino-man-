using UnityEngine;
using System.Collections;

public class strengthicon : MonoBehaviour 

{
	public GameObject StrengthIcon;

	//minoman's current strength icon
	public int curstricon;
	public Sprite[] striconstorage;
	public SpriteRenderer ingamesprite;

	void Start () 
	{
		Instantiate (StrengthIcon);
	}
	void Update () 

	{
		//strengthsprite = strengthsprite.GetComponent<Sprite> ();


		/*minogrey = gameObject.GetComponent<SpriteRenderer> ().color;
		minogrey = new Color (.5f, .1f, .9f);*/
	}


//	void strengthicongo ()
//	{
//		curstricon = (int)Mathf.Floor (strength / 15) -1;
//		ingamesprite.sprite = striconstorage [curstricon];
//	}

}
