using UnityEngine;
using System.Collections;

// BGLooper handles the infinite scrolling illusion by using panels of sprites and looping them forward after they hit the loopingPoint  

public class BGLooper : MonoBehaviour {

	private GameObject looperPoint;		// loopingPoint is a transparent object when passed by another object in game that object will be looped forward	
	public LayerMask layer;				// layer is the LayerMask of the object
	public int numPanels;				// number of panels thats going to be looped around (creating an illusion of never ending background per say)

	void Start ()
	{
		looperPoint = GameObject.Find ("BGLooper");		// finds the BGLooper object
	}
/*
	void Update()
	{
		// if this object 
		if (transform.position.x < looperPoint.transform.position.x) 
		{
			gameObject.SetActive (false);
		}
	}
*/

	// When loopingPoint collides with another object in game, the collided object (collider) is looped forward.
	void OnTriggerEnter2D(Collider2D collider)
	{
		//Debug.Log ("Triggered: " + collider.name); //used for testing/debugging purposes
        if (collider.IsTouchingLayers(layer))
        {
            float heightOfBGObject = collider.bounds.size.y;		// get the width of the collided object
            Vector3 position = collider.transform.position;		// get the position of the collided object

			position.y += heightOfBGObject * numPanels;			// multiple the width and the number of objects of that object (illusion of forever scroller)

            collider.transform.position = position;				// chaneg the position of the collided object
        }
	}
}