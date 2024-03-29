using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float range;
    [SerializeField] float maxDistanceX;
    [SerializeField] float maxDistanceY;
    Vector3 wayPoint;

    private void Start()
    {
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = (this.transform.position - wayPoint) * speed;
        if (Vector2.Distance(transform.position, wayPoint) < range)
        {
            SetNewDestination();
        }
    }
    void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistanceX, maxDistanceX), Random.Range(-maxDistanceY, maxDistanceY));
    }
}