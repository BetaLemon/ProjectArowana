using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ConversationDisplayer : MonoBehaviour
{
    private Text _textComponent; //We save the text we want to write to the text component here

    public AudioSource TextSound;

    public string[] DialogueStrings; //All possible dialogues we wish to display
    Conversation currentConversation;

    int idxSentence;
    int idxText;
    int idxChar;

    enum State
    {
        RevealingText,
        WaitingForInput,
        Finished,
    };

    State currentState = State.RevealingText;

    public float SecondsBetweenCharacters = 0.03f; //Delay between character's being shown on the text display.
    public float CharacterRateMultiplier = 0.05f; //How much faster the text should go when the player holds down a key. (The lower the faster)

    public KeyCode DialogueInput = KeyCode.Return;
    bool startTheDialogue = false;

    public GameObject ContinueIcon;
    public GameObject StopIcon;

    //INICIAIZATION
    void Start()
    {
        _textComponent = GetComponent<Text>();
        _textComponent.text = ""; //Emptying text display just for good measure.

        ContinueIcon.SetActive(false);
        StopIcon.SetActive(false);
    }

    public void SetConversationAndStart(Conversation newConversation)
    {
        Debug.LogWarning("Acuerdate de cambiar el gráfico del personaje");
        
        currentConversation = newConversation;

        currentState = State.RevealingText;
        idxSentence = 0;
        idxText = 0;
        idxChar = 0;

        gameObject.SetActive(true);
    }

    public void StopConversation()
    {
        currentConversation = null;
        gameObject.SetActive(false);
        PlayerController.instance.startStopMovement(true);
    }


    //UPDATE ONCE PER FRAME
    float timeLeftToRevealNextChar = 0f;
    void Update()
    {
        switch (currentState)
        {
            case State.RevealingText:
                timeLeftToRevealNextChar -= Time.deltaTime;
                if (timeLeftToRevealNextChar < 0f)
                {
                    TextSound.Play();
                    _textComponent.text += currentConversation.sentences[idxSentence].texts[idxText][idxChar];
                    idxChar++;

                    if (idxChar >= currentConversation.sentences[idxSentence].texts[idxText].Length)
                    {
                        currentState = State.WaitingForInput;
                        StopIcon.SetActive(true);
                    }

                    timeLeftToRevealNextChar = SecondsBetweenCharacters * CharacterRateMultiplier;
                }
                break;

            case State.WaitingForInput:
                if (Input.GetKeyDown(DialogueInput))
                {
                    idxChar = 0;
                    _textComponent.text = "";
                    idxText++;

                    if (idxText >= currentConversation.sentences[idxSentence].texts.Length)
                    {
                        idxSentence++;
                        if (idxSentence >= currentConversation.sentences.Length)
                        {
                            KillTheFuckingBox();
                        }
                        else
                        {
                            idxText = 0;
                            _textComponent.text = "";
                            currentState = State.RevealingText;
                            StopIcon.SetActive(false);

                            Debug.LogWarning("Acuerdate de cambiar el gráfico del personaje");
                        }
                    }
                    else
                    {
                        currentState = State.RevealingText;
                    }
                }
                break;
        }
    }

    private void KillTheFuckingBox() //Hace desaparecer el panel y termina la conversacion
    {
        Panel.instance.PanelActivation(false);
    }

    public void StartTheDialogue()
    {
        startTheDialogue = true;
    }
}
