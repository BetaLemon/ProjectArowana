using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlled : MonoBehaviour {

    private GameObject camStart;
    private GameObject camEnd;
    private GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        camStart = GameObject.Find("CamStart");
        camEnd = GameObject.Find("CamEnd");
        transform.position = new Vector3(camStart.transform.position.x,camStart.transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.x > camStart.transform.position.x)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
            //transform.position.x = player.transform.position.x;
        }
        if (player.transform.position.x > camEnd.transform.position.x)
        {
            transform.position = new Vector3(camEnd.transform.position.x, transform.position.y, transform.position.z);
        }
	}
}
