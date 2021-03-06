﻿// Necessary for Unity.
using UnityEngine;
using System.Collections;

// Every script is formed by one single class: (it is required that the filename is the same as the class' name, just like in Octave)
public class PlayerController : MonoBehaviour { // I don't know what MonoBehaviour means, just that Unity generates this automatically.

    [HideInInspector]
    public static PlayerController instance;

    public AudioSource jumpSound;
    public AudioSource fallSound;
    public AudioSource switchkeySoundLight;
    public AudioSource switchkeySoundHeavy;

    [HideInInspector]                           // This is used for the variable defined after it to be hidden in Unity's inspector.
    public bool facingRight = true;             // Boolean used for knowing if the player faces Left or Right, so we can later flip the sprite.
    [HideInInspector]                           // This is used for the variable defined after it to be hidden in Unity's inspector.
    public bool jump = false;                   // Boolean that saves whether the player is jumping or not.
    public float speed;                         // Float that contains the speed at which the player moves horizontally.
    public float jumpHeight;                    // Float with the height at which the player will be able to jump.
    //[HideInInspector]
    public int WeightMode = 1;

    private bool grounded = false;              // Bool that knows if the player is touching the ground or not, so we avoid infinite jumping.
    public Rigidbody2D rb2d;                   // RigidBody2D for the player's RB2D. This is useful for position, scale, rotation, etc. of the player.
    private CapsuleCollider2D playerCollider;   // CapsuleCollide2D of the player
    private int prevWeightMode;        // This just saves the mode set for the player's weight in the previous frame.

    private float dist = 0.65f;                  // Maximum distance to the floor, at which the Raycast will check if we are near it.
    private Vector2 dir = new Vector2(0,-1);    // Direction at which the Raycast has to look. In this is case, this is down (-y).

    public LayerMask layerGround;                       // This saves the layer in which the ground is contained. This is 'cause Unity has layers for every object.
    RaycastHit2D rayCastHit2D1 = new RaycastHit2D();     // Checks if the Raycast has hit the ground.
    RaycastHit2D rayCastHit2D2 = new RaycastHit2D();     // Checks if the Raycast has hit the ground.
    Animator animator;  //Reference to the animator component attatched to the player Kloe Game Object

    //Sistemas de particulas de caida al suelo de Kloe:
    public ParticleSystem fallParts;
    public ParticleSystem fallParts2;

    [HideInInspector]
    float timeSincePlayerStart = 0.0f; //Time since the player spawned in the scene
    float partsSoundsTriggerDelay = 1.0f;
    [HideInInspector]
    public bool triggerDelaySurpassed; //Used for stopping Play(); events for particles and sound on the start of a scene.

    [HideInInspector]
    public bool affectedByWind = false;
    [HideInInspector]
    public Vector2 windVector = new Vector2(0, 0);

    public bool canChangeWeight;        // Variable to control if the player can change his weight. In each scene we can decide whether it's true or not.
    public bool canMove = true;

    // When the game starts, this is initialized:
    void Awake()
    {
        instance = this;
        triggerDelaySurpassed = false; //Evitar que se ejecuten Play(); de sonido y particulas al inicio de spawneo en escena.

        rb2d = GetComponent<Rigidbody2D>(); // This will contain the player's RB2D.
        playerCollider = GetComponent<CapsuleCollider2D>();

        animator = GetComponent<Animator>();    //Assigns the Animator component from the player game object to the animator reference.
        if (canChangeWeight) GivePowers();
        canMove = true;
}

