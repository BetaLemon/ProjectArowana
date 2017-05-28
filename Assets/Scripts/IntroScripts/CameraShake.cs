using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    // Use this for initialization
    bool finishedShake;
    float magnitude;
    float timeShaked;
    public float duration;
    Vector3 originCamPos;
    bool canShake;
    void Start() {
        finishedShake = false;
        timeShaked = 0.0f;
        magnitude = 1.0f;
    }
    void Update()
    {
        if (canShake)
        {
            timeShaked += Time.deltaTime;
            float percentComplete = timeShaked / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            gameObject.transform.position = new Vector3(x + originCamPos.x, y + originCamPos.y, originCamPos.z);
        }
        if (timeShaked > duration)
        {
            canShake = false;
        }
    }
    public void StartShake(float Emagnitude)
    {
        originCamPos = transform.position;
        magnitude = Emagnitude;
        canShake = true;
    }
}
