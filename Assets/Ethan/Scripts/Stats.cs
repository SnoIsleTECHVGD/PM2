using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int health;
    public int attack;
    //public gun heldGun;
    public Scraps scraps;
    public float maxScraps;
    public float minScraps;
    private EnemyNewAI enemy;
    void Start()
    {
        enemy = GetComponent<EnemyNewAI>();
        scraps = FindObjectOfType<Scraps>();
        maxScraps = enemy.thisEnemy.scrapMax;
        minScraps = enemy.thisEnemy.scrapMin;
    }
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
            if (this.gameObject.CompareTag("Enemy"))
            {
                scraps.IncrementScrapCount(maxScraps, minScraps);
            }
            Die();
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

