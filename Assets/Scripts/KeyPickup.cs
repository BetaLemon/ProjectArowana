using UnityEngine;
using System.Collections;

public class KeyPickup : MonoBehaviour {

    public bool hasKey;
    public GameObject hudkey;

	// Use this for initialization
	void Start () {
        hasKey = false;
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
            print(other.gameObject.name);
            Destroy(other.gameObject);
            hudkey.SetActive(true);
            hasKey = true;
        }
        
           
    }
}