using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class NameDisplay : MonoBehaviour
{
    public static NameDisplay instance;
    public string aName2;

    private Text _textComponent;
    void Start()
    {
        _textComponent = GetComponent<Text>();
        _textComponent.text = ""; //Emptying text display just for good measure.
    }

    void Update()
    {
        _textComponent.text = aName2;
    }

    public void updateName(string theName)
    {
        Debug.Log("NAME DISPLAYER RESPONDING");
        _textComponent.text = theName;
    }
}

