using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour {

    public ImageFader fadeImage;
    public GameObject cameraI;
    public GameObject convI;
    public float cameraSpeed;
    public float magnitudeEarthquake;
    float timeInScene;
    bool dialogueLaunched;
    bool quakeLaunched;
    bool dialogueFinished;
    bool lerpFinished;
    bool quakeFinished;
    public AudioSource earthsound;
	void Start () {
        timeInScene = Time.time;
        dialogueLaunched = false;
        dialogueFinished = false;
        lerpFinished = false;
        quakeLaunched = false;
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
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
            earthsound.Play();
            cameraI.GetComponent<CameraShake>().StartShake(magnitudeEarthquake);
        }
        if (quakeFinished)
        {
            fadeImage.nextScene = 12;
            fadeImage.scenefinish = true;
        }
    }

    public void DialogueDone()
    {
        dialogueFinished = true;
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
    }
    public void LerpDone()
    {
        lerpFinished = true;
    }
    public void QuakeDone()
    {
        quakeFinished = true;
    }
}
