using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIntroSequence : MonoBehaviour {

    // Use this for initialization
    public GameObject lerpInit;
    public GameObject lerpEnd;
    float distanceJourney;
    float startTime;
	void Start () {
        startTime = Time.time;
        distanceJourney = Vector3.Distance(lerpInit.transform.position, lerpEnd.transform.position);
        gameObject.transform.position = lerpInit.transform.position;
	}
	
    public void CalcLerp(float speed)
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.05f, gameObject.transform.position.y, gameObject.transform.position.z);

        //lerp --> posinit, posfinal, recorrido hecho
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / distanceJourney;
        transform.position = Vector3.Lerp(lerpInit.transform.position, lerpEnd.transform.position, fracJourney);
        if (transform.position == lerpEnd.transform.position)
        {
            GameObject introManager = GameObject.Find("intromanager");
            introManager.GetComponent<IntroManager>().LerpDone();
        }
    }
}
