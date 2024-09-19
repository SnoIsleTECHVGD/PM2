using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int health;
    public int attack;

    public Scraps scraps;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //TakeDamage();
        if (this.gameObject.CompareTag("Enemy") && collision.gameObject.CompareTag("Enemy"))
        {
            return;
        }
        this.gameObject.GetComponent<Stats>().health -= collision.gameObject.GetComponent<Stats>().attack;
        if (health <= 0)
        {
            Die();
            scraps.IncrementScrapCount();
        }
    }
    public void TakeDamage(int attack)
    {
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
