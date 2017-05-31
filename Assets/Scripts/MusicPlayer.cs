using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public AudioSource audioFileStart;
    public AudioSource audioFileLoop;
    private bool looped;
	void Awake () {
        audioFileStart.Play();
        looped = false;
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(audioFileStart.time == 45.019f && !looped)
        {
            audioFileLoop.Play();
            audioFileStart.Stop();
            looped = true;
        }
	}
    public void destroyMe()
    {
        Destroy(gameObject);
    }
}
