using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCredits : MonoBehaviour
{

    // Use this for initialization
    private bool triggerEnter;
    private Animator animator;
    private bool activated = false;
    public AudioSource effect;
    public ImageFader fadeImage;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //si se activa, credits roll lmfao
        if (Input.GetButtonDown("Switch") && triggerEnter)
        {
            animator.SetBool("Activated", true);
            effect.Play();
            fadeImage.nextScene = 18;
            fadeImage.scenefinish = true;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        triggerEnter = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        triggerEnter = false;
    }
}
