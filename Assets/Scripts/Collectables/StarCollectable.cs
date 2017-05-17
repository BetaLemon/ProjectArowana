using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectable : MonoBehaviour {

    public int collectable; //Collectable ID#
    public static Collected instance; //Pasar el objeto instance aqui para que podamos usar sus funciones

    private void OnTriggerEnter2D(Collider2D other) //Algo ha tocado la estrella
    {

        if (other.gameObject == PlayerController.instance.gameObject) //Si el objeto que ha causado la colision es Kloe
        {
            instance.setCollected(collectable); //Funcion que realmente esta en Collected.cs
            Destroy(gameObject);
        }
    }
}
