using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObstacleDestroyer : MonoBehaviour {

    private GameObject _destroyerPoint;
	private float originX, originY;

    // Use this for initialization
    void Start ()
	{
		_destroyerPoint = GameObject.Find ("Destroyer Point");
	}

	void Update()
	{
		if (transform.position.x < _destroyerPoint.transform.position.x) 
		{
			gameObject.SetActive (false);
		}
	}

}
