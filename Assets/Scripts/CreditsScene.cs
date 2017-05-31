using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreditsScene : MonoBehaviour {

    // Use this for initialization
    float timer;
    public float timeTilNextScene;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.02f, gameObject.transform.position.z);

        //go to stat scene
        if (timer > timeTilNextScene) SceneManager.LoadScene(10);
    }
}
