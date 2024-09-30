using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyProjectile : MonoBehaviour
{
    private Camera mainCam;
    public EnemyNewAI enemyAI;
    public Transform gunRotate;
    public float firepointAngle;
    public Transform firePoint;
    public GameObject enemyProjectile;
    //Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    //Update is called once per frame
    void Update()
    {
        transform.right = (Vector2)enemyAI.target.position - (Vector2)transform.position;
        transform.Rotate(new Vector3(0, 0, firepointAngle));

        if (gunRotate.transform.right.x > 0)
        {
            gunRotate.localScale = new Vector2(-0.1f, -0.1f);
        }
        else if (gunRotate.transform.right.x < 0)
        {
            gunRotate.localScale = new Vector2(-0.1f, 0.1f);
        }
    }
    
    public void Blast()
    {
        Instantiate(enemyProjectile, firePoint.position, firePoint.rotation);
    }


}
