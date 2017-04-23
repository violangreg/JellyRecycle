using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {
	private bool _tog;
	private GameObject paused, unPause;
	public PlayerManager player;
	public ScoreManager scoreManager;
	public AudioSource click;
	// Use this for initialization
	void Start () 
	{
		paused = GameObject.Find ("Paused");
		unPause = GameObject.Find ("UnPause");
		paused.SetActive (false);
		_tog = true;
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void Toggle()
	{
		click.Play ();									// play the click sound
		if (_tog) {
			_tog = false;								// for toggling between true and false

			paused.SetActive (true);					// show paused object active -- this shows the resume, menu, and exit
			unPause.SetActive (false);					// show unpaused object active -- this shows the cog gear

			Time.timeScale = 0;							// pauses the game

			// if the scoreManager is shown, undisplay it
			if (scoreManager.IsDisplayRestartUI ())
				scoreManager.ToggleRestartUIDisplay ();
		} else {
			_tog = true;

			paused.SetActive (false);
			unPause.SetActive (true);

			Time.timeScale = 1;		// resuming the game

			// if the scoreManager is not displayed and player is dead, display it
			if (!scoreManager.IsDisplayRestartUI () && player.isDead ())
				scoreManager.ToggleRestartUIDisplay ();
		}
	}
}
