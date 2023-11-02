using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light flickeringLight;
    public float minIntensity = 0.1f;
    public float maxIntensity = 6.0f;
    public float flickerSpeed = 2.0f;

    private float randomInterval;
    private float timeElapsed = 0.0f;

    private void Start()
    {
        flickeringLight = GetComponent<Light>();
        randomInterval = Random.Range(0.1f, 1.0f);
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= randomInterval)
        {
            flickeringLight.intensity = Random.Range(minIntensity, maxIntensity);

            // Zresetuj czas i wybierz nowy losowy interwa³
            timeElapsed = 0.0f;
            randomInterval = Random.Range(0.1f, 1.0f);
        }
    }
}
