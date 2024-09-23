using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private PolygonCollider2D pc2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        pc2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb2D.velocity.y < 0)
        {
            GetComponent<Animator>().SetInteger("Direction", 0);
            Destroy(pc2D);
            pc2D = gameObject.AddComponent<PolygonCollider2D>();
        }
        if (rb2D.velocity.x < 0)
        {
            GetComponent<Animator>().SetInteger("Direction", 1);
            Destroy(pc2D);
            pc2D = gameObject.AddComponent<PolygonCollider2D>();
        }
        if (rb2D.velocity.y > 0)
        {
            GetComponent<Animator>().SetInteger("Direction", 2);
            Destroy(pc2D);
            pc2D = gameObject.AddComponent<PolygonCollider2D>();
        }
        if (rb2D.velocity.x > 0)
        {
            GetComponent<Animator>().SetInteger("Direction", 3);
            Destroy(pc2D);
            pc2D = gameObject.AddComponent<PolygonCollider2D>();
        }
        
    }
}