    // Update is called once per frame
    void Update()
    {
        timeSincePlayerStart += Time.deltaTime; //Time.deltaTime de UnityEngine da el tiempo entre frames.
        //Debug.Log(timeSincePlayerStart);
        if (timeSincePlayerStart > partsSoundsTriggerDelay)
        {
            triggerDelaySurpassed = true;
        }
        //Debug.Log(grounded);
        if (grounded)
        {
            //animator.SetBool("Jumping", false);
            animator.SetBool("Falling", false);
        }
        else {
            animator.SetBool("Running", false);
            animator.SetBool("Falling", true);
        }
        Vector3 d = new Vector3(playerCollider.GetComponent<CapsuleCollider2D>().size.x / 2, 0, 0);
        rayCastHit2D1 = Physics2D.Raycast(transform.position + d, dir.normalized, dist, layerGround);  // Saves the collision with the ground (or the not collision).
        rayCastHit2D2 = Physics2D.Raycast(transform.position - d, dir.normalized, dist, layerGround);  // Saves the collision with the ground (or the not collision).


        //Debug.Log(rayCastHit2D.collider != null ? rayCastHit2D.collider.gameObject : null, rayCastHit2D.collider != null ? rayCastHit2D.collider.gameObject : null);
        Debug.DrawRay(transform.position, dir * dist, Color.red, 0.1f);     // Draws the Raycast in form of a red line in the "Scene" tab of the Unity Editor.

        bool temp = grounded;
        if (rayCastHit2D1.collider != null || rayCastHit2D2.collider != null)
        {
            grounded = true;
        }
        else grounded = false;
        // If the collider that the Raycast detected is null, then the statement will be false, and thus grounded too.
        // But if the Raycast hit something, it will contain a collider and the statement will be true, and grounded too.
        if (!temp && grounded && triggerDelaySurpassed)
        { //Efectos de caída sobre el suelo
            //Decidiendo posicion de spawneo de particulas:
            Vector3 posParts = new Vector3(instance.transform.position.x +0.2f, instance.transform.position.y -0.6f, instance.transform.position.z);
            Vector3 posParts2 = new Vector3(instance.transform.position.x -0.2f, instance.transform.position.y -0.6f, instance.transform.position.z);

            fallParts.transform.position = posParts;
            fallParts2.transform.position = posParts2;

            //Rafaga de particulas:
            fallParts.Play();
            fallParts2.Play();
            //Sonido de caer:
            fallSound.Play();
        }
        if (Input.GetButtonDown("Jump") && grounded && canMove)    // If the player hits the "Jump" Button as configured in the Project Settings > Input.
        {
            //animator.SetBool("Jumping", true);
            jump = true;        // Set true the jump bool.
            jumpSound.Play();

        }

        if (Input.GetButtonDown("Weight") && canChangeWeight && canMove)          // If the player hits the "Weight" Button as configured in the Project Settings > Input.
        {
            switch (WeightMode)
            {
                case 0: //Light
                    WeightMode = 2; // -> Heavy
                    switchkeySoundLight.Play();
                    animator.SetBool("Heavy", true);
                    animator.SetBool("Light", false);
                    break;
                case 2: //Heavy
                    WeightMode = 0; // -> Light
                    switchkeySoundHeavy.Play();
                    animator.SetBool("Heavy", false);
                    animator.SetBool("Light", true);
                    break;
                default: //NoKey (Normal)
                    WeightMode = 1; // -> Normal (Same provably)
                    animator.SetBool("Heavy", false);
                    animator.SetBool("Light", false);
                    break;
            }

            //weightModeHeavy = !weightModeHeavy;     // Inverts the value of the Weight Mode (Light->Heavy / Heavy->Light).
           // print("Weight changed to " + WeightMode);                // Print "Weight changed" just for debugging purposes. This needs to be removed in the final game.
        }

        if(prevWeightMode != WeightMode)                   // If the Weight Mode has changed from one frame to the next, then do...
        {
            switch (WeightMode)                                // ... if we are in the Heavy mode...
            {
                case 2:
                    rb2d.mass = 3;                                 // ... set the mass to 15.
                    rb2d.gravityScale = (float)9;                   // How much the gravity attracts things.
                    jumpHeight = 24;
                    speed = 8;
                    break;
                case 1:
                    rb2d.mass = 5;                                  // ... we set the mass to 5.
                    rb2d.gravityScale = (float)5;                 // This is how much the gravity attracts.
                    jumpHeight = 18;
                    break;
                case 0:
                    rb2d.mass = 5;                                  // ... we set the mass to 5.
                    rb2d.gravityScale = (float)1.5;                 // This is how much the gravity attracts.
                    jumpHeight = 15;
                    speed = 8;
                    break;
            }
            /*else                                                // But if we are in Light mode...
            {
                rb2d.mass = 5;                                  // ... we set the mass to 5.
                rb2d.gravityScale = (float)0.7;                 // This is how much the gravity attracts.
                jumpHeight = 15;
                // And for debugging purposes me make the player narrower to see when he's in Light mode.
                if (facingRight)
                {
                    //dani here, added these transform 1,1 commentary to test the jellybox since this size change won't happen!
                    transform.localScale = new Vector3(1, 1, 1);
                    //transform.localScale = new Vector3(0.5f, 0.5f, 1);
                }
                else
                {
                   transform.localScale = new Vector3(-1, 1, 1);
                   //transform.localScale = new Vector3(-0.5f, 0.5f, 1);
                }
            }*/
        }
        prevWeightMode = WeightMode;                       // Update the weight mode so we can check in the next frame.
    }

    RaycastHit2D hitInfo2D;

