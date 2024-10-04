using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyProjectile : MonoBehaviour
{
    private Camera mainCam;
    public EnemyNewAI enemyAI;
    public float firepointAngle;
    public Transform firePoint;
    public GameObject enemyProjectile;
    public float rotateSpeed;
    //Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    //Update is called once per frame
    void Update()
    {
        RotateTowardsTarget();
    }
    
    public void Blast()
    {
        Instantiate(enemyProjectile, firePoint.position, firePoint.rotation);
    }

    public void RotateTowardsTarget()
    {
        Vector2 targetDirection = enemyAI.target.position - transform.position;
        firepointAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, firepointAngle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

}
