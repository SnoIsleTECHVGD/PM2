using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteFridge : MonoBehaviour
{
    public Scraps scraps;
    
    public void Update()
    {
        if (scraps.scrapsNeeded <= scraps.scrapCount)
        {
            gameObject.SetActive(false);
        }
    }
}
