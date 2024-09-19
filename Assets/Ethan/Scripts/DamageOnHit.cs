using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.CompareTag("Enemy") && collision.gameObject.CompareTag("Enemy"))
        {
            return;
        }
        Stats ourStats = GetComponent<Stats>();
        Stats hitStats = collision.gameObject.GetComponent<Stats>();

        if (hitStats != null)
        {
            hitStats.health -= ourStats.attack;
        }
    }
}
