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
    public GameObject level9mark2;
    public GameObject level10mark2;
    public Wind activateFan;
    public FountainScript activateFountain;

    public GameObject spawnZenku;
    public GameObject spawnZenku2;
    public GameObject spawnZenkuW1;
    public GameObject spawnZenkuW2;
    public GameObject spawnZenkuW3;
    public GameObject spawnZenkuW4;
    void Start () {

        spawnZenku.SetActive(false);
        spawnZenkuW1.SetActive(false);
        spawnZenkuW2.SetActive(false);
        spawnZenkuW3.SetActive(false);
        spawnZenkuW4.SetActive(false);

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
            spawnZenku2.SetActive(false);
        }
        else
            activateFountain.activable = false;

        if (l1C == 2 && l2C == 2) spawnZenkuW1.SetActive(true);
        if (l3C == 2 && l4C == 2) spawnZenkuW2.SetActive(true);
        if (l5C == 2 && l6C == 2) spawnZenkuW3.SetActive(true);
        if (l7C == 2 && l8C == 2) spawnZenkuW4.SetActive(true);

        //update stuff
        door1.GetComponent<hubDOOR>().UpdateState(l1C);
        door2.GetComponent<hubDOOR>().UpdateState(l2C);
        door3.GetComponent<hubDOOR>().UpdateState(l3C);
        door4.GetComponent<hubDOOR>().UpdateState(l4C);
        door5.GetComponent<hubDOOR>().UpdateState(l5C);
        door6.GetComponent<hubDOOR>().UpdateState(l6C);
        door7.GetComponent<hubDOOR>().UpdateState(l7C);
        door8.GetComponent<hubDOOR>().UpdateState(l8C);

        if (l9C == 2) level9mark2.SetActive(true);
        else level9mark2.SetActive(false);
        if (l10C == 2) level10mark2.SetActive(true);
        else level10mark2.SetActive(false);
        
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
