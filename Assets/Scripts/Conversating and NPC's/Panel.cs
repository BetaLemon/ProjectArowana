using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public static Panel instance;
    Conversation currentConversation;
    Dialogue dialogue;
    int currentSentence;


    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
        dialogue = GetComponentInChildren<Dialogue>();
    }

    public void PlayConversation(Conversation conversation)
    {
        currentConversation = conversation;
        Debug.Log("Will play " + conversation.gameObject.name);
        gameObject.SetActive(true);

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
        dialogue.SetNextTexts(currentConversation.sentences[0].texts);
    }

}
