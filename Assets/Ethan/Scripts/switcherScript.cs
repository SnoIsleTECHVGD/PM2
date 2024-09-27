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
        if (Input.GetKeyDown("Switch") && gameObject.GetComponent<swordParent>().enabled == true)
        {
            gun.gameObject.SetActive(true);
            sword.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown("Switch") && gameObject.GetComponent<swordParent>().enabled == false)
        {
            gun.gameObject.SetActive(false);
            sword.gameObject.SetActive(true);
        }
    }
}
