using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StatScreen : MonoBehaviour {

    public Text timeT;
    public Text statsT;
    public ImageFader fadeImage;
	void Start () {
        timeT = GameObject.Find("Finaltime").GetComponent<Text>();
        statsT = GameObject.Find("Completion").GetComponent<Text>();
        //get or calculate text values
        //time
        float time = PlayerPrefs.GetFloat("Time", 0);
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        string timeText = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

        //completion
        int l1C = PlayerPrefs.GetInt("level1", 0);
        int l2C = PlayerPrefs.GetInt("level2", 0);
        int l3C = PlayerPrefs.GetInt("level3", 0);
        int l4C = PlayerPrefs.GetInt("level4", 0);
        int l5C = PlayerPrefs.GetInt("level5", 0);
        int l6C = PlayerPrefs.GetInt("level6", 0);
        int l7C = PlayerPrefs.GetInt("level7", 0);
        int l8C = PlayerPrefs.GetInt("level8", 0);
        int l9C = PlayerPrefs.GetInt("level9", 0);
        int l10C = PlayerPrefs.GetInt("level10", 0);

        int totalScore = l1C + l2C + l3C + l4C + l5C + l6C + l7C + l8C + l9C + l10C;
        float percentage = totalScore / 20.0f * 100.0f;

        timeT.text = "Final time: " + timeText;
        statsT.text = "Completion: " + Mathf.Round(percentage).ToString() + "%";
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Switch"))
        {
            fadeImage.scenefinish = true;
        }
	}
}
