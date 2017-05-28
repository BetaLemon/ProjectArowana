﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour {

    public GameObject cameraI;
    public GameObject convI;
    public float cameraSpeed;
    public float magnitudeEarthquake;
    float timeInScene;
    bool dialogueLaunched;
    bool quakeLaunched;
    bool dialogueFinished;
    bool lerpFinished;
	void Start () {
        timeInScene = Time.time;
        dialogueLaunched = false;
        dialogueFinished = false;
        lerpFinished = false;
        quakeLaunched = false;
    }
	
	// Update is called once per frame
	void Update () {
        timeInScene = Time.time;
        if (!lerpFinished)  cameraI.GetComponent<CameraIntroSequence>().CalcLerp(cameraSpeed);
        
        if (timeInScene > 1.0f && !dialogueLaunched) {
            convI.GetComponent<DialogueLaunch>().StartConv();
            dialogueLaunched = true;
        }

        if (dialogueFinished && lerpFinished && !quakeLaunched)
        {
            quakeLaunched = true;
            cameraI.GetComponent<CameraShake>().StartShake(magnitudeEarthquake);
        }
    }

    public void DialogueDone()
    {
        dialogueFinished = true;
    }
    public void LerpDone()
    {
        lerpFinished = true;
    }
}
