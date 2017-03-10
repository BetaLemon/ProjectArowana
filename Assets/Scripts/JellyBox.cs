using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyBox : MonoBehaviour {

    public Sprite idle; // Drag your first sprite here
    public Sprite crushed; // Drag your second sprite here
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
        spriteRenderer.sprite = crushed;
    }
    void OnCollisionStay2D(Collision2D collision)
    {

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("released");
        spriteRenderer.sprite = idle;
    }
}
