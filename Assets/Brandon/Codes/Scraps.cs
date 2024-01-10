using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Scraps : MonoBehaviour
{
    public int scrapCount;
    public int scrapsNeeded;
    public UnityEvent pickupscrap;
    

    public void IncrementScrapCount()
    {
        float randomNumber = Random.Range(1, 5);
        float num = randomNumber;
        scrapCount = scrapCount + (int)num;
        
        GetComponent<TextMeshProUGUI>().text = $"Scraps: {scrapCount}";
    }
   
}
