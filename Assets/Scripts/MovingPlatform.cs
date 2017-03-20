using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public bool activated;
    public bool horizontalMovement;
    public float unitsAway;
    public int desiredSpeed;
    private Vector2 initPos;
    private Vector2 prevPos;
    private float timeActiveCount;
    private float diffSpace;
    void Start () {
        initPos = transform.position;
        timeActiveCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
    }
    void FixedUpdate()  // This update is called at the same framerate the game is working at. In general this is recommended for player movement and physics.
    {
        if (activated)
        {
            timeActiveCount += Time.deltaTime;
            if (horizontalMovement)
            {
                transform.position = new Vector2(initPos.x + Mathf.PingPong(timeActiveCount * desiredSpeed, unitsAway), transform.position.y);
                diffSpace = transform.position.x - prevPos.x;
            }
            else
            {
                transform.position = new Vector2(transform.position.x, initPos.y + Mathf.PingPong(timeActiveCount * desiredSpeed, unitsAway));
                diffSpace = transform.position.y - prevPos.y;
            }
            prevPos = transform.position;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (activated)
        {
            if (horizontalMovement)
                collision.transform.position = new Vector2(collision.transform.position.x + diffSpace, collision.transform.position.y);
            else
                collision.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y + diffSpace);
        }
    }

}
