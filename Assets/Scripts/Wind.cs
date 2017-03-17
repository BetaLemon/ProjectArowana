using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

    public bool activated;
    public bool triggerEnter;
	// Use this for initialization
	void Start () {
        triggerEnter = false;
        activated = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (activated && triggerEnter && !GameObject.Find("Player").GetComponent<PlayerController>().weightModeHeavy)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().jump = true;
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
