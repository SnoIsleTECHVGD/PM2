using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMiniMap : MonoBehaviour
{
    public GameObject miniMap;
    public bool miniMapOpen;
    public KeyCode miniMapToggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(miniMapToggle) && miniMapOpen == false)
        {
            miniMapOpen = true;
            miniMap.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(miniMapToggle) && miniMapOpen == true)
        {
            miniMapOpen = false;
            miniMap.gameObject.SetActive(false);
        }
    }
}
