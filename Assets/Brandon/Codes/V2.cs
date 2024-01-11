using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V2 : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        {
            GetComponent <Rigidbody2D> ().velocity = (this.transform.position - player.transform.position) * speed;
        }
    }
}
