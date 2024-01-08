using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int health;
    public int attack;


    public void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);  

        }
    }
}
