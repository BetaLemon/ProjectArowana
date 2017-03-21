﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

    public bool activated;
    public bool triggerEnter;
    public float windSpeed;
    public bool windDirection; //true for X, false for Y
    public bool windWay; //true for up / right, false for down / left
    public float speedAdded;
    public float speedAddedOnFrame;
    public float maxWindSpeed;
    Vector2 speedVector;
	// Use this for initialization
	void Start () {
        triggerEnter = false;
        speedAddedOnFrame = 0.1f;
        windSpeed = 5;
        speedAdded = 0;
        speedAddedOnFrame = 0.1f;
        maxWindSpeed = 20;

        if (windDirection && windWay)
            speedVector = new Vector2(windSpeed, 0);

        else if (windDirection && !windWay)
            speedVector = new Vector2(-windSpeed, 0);
        
        else if (!windDirection && windWay)
            speedVector = new Vector2(0, windSpeed);

        else
            speedVector = new Vector2(0, -windSpeed);
    }
	
	// Update is called once per frame
	void Update () {

        if (triggerEnter && activated && triggerEnter && GameObject.Find("Player").GetComponent<PlayerController>().WeightMode == 0)
        {
            if (speedAdded < maxWindSpeed)
                 speedAdded += speedAddedOnFrame;
            //for test
            if (windDirection && windWay)
                speedVector = new Vector2(windSpeed + speedAdded, 0);

            else if (windDirection && !windWay)
                speedVector = new Vector2(-windSpeed - speedAdded, 0);

            else if (!windDirection && windWay)
                speedVector = new Vector2(0, windSpeed + speedAdded);

            else
                speedVector = new Vector2(0, -windSpeed - speedAdded);
        }
        else
        {
            speedAdded = 0;
        }
        
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        triggerEnter = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        triggerEnter = false;
    }
    public void ApplyWind()
    {
        if (activated && triggerEnter && GameObject.Find("Player").GetComponent<PlayerController>().WeightMode == 0)
        {
            PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
            player.rb2d.velocity -= speedVector;
            //in case the speed goes over expected (happens a lot when iddle), turn the velocity vector back to its maximum
            if (player.rb2d.velocity.x < -maxWindSpeed)  player.rb2d.velocity = new Vector2(-maxWindSpeed, player.rb2d.velocity.y);
            else if (player.rb2d.velocity.x > maxWindSpeed) player.rb2d.velocity = new Vector2(maxWindSpeed, player.rb2d.velocity.y);
            else if (player.rb2d.velocity.y < -maxWindSpeed) player.rb2d.velocity = new Vector2(player.rb2d.velocity.x, -maxWindSpeed);
            else if (player.rb2d.velocity.y > maxWindSpeed) player.rb2d.velocity = new Vector2(player.rb2d.velocity.x, maxWindSpeed);

        }
    }
}
