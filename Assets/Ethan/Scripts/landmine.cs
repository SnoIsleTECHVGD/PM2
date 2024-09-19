using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landmine : MonoBehaviour
{
    public int splodeTime;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Console.WriteLine("BOOOM");
        this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
        System.Threading.Thread.Sleep(splodeTime);
        Destroy(this.gameObject);

    }
}
