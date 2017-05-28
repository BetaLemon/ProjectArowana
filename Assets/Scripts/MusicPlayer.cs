using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public AudioSource audioFileStart;
    public AudioSource audioFileLoop;
    private bool looped;
    private float time;
	void Awake () {
        audioFileStart.Play();
        looped = false;
        time = 0.0f;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (time > audioFileStart.clip.length && !looped)
        {
            audioFileLoop.Play();
            audioFileStart.Stop();
            looped = true;
        }
        else
        {
            time += Time.deltaTime;
        }
	}
}
