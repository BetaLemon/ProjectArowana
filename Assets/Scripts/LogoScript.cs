using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScript : MonoBehaviour {
    public Image fadeObject;
    Color c;
    float time = 1f;
    float fadeTime = 2f;

    private bool fadedIn = false;
    private bool fadedOut = false;
    void Start()
    {
        //the image starts invisible
        fadeObject = GetComponent<Image>();
        c = fadeObject.color;
        c.a = 0;
        fadeObject.color = c;
    }
    void Update()
    {
        //we substract the variable time every frame, when it gets to 0, the next event happens
        time -= Time.deltaTime;
        if (fadedOut) SceneManager.LoadScene(1);
        else if (!fadedIn && time <= 0)
        {
            FadeIn();
        }
        else if (fadedIn && time <= 0)
        {
            FadeOut();
        }
    }

    void FadeIn()
    {
        //we add a bit of alpha every frame
        if (c.a < 1)
        {
            c.a += Time.deltaTime / fadeTime;
            fadeObject.color = c;
        }
        else
        {
            time = 0.5f;
            fadedIn = true;
        }
    }
    void FadeOut()
    {
        //we substract a bit of alpha every frame
        if (c.a > 0)
        {
            c.a -= Time.deltaTime / fadeTime;
            fadeObject.color = c;
        }
        else
        {
            fadedOut = true;
        }
    }
}

