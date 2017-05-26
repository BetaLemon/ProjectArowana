using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePowersScript : MonoBehaviour {

    bool triggered;
    public GameObject thisKey;
	// Use this for initialization
	void Start () {
        triggered = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void destroyKey()
    {
        triggered = true;
        GameObject.Find("Player").GetComponent<PlayerController>().GivePowers();

         Destroy(thisKey);
        }
    }

