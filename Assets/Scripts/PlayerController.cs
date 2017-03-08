﻿// Necessary for Unity.
using UnityEngine;
using System.Collections;

// Every script is formed by one single class: (it is required that the filename is the same as the class' name, just like in Octave)
public class PlayerController : MonoBehaviour { // I don't know what MonoBehaviour means, just that Unity generates this automatically.

    [HideInInspector]                           // This is used for the variable defined after it to be hidden in Unity's inspector.
    public bool facingRight = true;             // Boolean used for knowing if the player faces Left or Right, so we can later flip the sprite.
    [HideInInspector]                           // This is used for the variable defined after it to be hidden in Unity's inspector.
    public bool jump = false;                   // Boolean that saves whether the player is jumping or not.
    public bool weightModeHeavy = false;        // Boolean that knows in which Weight Mode the player is in.
    public float speed;                         // Float that contains the speed at which the player moves horizontally.
    public float jumpHeight;                    // Float with the height at which the player will be able to jump.

    private bool grounded = false;              // Bool that knows if the player is touching the ground or not, so we avoid infinite jumping.
    private Rigidbody2D rb2d;                   // RigidBody2D for the player's RB2D. This is useful for position, scale, rotation, etc. of the player.
    private bool prevWeightMode = false;        // This just saves the mode set for the player's weight in the previous frame.

    private float dist = 1.6f;                  // Maximum distance to the floor, at which the Raycast will check if we are near it.
    private Vector2 dir = new Vector2(0,-1);    // Direction at which the Raycast has to look. In this is case, this is down (-y).

    public LayerMask layerGround;                       // This saves the layer in which the ground is contained. This is 'cause Unity has layers for every object.
    RaycastHit2D rayCastHit2D = new RaycastHit2D();     // Checks if the Raycast has hit the ground.

    // When the game starts, this is initialized:
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>(); // This will contain the player's RB2D.
    }

    // Update is called once per frame
    void Update()
    {
        rayCastHit2D = Physics2D.Raycast(transform.position, dir.normalized, dist, layerGround);  // Saves the collision with the ground (or the not collision).
        //Debug.Log(rayCastHit2D.collider != null ? rayCastHit2D.collider.gameObject : null, rayCastHit2D.collider != null ? rayCastHit2D.collider.gameObject : null);
        Debug.DrawRay(transform.position, dir * dist, Color.red, 0.1f);     // Draws the Raycast in form of a red line in the "Scene" tab of the Unity Editor.

        grounded = rayCastHit2D.collider != null;   // If the collider that the Raycast detected is null, then the statement will be false, and thus grounded too.
                                                    // But if the Raycast hit something, it will contain a collider and the statement will be true, and grounded too.

        if (Input.GetButtonDown("Jump") && grounded)    // If the player hits the "Jump" Button as configured in the Project Settings > Input.
        {
            jump = true;        // Set true the jumo bool.
            print("Jumped");    // Print "Jumped" just for debugging purposes. This needs to be removed in the final game.
        }

        if (Input.GetButtonDown("Weight"))          // If the player hits the "Weight" Button as configured in the Project Settings > Input.
        {
            weightModeHeavy = !weightModeHeavy;     // Inverts the value of the Weight Mode (Light->Heavy / Heavy->Light).
            print("Weight changed");                // Print "Weight changed" just for debugging purposes. This needs to be removed in the final game.
        }

        if(prevWeightMode != weightModeHeavy)                   // If the Weight Mode has changed from one frame to the next, then do...
        {
            if (weightModeHeavy)                                // ... if we are in the Heavy mode...
            {
                rb2d.mass = 15;                                 // ... set the mass to 15.
                rb2d.gravityScale = (float)2;                   // How much the gravity attracts things.
                                                                // For debugging purposes sets back the player's size if it has been changed in the else{} stat
                if (facingRight)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            else                                                // But if we are in Light mode...
            {
                rb2d.mass = 5;                                  // ... we set the mass to 5.
                rb2d.gravityScale = (float)0.7;                 // This is how much the gravity attracts.
                // And for debugging purposes me make the player narrower to see when he's in Light mode.
                if (facingRight)
                {
                    transform.localScale = new Vector3(0.5f, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-0.5f, 1, 1);
                }
            }
        }
        prevWeightMode = weightModeHeavy;                       // Update the weight mode so we can check in the next frame.
    }

    void FixedUpdate()  // This update is called at the same framerate the game is working at. In general this is recommended for player movement and physics.
    {
        // Move the player horizontally:
        float h = Input.GetAxis("Horizontal");      // Saves the input for the player's horizontal movement =>   [left-arrow] is -1 // [right-arrow] is 1 // [neutral] is 0
        //                                                                                                             <-                    ->                  --
        if (h != 0) // If the player has moved left or right/the movement is neutral, do...
        {
            rb2d.velocity = new Vector2(speed * h, rb2d.velocity.y);    // Change the player's y-axis speed accordingly. If h is negative, the speed too, and inverse too.
        }

        // This makes the sprite flip to the direction the player is looking at.
        if (h > 0 && !facingRight)      // If the player moves right (h = 1) and the sprite is not already looking right, then...
            Flip();                     // ...flip the sprite!
        else if (h < 0 && facingRight)  // If the player moves left (h = -1) and the sprite is not already looking left, then...
            Flip();                     // ...flip the sprite!

        // Applies the jump to the player.
        if (jump)   // If jump is true, ergo the player is jumpig. Duh.
        { 
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);   // Set the velocity to a 2D Vector that mantains the player's current x-axis movement, but sets the vertical speed to jumpHeight.
            jump = false;   // Set jump to false, as it has already jumped, and there is no point in repeating that.
        }
    }

    void Flip()     // As the name indicates, this function flips the sprite vertically. d->b | b->d
    {
        facingRight = !facingRight;                 // Switches whether it looks right or not.
        Vector3 theScale = transform.localScale;    // theScale saves the current scale of the player.
        theScale.x *= -1;                           // This modifies it to switch from left to right or viceversa.
        transform.localScale = theScale;            // This updates the player's scale to the one we've calculated.
    }
}
