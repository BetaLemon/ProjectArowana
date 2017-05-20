using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Sprite))]

public class ImageDisplay : MonoBehaviour
{
    public static ImageDisplay instance;
    public Sprite anImage;

    private Image _imageComponent;

    void Start()
    {
        _imageComponent = GetComponent<Image>();
    }

    void Update()
    {
        anImage = ConversationDisplayer.displayerInstance.getImageWhoTalks();
        _imageComponent.sprite = anImage;
    }


}
