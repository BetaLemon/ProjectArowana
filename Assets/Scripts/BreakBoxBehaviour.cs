﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBoxBehaviour : MonoBehaviour {

    Animator animator;
    private float prevSpeedY;
    private bool destroyBox;
    private float timeToDestroy = 0.5f;
    public AudioSource breakBox;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
        prevSpeedY = player.rb2d.velocity.y;

        if (destroyBox)
        {
            timeToDestroy -= Time.deltaTime;
            if (timeToDestroy < 0) Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (prevSpeedY < -20)
        {

            breakBox.Play();
            animator.SetBool("Break", true);
            destroyBox = true;
        }
    }
}
