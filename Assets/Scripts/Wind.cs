using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

    public bool activated;
    public bool triggerEnter;
    public float windSpeed;
    public bool windDirection; //true for X, false for Y
    public bool windWay; //true for up / right, false for down / left
    Vector2 speed;
	// Use this for initialization
	void Start () {
        triggerEnter = false;

        if (windDirection && windWay)
            speed = new Vector2(windSpeed, 0);

        else if (windDirection && !windWay)
            speed = new Vector2(-windSpeed, 0);
        
        else if (!windDirection && windWay)
            speed = new Vector2(0, windSpeed);
        
        else
            speed = new Vector2(0, -windSpeed);
    }
	
	// Update is called once per frame
	void Update () {

        //for test
        if (windDirection && windWay)
            speed = new Vector2(windSpeed, 0);

        else if (windDirection && !windWay)
            speed = new Vector2(-windSpeed, 0);

        else if (!windDirection && windWay)
            speed = new Vector2(0, windSpeed);

        else
            speed = new Vector2(0, -windSpeed);


        if (activated && triggerEnter && GameObject.Find("Player").GetComponent<PlayerController>().WeightMode == 0)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().rb2d.velocity = speed;
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
}
