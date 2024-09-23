using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
using Pathfinding;
using UnityEditor.Rendering;

public class EnemyNewAI : MonoBehaviour
{
    [System.Serializable]
    public struct Enemy
    {
        public UnityEvent ability;
        public bool hasAbility;
        public float scrapMax;
        public float scrapMin;
        public float speed;
    }
    public Transform target;
    public float nextWaypointDistance = 3f;
    private Pathfinding.Path enemyPath;
    public int currentWaypoint = 0;
    private bool reachedEndOfPath = false;

    public Seeker seeker;
    public Rigidbody2D rb;

    public Enemy thisEnemy;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }



    void OnPathComplete(Pathfinding.Path p)
    {
        if (!p.error)
        {
            enemyPath = p;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (enemyPath == null)
        {
            return;
        }

        if (currentWaypoint >= enemyPath.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)enemyPath.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * thisEnemy.speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, enemyPath.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
