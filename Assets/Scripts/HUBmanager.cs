using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUBmanager : MonoBehaviour {

    // Use this for initialization, 0->not completed, 1-> completed, 2-> completed with collectables
    public int l1C;
    public int l2C;
    public int l3C;
    public int l4C;
    public int l5C;
    public int l6C;
    public int l7C;
    public int l8C;
    public int l9C;
    public int l10C;

    public hubDOOR door1;
    public hubDOOR door2;
    public hubDOOR door3;
    public hubDOOR door4;
    public hubDOOR door5;
    public hubDOOR door6;
    public hubDOOR door7;
    public hubDOOR door8;

    public Wind activateFan;
    public FountainScript activateFountain;

    public GameObject spawnZenku;
    void Start () {

        spawnZenku.SetActive(false);
        //get components
        l1C = PlayerPrefs.GetInt("level1", 0);
        l2C = PlayerPrefs.GetInt("level2", 0);
        l3C = PlayerPrefs.GetInt("level3", 0);
        l4C = PlayerPrefs.GetInt("level4", 0);
        l5C = PlayerPrefs.GetInt("level5", 0);
        l6C = PlayerPrefs.GetInt("level6", 0);
        l7C = PlayerPrefs.GetInt("level7", 0);
        l8C = PlayerPrefs.GetInt("level8", 0);
        l9C = PlayerPrefs.GetInt("level9", 0);
        l10C = PlayerPrefs.GetInt("level10", 0);

        if (l1C != 0 && l2C != 0 && l3C != 0 && l4C != 0 && l5C != 0 && l6C != 0 && l7C != 0 && l8C != 0)
        {
            activateFountain.activable = true;
            activateFountain.updateState();
            spawnZenku.SetActive(true);
        }
        else
            activateFountain.activable = false;

        //update stuff
        door1.GetComponent<hubDOOR>().UpdateState(l1C);
        door2.GetComponent<hubDOOR>().UpdateState(l2C);
        door3.GetComponent<hubDOOR>().UpdateState(l3C);
        door4.GetComponent<hubDOOR>().UpdateState(l4C);
        door5.GetComponent<hubDOOR>().UpdateState(l5C);
        door6.GetComponent<hubDOOR>().UpdateState(l6C);
        door7.GetComponent<hubDOOR>().UpdateState(l7C);
        door8.GetComponent<hubDOOR>().UpdateState(l8C);

        if (l5C > 0) activateFan.GetComponent<Wind>().activated = true;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ResetHubManager()
    {
        PlayerPrefs.SetInt("level1", 0);
        PlayerPrefs.SetInt("level2", 0);
        PlayerPrefs.SetInt("level3", 0);
        PlayerPrefs.SetInt("level4", 0);
        PlayerPrefs.SetInt("level5", 0);
        PlayerPrefs.SetInt("level6", 0);
        PlayerPrefs.SetInt("level7", 0);
        PlayerPrefs.SetInt("level8", 0);
        PlayerPrefs.SetInt("level9", 0);
        PlayerPrefs.SetInt("level10", 0);
    }
}
