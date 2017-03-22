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
	void Start () {
        animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Switch") && triggerEnter && platformSwitch)
        {
            activableObject.GetComponent<MovingPlatform>().activated = !activableObject.GetComponent<MovingPlatform>().activated;
        }

        else if (Input.GetButtonDown("Switch") && triggerEnter && !platformSwitch)
        {
            activableObject.GetComponent<Wind>().activated = !activableObject.GetComponent<Wind>().activated;

        }

        if (Input.GetButtonDown("Switch") && triggerEnter && !activated)
        {
            animator.SetBool("Activated", true);
            activated = true;
        }
        else if (Input.GetButtonDown("Switch") && triggerEnter & activated) {
            animator.SetBool("Activated", false);
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
