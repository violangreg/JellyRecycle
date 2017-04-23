using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	public GameObject obstacle;

	// Use this for initialization
	void Start () {
		Instantiate (obstacle, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
