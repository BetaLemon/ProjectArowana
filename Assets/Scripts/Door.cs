using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    // Use this for initialization
    
    public ImageFader fadeImage;
    private Animator animator;
    public int nextLevel;
    public bool autoActivate;
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GameObject.Find("Player").GetComponent<KeyPickup>().hasKey == true)
        {
            fadeImage.nextScene = nextLevel;
            animator.SetBool("Open", true);
            fadeImage.scenefinish = true;
        }
        else if (collision.tag == "Player" && autoActivate)
        {
            fadeImage.nextScene = nextLevel;
            animator.SetBool("Open", true);
            fadeImage.scenefinish = true;
        }
    }
}
