using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject optionsMenu;
    public Button startButton;
    public Button exitButton;
    public Button optionsButton;
    public Button backToMainMenuButton;
    public Scene game;

    public Image fadeObject;
    Color c;
    float time = 1f;
    float fadeTime = 2f;

    private bool fadedIn = false;
    private bool fadedOut = false;
    // Use this for initialization
    void Start () {
        //this just activated the buttons
        startButton.onClick.AddListener(StartButton);
        optionsButton.onClick.AddListener(OptionsButton);
        exitButton.onClick.AddListener(ExitButton);
        backToMainMenuButton.onClick.AddListener(BackToMainMenu);
        optionsMenu.SetActive(false);

        //the image starts invisible
        fadeObject = GetComponent<Image>();
        c = fadeObject.color;
        c.a = 0;
        fadeObject.color = c;
    }
	
	// Update is called once per frame
	void Update () {
        //we substract the variable time every frame, when it gets to 0, the next event happens
        time -= Time.deltaTime;
        //if (fadedOut) SceneManager.LoadScene(1);
        if (!fadedIn && time <= 0)
        {
            print("lul");
            FadeIn();
        }
        //else if (fadedIn && time <= 0)
        //{
        //    FadeOut();
        //}
    }
    void StartButton()
    {
        
        SceneManager.LoadScene(2);
    }
    void OptionsButton()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    void ExitButton()
    {
        Application.Quit();
    }
    void BackToMainMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
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
