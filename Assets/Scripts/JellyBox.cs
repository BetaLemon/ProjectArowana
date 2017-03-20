using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyBox : MonoBehaviour {

    public Sprite idle; // Drag your first sprite here
    public Sprite crushed; // Drag your second sprite here
    public int jumpSpeed;
    private bool crush = false;
    
    private SpriteRenderer spriteRenderer;

    

    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = idle; // set the sprite to sprite1
}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter");
        if (GameObject.Find("Player").GetComponent<PlayerController>().WeightMode == 2)
        {
            spriteRenderer.sprite = crushed;
            crush = true;
        }
        else
        {
            spriteRenderer.sprite = idle;
            crush = false;
        } 
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().WeightMode == 2)
        {
            spriteRenderer.sprite = crushed;
            crush = true;
        }
        else if (crush)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().jumpHeight = jumpSpeed;
            GameObject.Find("Player").GetComponent<PlayerController>().jump = true;
            spriteRenderer.sprite = idle;
            crush = false;
        }
        else
        {
            spriteRenderer.sprite = idle;
            crush = false;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("released");
        spriteRenderer.sprite = idle;
    }
}
