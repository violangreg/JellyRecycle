using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour 
{
	public float speed = 0.0f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate( new Vector3 (0, 1, 0) * speed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == ("Player"))
		{
			Destroy(this.gameObject);
		}
	}
}
