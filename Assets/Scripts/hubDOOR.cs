﻿using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hubDOOR : MonoBehaviour {

    // Use this for initialization

    public ImageFader fadeImage;
    private Animator animator;
    public int levelDoor;
    public bool activable;
    private bool isCollided;
    public int state;
    public GameObject s1Mark;
    public GameObject s2Mark;
    public AudioSource soundEffect;
    void Start()
    {
        animator = GetComponent<Animator>();
        s1Mark.SetActive(false);
        s2Mark.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollided && Input.GetButtonDown("Switch") && activable)
        {
            soundEffect.Play();
            PlayerController.instance.startStopMovement(false);
            fadeImage.nextScene = levelDoor;
            animator.SetBool("Open", true);
            fadeImage.scenefinish = true;
        }
    }

    public void UpdateState(int doorState)
    {
        state = doorState;
        if (state >= 1) s1Mark.SetActive(true);
        if (state == 2) s2Mark.SetActive(true);
        //here goes sprite update
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        isCollided = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
            isCollided = false;
    }
}
