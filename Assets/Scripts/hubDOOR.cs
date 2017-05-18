using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hubDOOR : MonoBehaviour {

    // Use this for initialization

    public ImageFader fadeImage;
    private Animator animator;
    public int levelDoor;
    public bool activable;
    private bool isCollided;
    public int state;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollided && Input.GetButtonDown("Switch") && activable)
        {
            fadeImage.nextScene = levelDoor;
            animator.SetBool("Open", true);
            fadeImage.scenefinish = true;
        }
    }

    public void UpdateState(int doorState)
    {
        state = doorState;

        //here goes sprite update
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        isCollided = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
            isCollided = false;
    }
}
