using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public static Panel instance;
    Conversation currentConversation;
    Dialogue dialogue; //
    int currentSentence;


    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false); //Asegura que no se muestra el panel primero
        dialogue = GetComponentInChildren<Dialogue>(); //Asigna el dialogo
    }

    public void PlayConversation(Conversation conversation) //Esta funcion se ejecuta desde el launch
    {
        currentConversation = conversation; //Guarda la conversacion que habiamos recogido en dialoguelaunch como conversacion actual para el panel.
        Debug.Log("Will play " + conversation.gameObject.name);
        gameObject.SetActive(true); //Muestra el panel

        currentSentence = 0;

        DoPlayCurrentSentence();
    }

    //public void NotifyTextsFinished()
    //{
    //    currentSentence++;
    //    if (SHADEFER("Faltan textos por mostrar"))
    //    {
    //        DoPlayCurrentSentence();
    //    }
    //}

    void DoPlayCurrentSentence()
    {
        //SHADEFER("Cambiar el texto con el nombre del personaje que habla");
        //SHADEFER("Cambiar el grafico del personaje que habla");
        dialogue.SetNextTexts(currentConversation.sentences[0].texts); //La conversación actual que hemos asignado como la que hemos recogido desde el Dialogue Launch será la que se muestre en Dialogue.cs
    }

}
