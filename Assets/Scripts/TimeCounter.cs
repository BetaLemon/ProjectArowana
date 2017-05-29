using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeCounter : MonoBehaviour {

    // Use this for initialization
    public bool countTime;
    float timer;
	void Start () {
        float timer = PlayerPrefs.GetFloat("Time", 0);

        TimeSpan timeSpan = TimeSpan.FromSeconds(timer);
        string timeText = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        print(timeText);
    }
	
	// Update is called once per frame
	void Update () {
        if (countTime)
            timer += Time.deltaTime;
    }
    public void SaveTimer()
    {
        PlayerPrefs.SetFloat("Time", timer);
    }
}
