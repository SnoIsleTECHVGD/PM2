using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public float damage;
    public cameraShake cameraShake;
    public float speed = 20f;
    public Rigidbody2D rb;
    public void Start()
    {
        rb.velocity = transform.right * speed;
    }

    public void Update()
    {
      
    }
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        Destroy(gameObject);
        StartCoroutine(Camera.main.GetComponent<cameraShake>().Shake(.15f, .4f));
    }
    
}
