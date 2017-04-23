using UnityEngine;
using System.Collections;

public class ObstacleGenerator : MonoBehaviour 
{

    private float _distanceBetweenX, _distanceBetweenY;

    public GameObject obstacle;
	public Transform generationPoint;
    public ObjectPooler objectPool;
    public float distanceBetweenMinX, distanceBetweenMaxX, distanceBetweenMinY, distanceBetweenMaxY, originalX;

	// Use this for initialization
	void Start () 
	{
		originalX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.y < generationPoint.position.y) 
		{
			_distanceBetweenX = Random.Range (distanceBetweenMinX, distanceBetweenMaxX);
			_distanceBetweenY = Random.Range (distanceBetweenMinY, distanceBetweenMaxY);

			// position of generator
			transform.position = new Vector2 (originalX, transform.position.y); 
			transform.position = new Vector2 (transform.position.x + _distanceBetweenX, transform.position.y + _distanceBetweenY); 

			//Instantiate (obstacle, transform.position, transform.rotation);
			GameObject newObstacle = objectPool.GetPooledObject ();
			//Debug.Log (newObstacle.name);

			//Debug.Log (newObstacle.transform.position);
			newObstacle.transform.position = transform.position;

			newObstacle.transform.rotation = transform.rotation;

			newObstacle.SetActive (true);
		}
	}

}
