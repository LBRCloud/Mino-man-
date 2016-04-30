using UnityEngine;
using System.Collections;

public class ScrollingUVs : MonoBehaviour {
	Renderer backRender;
	public float backScroll = .2f;
	float backoffSet;
	// Use this for initialization
	void Start () {
		backRender = gameObject.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void LateUpdate () 

	{
		backoffSet += backScroll * Time.deltaTime;
		backRender.material.mainTextureOffset = new Vector2 (0f, backoffSet % 1);
	}
}
