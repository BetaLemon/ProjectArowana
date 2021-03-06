﻿using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    // Use this for initialization
    
    public ImageFader fadeImage;
    private Animator animator;
    public int nextLevel;
    public bool autoActivate;
    public string bFileName;
    private int statusChecker;
    public AudioSource openedDoor;

    void Start () {
        animator = GetComponent<Animator>();

        //checker para no sobreescribir innecesariamente LOL
        statusChecker = PlayerPrefs.GetInt(bFileName, 0);

        //si el nivel 2 esta acabado previamente (se puede acceder a hubworld), se lleva al hub en vez de nivel 2
        //se hace con el nivel 2 porque podrian haber problemas si se hace reset quizas
        if (statusChecker > 0 && bFileName == "level1") nextLevel = 11;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GameObject.Find("Player").GetComponent<KeyPickup>().hasKey == true)
        {
            openedDoor.Play();
            PlayerController.instance.startStopMovement(false);
            //dependiendo si lo ha acabado con todos los coleccionables o no, tal y cual
            
            if (statusChecker == 0 || statusChecker == 1)
            {
                if (!GameObject.Find("Player").GetComponent<starPickup>().hasAll)
                    PlayerPrefs.SetInt(bFileName, 1);
                else
                    PlayerPrefs.SetInt(bFileName, 2);
            }
            
            fadeImage.nextScene = nextLevel;
            animator.SetBool("Open", true);
            fadeImage.scenefinish = true;
        }
        else if (collision.tag == "Player" && autoActivate)
        {
            openedDoor.Play();
            PlayerController.instance.startStopMovement(false);
            fadeImage.nextScene = nextLevel;
            animator.SetBool("Open", true);
            fadeImage.scenefinish = true;
        }
    }
}
