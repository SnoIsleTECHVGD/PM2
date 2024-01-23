using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionTimer : MonoBehaviour
{
    public GameObject timer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        timer.SetActive(true);
        timer.GetComponent<Timer>().enabled = true;
    }
}