    void FixedUpdate()  // This update is called at the same framerate the game is working at. In general this is recommended for player movement and physics.
    {
        if (canMove)
        {
            // Move the player horizontally:
            float h = Input.GetAxis("Horizontal");      // Saves the input for the player's horizontal movement =>   [left-arrow] is -1 // [right-arrow] is 1 // [neutral] is 0
                                                        //                                                                                                             <-                    ->                  --
                                                        //Debug.Log(h);
            if (h != 0) // If the player has moved left or right/the movement is neutral, do...
            {

                animator.SetBool("Running", true);

                Vector2 desiredHorizontalSpeed = new Vector2(speed * h, 0);

                // Let's check if there are obstacles
                // in the desired direction
                hitInfo2D = Physics2D.Raycast(transform.position, desiredHorizontalSpeed, playerCollider.size.x + 0.01f, layerGround);
                if (hitInfo2D.collider == null) { hitInfo2D = Physics2D.Raycast(transform.position + (Vector3.up * (playerCollider.size.y / 2f)), desiredHorizontalSpeed, playerCollider.size.x + 0.001f, layerGround); }
                if (hitInfo2D.collider == null) { hitInfo2D = Physics2D.Raycast(transform.position + (Vector3.up * (-playerCollider.size.y / 2f)), desiredHorizontalSpeed, playerCollider.size.x + 0.001f, layerGround); }
                // if (hitInfo2D.collider == null) { hitInfo2D = Physics2D.Raycast(transform.position + (Vector3.up * (playerCollider.size.y / 4f)), desiredHorizontalSpeed, playerCollider.size.x + 0.01f, layerGround); }
                //if (hitInfo2D.collider == null) { hitInfo2D = Physics2D.Raycast(transform.position + (Vector3.up * (-playerCollider.size.y / 4f)), desiredHorizontalSpeed, playerCollider.size.x + 0.01f, layerGround); }

                //Debug.Log(hitInfo2D.collider);

                if (hitInfo2D.collider != null)
                {
                    // There's an obstacle - do not change speed
                }
                else
                {
                    if (rb2d.velocity.x > speed || rb2d.velocity.x < -speed)
                    {
                        rb2d.velocity = new Vector2(rb2d.velocity.x + desiredHorizontalSpeed.x * 0.1f, rb2d.velocity.y);
                    }
                    else
                        rb2d.velocity = desiredHorizontalSpeed + (Vector2.up * rb2d.velocity.y);    // Change the player's y-axis speed accordingly. If h is negative, the speed too, and inverse too.

                }
            }
            else { animator.SetBool("Running", false); }

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

        //some wind spam here because my code sucks
        if (GameObject.Find("Wind1") != null)
            GameObject.Find("Wind1").GetComponent<Wind>().ApplyWind(this);
        if (GameObject.Find("Wind2") != null)
            GameObject.Find("Wind2").GetComponent<Wind>().ApplyWind(this);
        if (GameObject.Find("Wind3") != null)
            GameObject.Find("Wind3").GetComponent<Wind>().ApplyWind(this);
        if (GameObject.Find("Wind4") != null)
            GameObject.Find("Wind4").GetComponent<Wind>().ApplyWind(this);
        if (GameObject.Find("Wind5") != null)
            GameObject.Find("Wind5").GetComponent<Wind>().ApplyWind(this);
    }

    void Flip()     // As the name indicates, this function flips the sprite vertically. d->b | b->d
    {
        facingRight = !facingRight;                 // Switches whether it looks right or not.
        Vector3 theScale = transform.localScale;    // theScale saves the current scale of the player.
        theScale.x *= -1;                           // This modifies it to switch from left to right or viceversa.
        transform.localScale = theScale;            // This updates the player's scale to the one we've calculated.
    }

    public void GivePowers()
    {
       canChangeWeight = true;
       WeightMode = 2; // -> Heavy
        animator.SetBool("KeyGet", false);
       animator.SetBool("Heavy", true);

    }
    public void PlusBoxAffected()
    {
        WeightMode = 2;
        rb2d.mass = 3;                                 // ... set the mass to 15.
        rb2d.gravityScale = (float)9;                   // How much the gravity attracts things.
        jumpHeight = 24;
        speed = 8;
    }
    public void MinusBoxAffected()
    {
        WeightMode = 0;
        rb2d.mass = 5;                                  // ... we set the mass to 5.
        rb2d.gravityScale = (float)1.5;                 // This is how much the gravity attracts.
        jumpHeight = 15;
        speed = 8;
    }

    public void startStopMovement(bool startstop)
    {
        animator.SetBool("Running", false);
        canMove = startstop;
        rb2d.velocity = new Vector2(0, 0);

    }
    public void GetKeyAnim()
    {
        animator.SetBool("KeyGet", true);
    }
}
