using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyBox : MonoBehaviour {

    public Sprite idle; // Drag your first sprite here
    public Sprite crushed; // Drag your second sprite here
    public int jumpSpeed;
    private bool crush = false;
    private bool collisionEnter;
    private int prevState;
    private SpriteRenderer spriteRenderer;
    Animator animator;

    void Start () {

        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject

        animator = GetComponent<Animator>();
        animator.SetBool("uncrush", false);
        animator.SetBool("crushed", false);


        collisionEnter = false;
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = idle; // set the sprite to sprite1
}
	
	// Update is called once per frame
	void Update () {
        if (collisionEnter)
        {
            if (GameObject.Find("Player").GetComponent<PlayerController>().WeightMode == 2)
            {
                crush = true;
                animator.SetBool("crushed", true);
            }
            else if (crush && prevState != GameObject.Find("Player").GetComponent<PlayerController>().WeightMode)
            {
                GameObject.Find("Player").GetComponent<PlayerController>().jumpHeight = jumpSpeed;
                GameObject.Find("Player").GetComponent<PlayerController>().jump = true;

                animator.SetBool("uncrush", true);
                crush = false;
            }
        }
  
        prevState = GameObject.Find("Player").GetComponent<PlayerController>().WeightMode;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(GameObject.Find("Player").GetComponent<PlayerController>().transform.position.y > this.transform.position.y)
        collisionEnter = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        collisionEnter = false;
        animator.SetBool("crushed", false);
        animator.SetBool("uncrush", false);
        crush = false;
    }
}
