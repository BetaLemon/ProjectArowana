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

    public ImageFader fadeImage;
    // Use this for initialization
    void Start () {
        
        //this just activated the buttons
        startButton.onClick.AddListener(StartButton);
        optionsButton.onClick.AddListener(OptionsButton);
        exitButton.onClick.AddListener(ExitButton);
        backToMainMenuButton.onClick.AddListener(BackToMainMenu);
        optionsMenu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

    }
    void StartButton()
    {
        fadeImage.GetComponent<ImageFader>().scenefinish = true;
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
    
}
