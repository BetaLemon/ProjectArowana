using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    // Use this for initialization
    
    public ImageFader fadeImage;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.Find("Player").GetComponent<KeyPickup>().hasKey == true)
        {
            fadeImage.scenefinish = true;
        }
    }
}
