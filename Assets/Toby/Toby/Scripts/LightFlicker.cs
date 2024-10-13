using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    public Light2D lampLight;
    public float lightFlickerCountdown;
    public float countdownMax;
    public float timeOff;
    public Light2D[] lampLights;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        lightFlickerCountdown -= Time.deltaTime;
        if (lightFlickerCountdown <= 0)
        {
            TurnLightOff();
            Invoke("ResetTimer", timeOff);
        }
        else if (lightFlickerCountdown > 0)
        {
            TurnLightOn();
        }
    }

    public void TurnLightOn()
    {
        lampLight.enabled = true;
    }

    public void TurnLightOff()
    {
        lampLight.enabled = false;
    }

    public void ResetTimer()
    {
        lightFlickerCountdown = countdownMax;
    }
}
