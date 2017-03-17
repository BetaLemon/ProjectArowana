using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusBox : MonoBehaviour
{
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision){
        
        if(GameObject.Find("Player").GetComponent<PlayerController>().weightModeHeavy){
            GameObject.Find("Player").GetComponent<PlayerController>().weightModeHeavy = false;
        }
    }
}
