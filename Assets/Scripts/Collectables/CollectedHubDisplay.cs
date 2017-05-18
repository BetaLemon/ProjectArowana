using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedHubDisplay : MonoBehaviour
{

    public int level; //Level ID#
    //Do we have these optional pickups?:
    public bool collectable1;
    public bool collectable2;
    public bool collectable3;

    // Use this for initialization
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);

        if (collectable1)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        if (collectable2)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        if (collectable3)
        {
            transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}