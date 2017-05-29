using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour {


    public Image imgBG;
	// Use this for initialization
	void Start () {
        imgBG.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
