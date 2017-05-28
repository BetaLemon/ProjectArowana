using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLaunch : MonoBehaviour
{
    bool nowPressEnter = false;

    public KeyCode DialogueInput = KeyCode.Return; //The key that will speed up dialogue.

    private void OnTriggerEnter2D(Collider2D other) //Función que ejecuta la caja de texto al triggear la colision del npc
    {
        if (other.gameObject == PlayerController.instance.gameObject) //Si el objeto que ha causado la colision es Kloe
        {
            nowPressEnter = true; //Ahora si podemos pulsar enter para activar el dialogo desde el update
        }
    }

    private void OnTriggerExit2D(Collider2D other) //Salimos de la colision, por lo tanto no se puede pulsar enter para activar el dialogo
    {
        nowPressEnter = false;
        Panel.instance.StopConversation();
    }

    private void Update()
    {
        if (nowPressEnter &&
            Input.GetButtonDown("Switch") &&
            !Panel.instance.ConversationInProgress()
            || nowPressEnter && gameObject.tag == "keydialogue") //Comprobar si se ha pulsado enter mientras estabamos dentro de la colision
        {
            Conversation conversation = GetComponentInChildren<Conversation>(); //Recoge el elemento de conversacion del npc al qual va adjudicado este script
            Panel.instance.PlayConversation(conversation); //Ejecuta la funcion de reproducir conversacion en el Panel con la conversacion que hemos recogido

            if (gameObject.tag == "keydialogue")
            {
                nowPressEnter = false;
                gameObject.GetComponent<GivePowersScript>().destroyKey();
            }
        }
    }

    public void StartConv()
    {
        Conversation conversation = GetComponentInChildren<Conversation>(); //Recoge el elemento de conversacion del npc al qual va adjudicado este script
        Panel.instance.PlayConversation(conversation); //Ejecuta la funcion de reproducir conversacion en el Panel con la conversacion que hemos recogido
    }
}
