using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float playerSpeed;
	Rigidbody2D playerRigidBody;

	// Use this for initialization
	void Start () {
		//playerSpeed = 0f;
		playerRigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		MoveForward (playerSpeed);
		AccelerometerMove ();
	}

	void AccelerometerMove()
	{
		float x = Input.acceleration.x;
		Debug.Log ("x = " + x);

		if (x < -0.1f) {
			MoveLeft ();
		} else if (x > 0.1f) {
			MoveRight ();
		} else {
			SetVelocityZero ();
		}

		MoveForward (playerSpeed);
	}

	void MoveForward(float playerSpeed)
	{
		playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, playerSpeed);
		this.playerSpeed = playerSpeed; 
	}

	void MoveRight()
	{
		playerRigidBody.velocity = new Vector2 (playerSpeed, 0);
	}

	void MoveLeft()
	{
		playerRigidBody.velocity = new Vector2 (-playerSpeed, 0);
	}

	void SetVelocityZero()
	{
		playerRigidBody.velocity = Vector2.zero;
	}
}
