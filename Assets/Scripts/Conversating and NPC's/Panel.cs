using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Panel : MonoBehaviour
{
    public static Panel instance;

    Conversation currentConversation;
    Dialogue dialogue; //
    int sentencesAmmount;
    int currentSentence = 0;


    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false); //Asegura que no se muestra el panel primero
        dialogue = GetComponentInChildren<Dialogue>(); //Asigna el dialogo
    }

    public void PlayConversation(Conversation conversation) //Esta funcion se ejecuta desde el launch
    {
        currentConversation = conversation; //Guarda la conversacion que habiamos recogido en dialoguelaunch como conversacion actual para el panel.
        PanelActivation(true); //Muestra el panel

        sentencesAmmount = currentConversation.sentences.Length;

        DoPlayCurrentSentence();

    }

    public void StopConversation()
    {
        currentConversation = null;
        PanelActivation(false); //Esconde el panel

        BreakConversation();
    }

    public void PanelActivation(bool what) //Activar o desactivar panel
    {
        gameObject.SetActive(what);
    }

    public void NextSentencePlease() //Used by Dialogue for requesting the next sentence.
    {
        currentSentence++;
        Debug.Log("Current sentence: " + currentSentence);

        if (sentencesAmmount > currentSentence)
        {
            dialogue.SetNextTexts(currentConversation.sentences[currentSentence].texts);
            DoPlayCurrentSentence();
        }
        else if (sentencesAmmount == currentSentence) //No more sentences left to send
        {
            dialogue.NoMoreSentencesLeft();
        }
    }

    void DoPlayCurrentSentence() //Establece en el Dialogue.cs los datos de la conversacion y la ejecuta.
    {
        //SHADEFER("Cambiar el texto con el nombre del personaje que habla");
        //SHADEFER("Cambiar el grafico del personaje que habla");
        //Cambiar conversacion actual:
        dialogue.SetNextTexts(currentConversation.sentences[currentSentence].texts); //La conversación actual que hemos asignado como la que hemos recogido desde el Dialogue Launch será la que se muestre en Dialogue.cs
    }

    void BreakConversation() //Ordena a Dialogue.cs que pare la conversacion.
    {
        dialogue.StopConversation();
    }

}
