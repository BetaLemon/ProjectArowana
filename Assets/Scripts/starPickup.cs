using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starPickup : MonoBehaviour {

    public bool hasAll; //if the played got all star fragments this goes true
    int starCount; //number of collected stars, from 0 to 3

    public GameObject hud1;
    public GameObject hud2;
    public GameObject hud3;
	void Start () {
        hasAll = false;
        starCount = 0;
        
        hud1 = GameObject.Find("Star1");
        hud2 = GameObject.Find("Star2");
        hud3 = GameObject.Find("Star3");

        hud1.SetActive(false);
        hud2.SetActive(false);
        hud3.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "star")
        {
            Destroy(other.gameObject);
            starCount++;
            if (starCount == 1)
            {
                hud1.SetActive(true);
            }
           else if (starCount == 2)
            {
                hud2.SetActive(true);
            }
            else if (starCount == 3)
            {
                hud3.SetActive(true);
                hasAll = true;
            }
        }

    }
}
