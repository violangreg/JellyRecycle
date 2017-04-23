using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableDestroyer : MonoBehaviour {

	private GameObject _collectablePoint;

	// Use this for initialization
	void Start () {
		_collectablePoint= GameObject.Find ("CollectableDestroyer");
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y < _collectablePoint.transform.position.y) 
		{
			Destroy (this.gameObject);
		}
	}
}
