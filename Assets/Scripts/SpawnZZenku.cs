using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZZenku : MonoBehaviour {

    // Use this for initialization
    public GameObject Z;
	void Start () {
        Z.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        Z.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Z.SetActive(false);
    }
}
