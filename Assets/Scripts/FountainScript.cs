using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainScript : MonoBehaviour {

    public bool activable; //activable after levels 1 - 8 are completed
    bool collisionEnter;
    public ImageFader fadeImage;
    public GameObject effect;
    public bool canActivateTimer;
    private float timer;
	void Start () {
        
        effect.SetActive(false);
        timer = 1.00f;
        canActivateTimer = false;
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer < 0) canActivateTimer = true;
		if (collisionEnter && Input.GetButtonDown("Switch") && activable && canActivateTimer)
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
