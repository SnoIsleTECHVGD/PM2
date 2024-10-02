using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switcherScript : MonoBehaviour
{
    public KeyCode Switch;
    public GameObject player;
    public GameObject gun;
    public GameObject gunChild;
    public GameObject sword;
    public GameObject swordChild;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (sword.gameObject == true || gun.gameObject == false))
        {
            gun.gameObject.SetActive(true);
            gunChild.gameObject.SetActive(true);
            player.GetComponent<gun>().enabled = true;
            sword.gameObject.SetActive(false);
            swordChild.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && (gun.gameObject == true || sword.gameObject == false))
        {
            gun.gameObject.SetActive(false);
            gunChild.gameObject.SetActive(false);
            player.GetComponent<gun>().enabled = false;
            sword.gameObject.SetActive(true);  
            swordChild.gameObject.SetActive(true);
        }
    }
}
