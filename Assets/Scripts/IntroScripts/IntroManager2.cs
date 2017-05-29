using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager2 : MonoBehaviour {

    // Use this for initialization
    float timeInScene;
    bool dialogueLaunched;
    public GameObject convI;
	void Start () {
        PlayerPrefs.SetFloat("Time", 0);
        timeInScene = 0.0f;
        dialogueLaunched = false;
        
	}
	
	// Update is called once per frame
	void Update () {
        timeInScene = Time.time;

        if (timeInScene > 0.2f && !dialogueLaunched)
        {
            convI.GetComponent<DialogueLaunch>().StartConv();
            dialogueLaunched = true;
        }
    }
}
