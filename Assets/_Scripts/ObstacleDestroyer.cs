using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObstacleDestroyer : MonoBehaviour {

    private GameObject _destroyerPoint;

    // Use this for initialization
    void Start ()
	{
		_destroyerPoint = GameObject.Find ("DestroyerPoint");
	}

	void Update()
	{
		if (this.transform.position.y < _destroyerPoint.transform.position.y) 
		{
			gameObject.SetActive (false);
		}
	}

}
