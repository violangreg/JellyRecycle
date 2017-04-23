using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Global Sound toggler
public class Sound : MonoBehaviour {
	
	private bool _tog;

	void Start() 
	{
		_tog = true;
	}

	public void Toggle()
	{
		if (_tog) 
		{
			AudioListener.volume = 0;
			_tog = false;
		} 
		else 
		{
			AudioListener.volume = 1;
			_tog = true;
		}
	}

}
