using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb2D.velocity.y < 0)
        {
            GetComponent<Animator>().SetInteger("Direction", 0);
        }
        if (rb2D.velocity.x < 0)
        {
            GetComponent<Animator>().SetInteger("Direction", 1);
        }
        if (rb2D.velocity.y > 0)
        {
            GetComponent<Animator>().SetInteger("Direction", 2);
        }
        if (rb2D.velocity.x > 0)
        {
            GetComponent<Animator>().SetInteger("Direction", 3);
        }
        
    }
}
