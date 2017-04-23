using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

    public AudioSource sound;

    public void ChangeToScene(int sceneToChangeTo)
    {
		if (Time.timeScale == 0)
			Time.timeScale = 1;
        StartCoroutine(delay(sceneToChangeTo));
        sound.Play();
    }

    IEnumerator delay(int sceneToChangeTo)
    {
        yield return new WaitForSeconds(0.2f);
        
        if(sceneToChangeTo == 5)
        {
            Application.Quit();
        }
        else
        {
            Application.LoadLevel(sceneToChangeTo);
        }

    }

}
