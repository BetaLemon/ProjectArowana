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
    public Button resetButton;
    public Button backToMainMenuButton;
    public Scene game;

    public ImageFader fadeImage;
    public Image imageBG;
    // Use this for initialization
    void Start () {

        imageBG.rectTransform.localScale = new Vector2(Screen.width + 2, Screen.height);
        //this just activated the buttons
        startButton.onClick.AddListener(StartButton);
        optionsButton.onClick.AddListener(OptionsButton);
        exitButton.onClick.AddListener(ExitButton);
        backToMainMenuButton.onClick.AddListener(BackToMainMenu);
        resetButton.onClick.AddListener(ResetButton);
        optionsMenu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

    }
    void StartButton()
    {
        fadeImage.scenefinish = true;
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
    void ResetButton()
    {
        PlayerPrefs.SetInt("level1", 0);
        PlayerPrefs.SetInt("level2", 0);
        PlayerPrefs.SetInt("level3", 0);
        PlayerPrefs.SetInt("level4", 0);
        PlayerPrefs.SetInt("level5", 0);
        PlayerPrefs.SetInt("level6", 0);
        PlayerPrefs.SetInt("level7", 0);
        PlayerPrefs.SetInt("level8", 0);
        PlayerPrefs.SetInt("level9", 0);
        PlayerPrefs.SetInt("level10", 0);
    }
}
