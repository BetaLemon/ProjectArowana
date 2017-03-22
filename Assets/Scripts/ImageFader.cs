using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ImageFader : MonoBehaviour {

    public Image fadeObject;
    
    public int nextScene;
    bool sceneStart = true;
    [HideInInspector]
    public bool scenefinish = false;
    private float fadeTime;
    // Use this for initialization
    void Start () {
        fadeObject.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
        fadeObject.color = Color.black;
        fadeTime = 3;
	}
	// Update is called once per frame
	void Update () {

       if (sceneStart) StartScene();
       if (scenefinish) EndScene(nextScene);
    }

    void FadeIn()
    {
        // Lerp the colour of the image between itself and transparent.
        fadeObject.color = Color.Lerp(fadeObject.color, Color.clear, fadeTime * Time.deltaTime);
    }
    
    void FadeOut()
    {
        // Lerp the colour of the image between itself and black.
        fadeObject.color = Color.Lerp(fadeObject.color, Color.black, fadeTime * Time.deltaTime);
        print(fadeObject.color.a);
    }

    public void StartScene()
    {
        FadeIn();
        if (fadeObject.color.a <= 0.1f)
        {
            fadeObject.color = Color.clear;
            fadeObject.enabled = false;
            sceneStart = false;
        }
    }
    public void EndScene(int sceneNumber)
    {
        if (!fadeObject.enabled) fadeObject.enabled = true;

        FadeOut();
        if (fadeObject.color.a >= 0.9f)
            {
                SceneManager.LoadScene(sceneNumber);
            }
        }
    
}
