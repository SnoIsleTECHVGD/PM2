using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;
using UnityEditor.Rendering;

public partial class EnemyNewAI : MonoBehaviour
{
    public Transform target;
    public float nextWaypointDistance = 3f;
    private Pathfinding.Path enemyPath;
    public int currentWaypoint = 0;
    private bool reachedEndOfPath = false;
    
    public GameObject ammoCache;
    public Seeker seeker;
    public Rigidbody2D rb;
    public bool hasAbility;
    public Enemy thisEnemy;
    public float abilityCountdown;
    public float abilityCountdownMax;
    
    public bool isRanged;
    public float playerDistance;
    public float slowdownDistance;
    public float runDistance;
    public EnemyProjectile projectile;
    public float runSpeed;
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
        if (isRanged == true)
        {
            playerDistance = Vector2.Distance((Vector2)target.position, (Vector2)transform.position);

            if (playerDistance > slowdownDistance)
            {
                abilityCountdown -= Time.deltaTime;
                if (abilityCountdown <= 0)
                {
                    projectile.Blast();
                    abilityCountdown = abilityCountdownMax;
                }
            }
            if (playerDistance <= slowdownDistance)
            {
                abilityCountdown -= Time.deltaTime;
                thisEnemy.speed = 0;
                if (abilityCountdown <= 0)
                {
                    projectile.Blast();
                    abilityCountdown = abilityCountdownMax;
                }
            }
            if (playerDistance > slowdownDistance)
            {
                thisEnemy.speed = thisEnemy.maxSpeed;
            }
            if (playerDistance <= runDistance)
            {
                thisEnemy.speed = runSpeed;
            }
        }
        if (hasAbility == true)
        {
            abilityCountdown -= Time.deltaTime;
            if (abilityCountdown <= 0)
            {
                ActivateAbility();
            }
        }

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

    public void ActivateAbility()
    {
        thisEnemy.ability.Invoke();
        abilityCountdown = abilityCountdownMax;
    }

}
