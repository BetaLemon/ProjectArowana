using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour {

    public Button startButton;
    public Button exitButton;
    public Scene game;
	// Use this for initialization
	void Start () {
        startButton.onClick.AddListener(StartButton);
        exitButton.onClick.AddListener(ExitButton);
    }
	
	// Update is called once per frame
	void Update () {
        
	}
    void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    void ExitButton()
    {

        Application.Quit();
    }
}
