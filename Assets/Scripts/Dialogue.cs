using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Dialogue : MonoBehaviour
{
    private Text _textComponent; //We save the text we want to write to the text component here

    public string[] DialogueStrings; //All possible dialogues we wish to display

    public float SecondsBetweenCharacters = 0.15f; //Delay between character's being shown on the text display.


	void Start () {
        _textComponent = GetComponent<Text>();
        _textComponent.text = ""; //Emptying text display just for good measure.
	}
	

	void Update () {
        if (Input.GetKeyDown(KeyCode.Return)) //Press "Enter" key
        {
            StartCoroutine(DisplayString(DialogueStrings[0])); //Starts the coroutine for displaying the string with the index we want.
        }
	}

    //Async thread "IEnumerator for adding characters to the current text being displayed. Because this needs a delay between characters, we are creating an IEnumerator "thread" for it:
    private IEnumerator DisplayString(string stringToDisplay) {
        int stringLength = stringToDisplay.Length;
        int currentCharacterIndex = 0;

        _textComponent.text = "";

        while (currentCharacterIndex < stringLength)
        {
            _textComponent.text += stringToDisplay[currentCharacterIndex]; //Adding a character to the display text.
            currentCharacterIndex++; //Next character please

            if (currentCharacterIndex < stringLength)
            {
                yield return new WaitForSeconds(SecondsBetweenCharacters); //The delay.
            }
            else
            {
                break;
            }
        }
        //_textComponent.text = ""; //Emptying the display text in order to not conflict with the following iteration of characters.
    }
}
