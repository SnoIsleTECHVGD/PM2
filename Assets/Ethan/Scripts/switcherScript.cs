using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switcherScript : MonoBehaviour
{
    public KeyCode Switch;
    public GameObject gun;
    public GameObject sword;
    public void Update()
    {
        if (Input.GetKeyDown("Switch") && gun.gameObject == false)
        {
            gun.gameObject.SetActive(true);
            sword.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown("Switch") && gun.gameObject == true)
        {
            gun.gameObject.SetActive(false);
            sword.gameObject.SetActive(true);
        }
    }
}
