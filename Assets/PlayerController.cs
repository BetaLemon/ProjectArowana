﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = false;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;
    public bool weightModeHeavy = false;

    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;
    private bool prevWeightMode = false;

    private float dist = 1.5f;
    private Vector2 dir = new Vector2(0,-1);
    private float hit;

    public LayerMask layerGround;
    RaycastHit2D rayCastHit2D = new RaycastHit2D();

    // Use this for initialization
    void Awake()
    {
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rayCastHit2D = Physics2D.Raycast(transform.position, dir.normalized, dist, layerGround);
        //Debug.Log(rayCastHit2D.collider != null ? rayCastHit2D.collider.gameObject : null, rayCastHit2D.collider != null ? rayCastHit2D.collider.gameObject : null);
        Debug.DrawRay(transform.position, dir * dist, Color.red, 0.1f);

        grounded = rayCastHit2D.collider != null;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
            print("Jumped");
        }

        if (Input.GetButtonDown("Weight"))
        {
            weightModeHeavy = !weightModeHeavy;
            print("Weight changed");
        }

        if(prevWeightMode != weightModeHeavy)
        {
            if (weightModeHeavy)
            {
                rb2d.mass = 15;
                rb2d.gravityScale = (float)2;
                jumpForce = 6000;
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                rb2d.mass = 2;
                rb2d.gravityScale = (float)0.6;
                jumpForce = 1000;
                transform.localScale = new Vector3(0.5f, 1, 1);
            }
        }
        prevWeightMode = weightModeHeavy;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        //anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump)
        {
            //anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
