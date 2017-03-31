using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Dialogue : MonoBehaviour
{
    private Text _textComponent;

    public string[] DialogueStrings;

    public float SecondsBetweenCharacters = 0.15f;


	void Start () {
        _textComponent = GetComponent<Text>();
        _textComponent.text = "";
	}
	

	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(DisplayString(DialogueStrings[0]));
        }
	}

    private IEnumerator DisplayString(string stringToDisplay) {
        int stringLength = stringToDisplay.Length;
        int currentCharacterIndex = 0;

        _textComponent.text = "";

        while (currentCharacterIndex < stringLength) {
            _textComponent.text += stringToDisplay[currentCharacterIndex];
            currentCharacterIndex++;

            if (currentCharacterIndex < stringLength) {
                yield retrun new WaitForSeconds(SecondsBetweenCharacters);
            }
            else
            {
                break;
            }
        }
        _textComponent.text = "";
    }
}
