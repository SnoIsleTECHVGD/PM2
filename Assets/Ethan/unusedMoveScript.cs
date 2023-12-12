using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{   
    public Rigidbody2D rb;
    public BoxCollider2D bc;

    public KeyCode MoveUp;
    public KeyCode MoveDown;
    public KeyCode MoveLeft;
    public KeyCode MoveRight;
    public float speed;






    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    
    // Update is called once per frame
    void Update()
    {
        //Movement script
        if (Input.GetKey(MoveUp))
        {
            rb.velocity = Vector2.up * speed;
        }
        if (Input.GetKey(MoveDown))
        {
            rb.velocity = Vector2.down * speed;
        }
        if (Input.GetKey(MoveLeft))
        {
            rb.velocity = Vector2.left * speed;
        }
        if (Input.GetKey(MoveRight))
        {
            rb.velocity = Vector2.right * speed;
        }
       

    }

   
    
}

