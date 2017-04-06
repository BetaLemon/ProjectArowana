using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    // Use this for initialization
    private bool paused;
	void Start () {
        paused = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Pause") && !paused){
            paused = true;
            Time.timeScale = 0;
        }
        else if (Input.GetButtonDown("Pause") && paused)
        {
            paused = false;
            Time.timeScale = 1;
           // SceneManager.LoadScene(5);
        }
	}
    
}