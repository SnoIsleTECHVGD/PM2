using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;


public class ToggleLights : MonoBehaviour
{
    public Light2D[] lampLights;
    public Light2D[] otherLights;
    public LightFlicker[] flickers;
    public Color flashColor;
    public Color projectileColor;
    public Color defaultColor;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TurnOnAllLights()
    {
        foreach (Light2D light in lampLights)
        {
            light.enabled = true;
        }
        foreach (Light2D other in otherLights)
        {
            other.enabled = true;
        }
        foreach (LightFlicker flicker in flickers)
        {
            flicker.enabled = true;
        }
    }
    public void TurnOffAllLights()
    {
        foreach (LightFlicker flicker in flickers)
        {
            flicker.enabled = false;
        }
        foreach (Light2D other in otherLights)
        {
            other.enabled = false;
        }
        foreach (Light2D light in lampLights)
        {
            light.enabled = false;
        }
    }
    public void ColorAllLightsRed()
    {
        foreach (Light2D light in lampLights)
        {
            light.color = Color.red;
        }
        foreach (Light2D other in otherLights)
        {
            other.color = Color.red;
        }
    }

    public void ColorAllLightsGreen()
    {
        foreach (Light2D light in lampLights)
        {
            light.color = new Color (193f/255f, 254f/255f, 58f/255f);
        }
        foreach (Light2D other in otherLights)
        {
            other.color = new Color(193f / 255f, 254f / 255f, 58f / 255f);
        }
    }

    public void ColorAllLightsMagenta()
    {
        foreach (Light2D light in lampLights)
        {
            light.color = new Color(1f, 0f, 249f / 255f);
        }
        foreach (Light2D other in otherLights)
        {
            other.color = new Color(1f, 0f, 249f / 255f);
        }
    }

    public void DefaultColor()
    {
        foreach (Light2D light in lampLights)
        {
            light.color = new Color(196f / 255f, 217f / 255f, 162f / 255f);
        }
        foreach (Light2D other in otherLights)
        {
            other.color = new Color(170f / 255f, 1f, 250f / 255f);
        }
    }
}
