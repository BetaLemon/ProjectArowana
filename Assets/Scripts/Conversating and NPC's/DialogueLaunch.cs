using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLaunch : MonoBehaviour
{
    bool autoLaunchDialog = true;

    private void OnTriggerEnter2D(Collider2D other) //Función que ejecuta la caja de texto al triggear la colision del npc
    {
        if (other.gameObject == PlayerController.instance.gameObject)
        {
            Conversation conversation = GetComponentInChildren<Conversation>();
            Panel.instance.PlayConversation(conversation);
        }
    }
}
