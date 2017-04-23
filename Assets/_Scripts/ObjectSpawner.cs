using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	public GameObject object_;
	public float maxPos;
	public float delayTimer;
	float timer;
	public Items_Pool itempool;
	public Player player;

	// Use this for initialization
	void Start () {
		timer = delayTimer;
	}
	
	// Update is called once per frame
	void Update () {
		
		// Timer to generate object again
		if (!player.isDead ()) {
			timer -= Time.deltaTime;

			if (timer <= 0) {

				// Position the object at random x pos
				Vector3 objectPos = new Vector3 (Random.Range (-maxPos, maxPos), transform.position.y, transform.position.z);
				Instantiate (itempool.getRandomItem (), objectPos, transform.rotation);

				// Reset timer
				timer = delayTimer;
			}
		}
	}



}
