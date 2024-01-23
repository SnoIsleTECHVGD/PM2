using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionGun : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetComponent<spawnBullet>().enabled = true;
    }
}
