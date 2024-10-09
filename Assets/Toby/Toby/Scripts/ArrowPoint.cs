using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static EnemyNewAI;

public class ArrowPoint : MonoBehaviour
{
    public GameObject closestEnemy;
    public float arrowAngle;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        closestEnemy = WaveSpawner.enemies.OrderBy(item => item.GetComponent<EnemyNewAI>().playerDistance).ElementAt(0);
        RotateTowardsTarget();
    }
    public void RotateTowardsTarget()
    {
        Vector2 targetDirection = closestEnemy.transform.position - transform.position;
        arrowAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, arrowAngle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }
}
