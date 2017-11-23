using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private float playerSpeed;
	Rigidbody2D playerRigidBody;
	private bool dead;
	public ScoreManager scoreManager;
	public float timer;
	private AudioSource dying;
	public float speedY, speedMultiplier, speedIncreaseMilestone;
	private float _speedMilestoneCount;
	public ObstacleGenerator obsGen1, obsGen2, obsGen3;

	// Use this for initialization
	void Start () {
		//playerSpeed = 0f;
		playerRigidBody = GetComponent<Rigidbody2D> ();
		dead = false;
		dying = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!dead) {
			MoveForward (playerSpeed);
			AccelerometerMove ();
		} else {
			MoveDown (playerSpeed);

			timer -= Time.deltaTime;
			if (timer <= 0) {
				playerRigidBody.velocity = Vector2.zero;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		// when the player collides with an object tagged as "Objects", it dies
		if (other.gameObject.tag == "Collectable")
		{
			scoreManager.IncreaseScore();
		}
		if (other.gameObject.tag == "Obstacle")
		{

			if (!dead) {
				dead = true;
				dying.Play ();
				scoreManager.ToggleRestartUIDisplay ();
				scoreManager.ToggleScoreText ();
			}
		}
	}



	void AccelerometerMove()
	{
		float x = Input.acceleration.x;
		//Debug.Log ("x = " + x);

		if (x < -0.1f) {
			MoveLeft ();
		} else if (x > 0.1f) {
			MoveRight ();
		} else {
			SetVelocityZero ();
		}

		MoveForward (playerSpeed);
	}

	void AccelerometerForce()
	{
		Vector2 force = new Vector2 (-Input.acceleration.x, 0) * playerSpeed;
		playerRigidBody.AddForce(force);
	}

	void MoveForward(float playerSpeed)
	{
		playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, playerSpeed);
	
		if (transform.position.y > _speedMilestoneCount)
		{
			_speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			speedY = speedY * speedMultiplier;

			obsGen1.distanceBetweenMinY = obsGen1.distanceBetweenMinY * speedMultiplier;
			obsGen1.distanceBetweenMaxY = obsGen1.distanceBetweenMaxY * speedMultiplier;

			obsGen2.distanceBetweenMinY = obsGen2.distanceBetweenMinY * speedMultiplier;
			obsGen2.distanceBetweenMaxY = obsGen2.distanceBetweenMaxY * speedMultiplier;

			obsGen3.distanceBetweenMinY = obsGen3.distanceBetweenMinY * speedMultiplier;
			obsGen3.distanceBetweenMaxY = obsGen3.distanceBetweenMaxY * speedMultiplier;
		}

		this.playerSpeed = speedY; 
	}

	void MoveDown(float playerSpeed)
	{
		playerRigidBody.velocity = new Vector2(0, -1);
		this.playerSpeed = 1; 
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

	public bool isDead(){
		return dead;
	}
}
