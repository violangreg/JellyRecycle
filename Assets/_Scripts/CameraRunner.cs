using UnityEngine;
using System.Collections;

// CameraRunner uses the camera object and follows the player
public class CameraRunner : MonoBehaviour {

	private Transform player; 		// is the transform of the player
	private float offSetY;			// is the offset x axis of the player
	public Player playa;

	void Start () 
	{
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");		// finds the player game object using its name tag "Player"

		if (player_go == null) 
		{
			Debug.LogError ("Couldn't find an object with tag 'Player'!");
		} 
		else 
		{
			player = player_go.transform;										// get the transform of the player
			offSetY = transform.position.y - player.position.y;					// get the offset of the player by using the transform of the camera pane - the position of the player's x axis
		}
	}

	void Update () 
	{
		if (player != null && !playa.isDead()) 													
		{
			Vector3 pos = transform.position;				// get the position of the camera
			pos.y = player.position.y + offSetY;			// set the position of the camera to the player and its offset
			transform.position = pos;						// apply the position to the camera
		}
	}
}
