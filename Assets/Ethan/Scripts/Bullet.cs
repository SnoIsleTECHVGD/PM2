using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public float damage;

    public float speed = 20f;
    public Rigidbody2D rb;
    public Stats playerStats;
    public GameObject player;
    public Color damageColor;
    public Color healColor;
    public void Start()
    {
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<Stats>();
        rb.velocity = transform.right * speed;
        damage = damage + playerStats.attack;
    }

    public void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        Destroy(gameObject);
    }
}
