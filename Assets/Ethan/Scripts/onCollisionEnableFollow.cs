using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollisionEnableFollow : MonoBehaviour
{
    
    public GameObject player;
        public GameObject tutbot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tutbot.GetComponent<TutFollow>().enabled = true;
    }

}
