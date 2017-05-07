using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {

	// Use this for initialization
    public GameObject activableObject;
    public bool platformSwitch; // true for moving platform, false for wind
    private bool triggerEnter;
    private Animator animator;
    private bool activated = false;
    public AudioSource effect;
	void Start () {
        animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Switch") && triggerEnter && platformSwitch)
        {
            //activa o desactiva las plataformas que se mueven
            activableObject.GetComponent<MovingPlatform>().activated = !activableObject.GetComponent<MovingPlatform>().activated;
           
        }

        else if (Input.GetButtonDown("Switch") && triggerEnter && !platformSwitch)
        {
            //activa o desactiva los ventiladores
            activableObject.GetComponent<Wind>().activated = !activableObject.GetComponent<Wind>().activated;

        }

        if (Input.GetButtonDown("Switch") && triggerEnter && !activated)
        {
            //animacion a activarse
            animator.SetBool("Activated", true);
            effect.Play();
            activated = true;
        }
        else if (Input.GetButtonDown("Switch") && triggerEnter & activated) {
            //animacion a desactivarse
            animator.SetBool("Activated", false);
            effect.Play();
            activated = false;
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
