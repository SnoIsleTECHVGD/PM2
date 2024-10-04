using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteFridge : MonoBehaviour
{
    public KeyCode openUpShop;
    public bool canInteract;
    public bool isShopOpen;
    public GameObject shop;
    public GameObject Timer;
    public GameObject scrapCount;
    public GameObject minimap;
    public DialogueTrigger introToShop;
    public void Update()
    {
        if (Input.GetKeyDown(openUpShop) && canInteract == true && isShopOpen == false)
        {
            isShopOpen = true;
            shop.gameObject.SetActive(true);
            Time.timeScale = 0;
            Timer.gameObject.SetActive(false);
            scrapCount.gameObject.SetActive(false);
            minimap.gameObject.SetActive(false);
            introToShop.TriggerDialogue();
        }
        else if (Input.GetKeyDown(openUpShop) && canInteract == true && isShopOpen == true)
        {
            Time.timeScale = 1;
            isShopOpen = false;
            shop.gameObject.SetActive(false);
            Timer.gameObject.SetActive(true);
            scrapCount.gameObject.SetActive(true);
            minimap.gameObject.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canInteract = false;
        }
    }
}
