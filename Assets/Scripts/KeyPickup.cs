using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyPickup : MonoBehaviour {

    public bool hasKey;
    public GameObject hudkey;
	// Use this for initialization
	void Start () {
        hudkey = GameObject.Find("hudkey");
        hudkey.SetActive(false);
     }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Key")
        {
            Destroy(other.gameObject);
            hudkey.SetActive(true);
            hasKey = true;
        }
           
    }
}