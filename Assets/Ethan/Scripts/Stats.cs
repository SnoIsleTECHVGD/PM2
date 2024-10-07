using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

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
    public bool isBullet;
    public GameObject player;
    public Stats playerStats;
    public GameObject splodin;
    public Vignette vignette;
    //public GameObject daCamera = Camera.main.gameObject;
    void Start()
    {
        enemy = GetComponent<EnemyNewAI>();
        scraps = FindObjectOfType<Scraps>();
        maxScraps = enemy.thisEnemy.scrapMax;
        minScraps = enemy.thisEnemy.scrapMin;
        ammo = enemy.ammoCache.gameObject;
        if (isBullet == true)
        {
            player = GameObject.Find("Player");
            playerStats = player.GetComponent<Stats>();
            attack = playerStats.attack + attack;
        }
        vignette = Camera.main.GetComponent<Vignette>();
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
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Camera.main.GetComponent<cameraShake>().ChangeVignette());
            StartCoroutine(Camera.main.GetComponent<cameraShake>().Shake(.20f, 1f));
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
        Instantiate(splodin, this.transform.position, this.transform.rotation);
        Destroy(gameObject);
    }
}

