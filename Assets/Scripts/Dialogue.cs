using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Dialogue : MonoBehaviour
{
    private Text _textComponent; //We save the text we want to write to the text component here

    public string[] DialogueStrings; //All possible dialogues we wish to display

    public float SecondsBetweenCharacters = 0.03f; //Delay between character's being shown on the text display.
    public float CharacterRateMultiplier = 0.5f; //How much faster the text should go when the player holds down a key.

    public KeyCode DialogueInput = KeyCode.Return; //The key that will speed up dialogue.

    private bool _isStringBeingRevealed = false; //Makes sure the coroutine isn't being called multiple times while it's being run.
    private bool _isDialoguePlaying = false;
    private bool _isEndOfDialogue = false;

    public GameObject ContinueIcon;
    public GameObject StopIcon;

    //INICIAIZATION
    void Start () {
        _textComponent = GetComponent<Text>();
        _textComponent.text = ""; //Emptying text display just for good measure.

        HideIcons();
    }
	
    //UPDATE ONCE PER FRAME
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Return)) //Press "Enter" key
        {
            if (!_isDialoguePlaying){ //Don't call the corutine unless it's available.
                _isDialoguePlaying = true; //The boolean will stop the corutine from being called again.
                StartCoroutine(StartDialogue()); //Starts the coroutine for displaying the string with the index we want.
            }
        }
	}

    private IEnumerator StartDialogue()
    {
        int dialogueLength = DialogueStrings.Length;
        int currentDialogueIndex = 0;

        while (currentDialogueIndex < dialogueLength || !_isStringBeingRevealed)
        {
            if (!_isStringBeingRevealed)
            {
                _isStringBeingRevealed = true;
                StartCoroutine(DisplayString(DialogueStrings[currentDialogueIndex++]));

                if (currentDialogueIndex >= dialogueLength)
                {
                    _isEndOfDialogue = true;
                }
            }

            yield return 0;
        }

        while (true)
        {
            if (Input.GetKeyDown(DialogueInput))
            {
                break;
            }

            yield return 0;
        }

        HideIcons();
        _isEndOfDialogue = false;
        _isDialoguePlaying = false;
    }

    //Async thread "IEnumerator for adding characters to the current text being displayed. Because this needs a delay between characters, we are creating an IEnumerator "thread" for it:
    private IEnumerator DisplayString(string stringToDisplay)
    {
        int stringLength = stringToDisplay.Length;
        int currentCharacterIndex = 0;

        HideIcons();

        _textComponent.text = "";

        while (currentCharacterIndex < stringLength)
        {
            _textComponent.text += stringToDisplay[currentCharacterIndex]; //Adding a character to the display text.
            currentCharacterIndex++; //Next character please

            if (currentCharacterIndex < stringLength)
            {
                if (Input.GetKey(DialogueInput))
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters * CharacterRateMultiplier); //Reduced delay due to player request.
                }
                else
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters); //The normal delay.
                }
            }
            else
            {
                break;
            }
        }

        ShowIcon();

        while (true) //Pausa el dialogo cuando todo el string ha sido revelado
        {
            if (Input.GetKeyDown(DialogueInput)) //Si se ejecuta el DialogueInput de nuevo, se rompe el bucle que detiene el texto parado y pasamos al siguiente.
            {
                break;
            }

            yield return 0;
        }

        HideIcons();

        _isStringBeingRevealed = false;
        _textComponent.text = ""; //Emptying the display text in order to not conflict with the following iteration of characters.
    }

    private void HideIcons()
    {
        ContinueIcon.SetActive(false);
        StopIcon.SetActive(false);
    }

    private void ShowIcon()
    {
        if (_isEndOfDialogue)
        {
            StopIcon.SetActive(true);
            return;
        }

        ContinueIcon.SetActive(true);
    }
}
