using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public cameraShake cameraShake;
    public float speed = 20f;
    public Rigidbody2D rb;
    private void Start()
    {
        rb.velocity = transform.right * speed;
       
    }
    private void OnCollisionEnter2D(Collider2D hitInfo)
    {
        Debug.Log("Please work");
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
        StartCoroutine(Camera.main.GetComponent<cameraShake>().Shake(.15f, .4f));
    }
}
