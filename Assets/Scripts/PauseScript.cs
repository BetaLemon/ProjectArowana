using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    // Use this for initialization
    public GameObject pauseMenu;
    public Button resumeButton;
    public Button restartButton;
    public Button menuButton;

    public GameObject kHud;
    public GameObject timer;
    private bool paused;
  
    void Start () {
        kHud = GameObject.Find("Collecteds");
        pauseMenu = GameObject.Find("PauseMenu");
        resumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
        restartButton = GameObject.Find("RestartButton").GetComponent<Button>();
        menuButton = GameObject.Find("MenuButton").GetComponent<Button>();

        resumeButton.onClick.AddListener(ResumeButton);
        restartButton.onClick.AddListener(RestartButton);
        menuButton.onClick.AddListener(MenuButton);

        paused = false;
        pauseMenu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Pause") && !paused){
            paused = true;
            pauseMenu.SetActive(true);
            kHud.SetActive(false);
            Time.timeScale = 0;
        }
        else if (Input.GetButtonDown("Pause") && paused)
        {
            
            Time.timeScale = 1;
            kHud.SetActive(true);
            pauseMenu.SetActive(false);
            paused = false;
        }
	}
    
    void ResumeButton()
    {
        paused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    void RestartButton()
    {
        paused = false;
        Time.timeScale = 1;
        timer.GetComponent<TimeCounter>().SaveTimer();
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void MenuButton()
    {
        paused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(1);
    }
}