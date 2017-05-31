using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePowersScript : MonoBehaviour {

    bool triggered;
    public GameObject thisKey;
    GameObject player;
    public AudioSource getSound;
    // Use this for initialization
    void Start () {
        triggered = false;
        player = GameObject.Find("Player");

        if (PlayerPrefs.GetInt("level2", 0) > 0 && PlayerPrefs.GetInt("level1", 0) > 0) instaDestroy();
    }
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<PlayerController>().canMove && triggered)
        {
            player.GetComponent<PlayerController>().GivePowers();
            Destroy(gameObject);
        }
	}

    public void destroyKey() {
       triggered = true;
       getSound.Play();
       player.GetComponent<PlayerController>().GetKeyAnim();
       gameObject.GetComponent<SpriteRenderer>().sprite = null;
    }

    void instaDestroy()
    {
        player.GetComponent<PlayerController>().GivePowers();
        Destroy(gameObject);
    }
}

