using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected : MonoBehaviour {

    public static Collected instance; //Instancia para poder acceder a los datos a continuacion, remotamente.

    public int level; //Level ID#
    //Do we have these optional pickups?:
    public bool collectable1;
    public bool collectable2;
    public bool collectable3;

    public void setCollected(int theCollectable) //Function for setting collectables as collected (Is called by a StarCollectable.cs)
    {
        switch (theCollectable)
        {
            case 1:
                collectable1 = true;
                transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 2:
                collectable2 = true;
                transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 3:
                collectable3 = true;
                transform.GetChild(2).gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
    }
}
