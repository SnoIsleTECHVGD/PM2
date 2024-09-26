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
    public GameObject ammo;
    void Start()
    {
        enemy = GetComponent<EnemyNewAI>();
        scraps = FindObjectOfType<Scraps>();
        maxScraps = enemy.thisEnemy.scrapMax;
        minScraps = enemy.thisEnemy.scrapMin;
        ammo = enemy.ammoCache.gameObject;
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
            Die();
        }
    }
    public void TakeDamage(int attack)
    {
    
    }
    void Die()
    {
        if (this.gameObject.CompareTag("Enemy"))
        {
            scraps.IncrementScrapCount(maxScraps, minScraps);
            Instantiate(ammo, this.transform.position, this.transform.rotation);
        }
        Destroy(gameObject);
    }
}

