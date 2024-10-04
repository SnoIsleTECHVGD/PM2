using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimation : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private PolygonCollider2D pc2D;
    public bool isRanged;
    public EnemyNewAI AI;
    public EnemyProjectile firepoint1;
    public EnemyProjectile firepoint2;
    public EnemyProjectile firepoint3;
    public EnemyProjectile firepoint4;
    public GameObject light1;
    public GameObject light2;
    public float dotSuccess;
   
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        pc2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Dot(rb2D.velocity, Vector2.down) > dotSuccess)
        {
            light2.SetActive(false);
            light1.SetActive(false);
            GetComponent<Animator>().SetInteger("Direction", 0);
            Destroy(pc2D);
            pc2D = gameObject.AddComponent<PolygonCollider2D>();
            if (isRanged == true)
            {
                AI.projectile = firepoint1;
            }
        }
        else if (Vector2.Dot(rb2D.velocity, Vector2.left) > dotSuccess)
        {
            light2.SetActive(true);
            light1.SetActive(false);
            GetComponent<Animator>().SetInteger("Direction", 1);
            Destroy(pc2D);
            pc2D = gameObject.AddComponent<PolygonCollider2D>();
            if (isRanged == true)
            {
                AI.projectile = firepoint2;
            }
        }
        else if (Vector2.Dot(rb2D.velocity, Vector2.up) > dotSuccess)
        {
            light2.SetActive(false);
            light1.SetActive(false);
            GetComponent<Animator>().SetInteger("Direction", 2);
            Destroy(pc2D);
            pc2D = gameObject.AddComponent<PolygonCollider2D>();
            if (isRanged == true)
            {
                AI.projectile = firepoint4;
            }
        }
        else if (Vector2.Dot(rb2D.velocity, Vector2.right) > dotSuccess)
        {
            light2.SetActive(false);
            light1.SetActive(true);
            GetComponent<Animator>().SetInteger("Direction", 3);
            Destroy(pc2D);
            pc2D = gameObject.AddComponent<PolygonCollider2D>();
            if (isRanged == true)
            {
                AI.projectile = firepoint3;
            }
        }
        
    }
}
