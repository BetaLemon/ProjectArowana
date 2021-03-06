﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyBox : MonoBehaviour {

    public Sprite idle; // Drag your first sprite here
    public Sprite crushed; // Drag your second sprite here
    public int jumpSpeed;
    public AudioSource comp;
    public AudioSource descomp;
    bool playCompSound;
    private bool crush = false;
    private bool collisionEnter;
    private bool changedCol;
    private int prevState;
    private SpriteRenderer spriteRenderer;
    Animator animator;
    
    GameObject idleCollider;
    GameObject crushedCollider;
    void Start () {
        playCompSound = true;
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject

        animator = GetComponent<Animator>();
        animator.SetBool("uncrush", false);
        animator.SetBool("crushed", false);


        collisionEnter = false;
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = idle; // set the sprite to sprite1

        idleCollider = transform.FindChild("Idle_Collider").gameObject;
        crushedCollider = transform.FindChild("Crushed_Collider").gameObject;
        crushedCollider.SetActive(false);

        changedCol = true;
    }

    // Update is called once per frame
    void Update () {
        if (collisionEnter)
        {
            if (GameObject.Find("Player").GetComponent<PlayerController>().WeightMode == 2)
            {
                if (playCompSound)
                {
                    comp.Play();
                    playCompSound = false;
                }
                crush = true;
                animator.SetBool("crushed", true);
                animator.SetBool("uncrush", false);
                idleCollider.SetActive(false);
                crushedCollider.SetActive(true);
                changedCol = false;
            }
            else if (crush && prevState != GameObject.Find("Player").GetComponent<PlayerController>().WeightMode)
            {
               PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
                player.rb2d.velocity += new Vector2(0, jumpSpeed);
                    
                animator.SetBool("uncrush", true);
                animator.SetBool("crushed", false);
                descomp.Play();
                crush = false;

                changedCol = false;
            }
        }
        else if (!changedCol)
        {
            idleCollider.SetActive(true);
            crushedCollider.SetActive(false);
            changedCol = true;
            animator.SetBool("uncrush", true);
            animator.SetBool("crushed", false);
        }
        
        prevState = GameObject.Find("Player").GetComponent<PlayerController>().WeightMode;
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(GameObject.Find("Player").GetComponent<PlayerController>().transform.position.y > this.transform.position.y)
        collisionEnter = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        collisionEnter = false;
        animator.SetBool("crushed", false);
        animator.SetBool("uncrush", false);
        crush = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().transform.position.y > this.transform.position.y)
        {
            collisionEnter = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        collisionEnter = false;
        animator.SetBool("crushed", false);
        animator.SetBool("uncrush", false);
        playCompSound = true;
        crush = false;
    }
}
