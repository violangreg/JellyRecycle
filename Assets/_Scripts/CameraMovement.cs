using UnityEngine;
using System.Collections;

// not used

public class CameraMovement : MonoBehaviour {
	public GameObject player;			// Is the object that we're gonna pan our camera focus on
	private Vector3 offset;				// Is the offset 

	// Use this for initialization
	void Start () {
		offset = transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
