using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    //public Stats stats;
    public void OnCollisionEnter(Collision collision)
    {
        /*
        Enemy other = collision.gameObject.GetComponent<Enemy>();
        if (other)
        {
            // HERE we know that the other object we collided with is an enemy
            print("Has collided!!");
            other.stats.hitPoints = -damage;
        }

          print("Has collided!!");

          stats.hitPoints =- damage; */



    }
}
