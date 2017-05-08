using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyBoxChildColliders : MonoBehaviour {

    // Use this for initialization
    public JellyBox parent;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        parent.SendMessage("OnCollisionEnter2D", collision);
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        parent.SendMessage("OnCollisionExit2D", collision);
    }
}
