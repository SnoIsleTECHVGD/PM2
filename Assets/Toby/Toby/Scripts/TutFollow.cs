using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutFollow : MonoBehaviour
{
    public GameObject player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Animator>().SetInteger("WalkDirection", 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Animator>().SetInteger("WalkDirection", 2);
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Animator>().SetInteger("WalkDirection", 3);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetInteger("WalkDirection", 4);
        }
    }
}

