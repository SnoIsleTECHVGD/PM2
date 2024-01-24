using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public cameraShake cameraShake;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Camera.main.GetComponent<cameraShake>().Shake(.15f, .4f));
    }
}
