using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Scraps : MonoBehaviour
{
    int scrapCount;
    public UnityEvent pickupscrap;

    public void IncrementScrapCount()
    {
        scrapCount++;
        GetComponent<TextMeshProUGUI>().text = $"Scraps: {scrapCount}";
    }
}
