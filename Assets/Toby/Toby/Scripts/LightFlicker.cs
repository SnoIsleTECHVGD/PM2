using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    public Light2D lampLight;
    public float timeToFlicker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Flicker());
    }
    private IEnumerator Flicker()
    {
        lampLight.enabled = false;
        yield return new WaitForSeconds(timeToFlicker);
        lampLight.enabled = true;
    }
}
