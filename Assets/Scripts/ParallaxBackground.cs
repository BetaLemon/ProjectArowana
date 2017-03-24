using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {

    GameObject cam;
    GameObject camStart;

	// Use this for initialization
	void Start () {
        cam = GameObject.Find("Main Camera");
        camStart = GameObject.Find("CamStart");
        transform.position = new Vector3(camStart.transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3((cam.transform.position.x / 2)+10, transform.position.y, transform.position.z);
    }
}
