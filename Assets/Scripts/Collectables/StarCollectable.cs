using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectable : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) //Algo ha tocado la estrella
    {

        if (other.gameObject == PlayerController.instance.gameObject) //Si el objeto que ha causado la colision es Kloe
        {
            Destroy(gameObject);
        }
    }
}
