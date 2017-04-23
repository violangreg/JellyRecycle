using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour 
{
	public GameObject pooledObject;			// game objects that will be pooled (reused)
	public int pooledAmount;				// amount of game objects to pool
	private List<GameObject> _pooledObjects;			// list to store all the pooled objects

	// Use this for initialization
	void Start () 
	{
		_pooledObjects = new List<GameObject> ();

		// creates the pooled objects and put it in the list where it will be reused in the game over and over
		for (int i = 0; i < pooledAmount; i++) 
		{
			GameObject obj = (GameObject) Instantiate (pooledObject);		// instantiates the object that will be pooled
			obj.SetActive (false);											// set active to false (objs will be activated in update)
			_pooledObjects.Add (obj);										// add the object to the list
		}
	}

	// gets non-active pooled object in the game hierarchy (scene)
	public GameObject GetPooledObject() 
	{
		
		// find non-active pooled object in the list
		for (int i = 0; i < _pooledObjects.Count; i++) 
		{
			if (!_pooledObjects [i].activeInHierarchy) 
			{
				return _pooledObjects [i];
			}

		}

		GameObject obj = (GameObject)Instantiate (pooledObject);
		obj.SetActive (false);
		_pooledObjects.Add (obj);


		//Debug.Log ("test");
		return obj;

	}
		
}
