using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string avoid;
    private void OnTriggerEnter(Collider other)
    {
        /*
        Stats hitstats = other.gameObject.GetComponent<Stats>();

        if (hitstats != null && hitstats.hasHealth == true && !other.CompareTag(avoid) && !other.CompareTag("Bullet"))
        {
            hitstats.health -= 10 - hitstats.defense;
            if (hitstats.health <= 0)
            {
                Destroy(hitstats.gameObject);
            }
        }
        if (other.CompareTag("Player") == false)
        {
            Destroy(gameObject);
        }
        */
    }
}
