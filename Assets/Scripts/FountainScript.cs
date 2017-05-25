using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainScript : MonoBehaviour {

    public bool activable; //activable after levels 1 - 8 are completed
    bool collisionEnter;
    public ImageFader fadeImage;
    public GameObject effect;

	void Start () {
        
        effect.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if (collisionEnter && Input.GetButtonDown("Switch") && activable)
        {
            fadeImage.nextScene = 14;
            fadeImage.scenefinish = true;
        }
        else if (activable)
        {
            effect.SetActive(true);
        }
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        collisionEnter = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collisionEnter = false;
    }
    public void updateState()
    {
        effect.SetActive(true);
    }
}
