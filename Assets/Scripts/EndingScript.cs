using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour {


    public Image imgBG;
    private float time = 10.0f;
	// Use this for initialization
	void Start () {
        imgBG.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Application.Quit();
        }
	}
}
