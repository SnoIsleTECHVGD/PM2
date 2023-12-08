using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    public KeyCode MoveUp;
    public KeyCode MoveDown;
    public KeyCode MoveLeft;
    public KeyCode MoveRight;
    public KeyCode Dash;
    public float speed;
    public Rigidbody2D rb;
    public BoxCollider2D bc;

    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = .5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;
    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = speed;
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
        //Dash script
        if (Input.GetKeyDown(Dash))
        {

            if (dashCoolCounter <=0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;

            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if(dashCounter <= 0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashCooldown;
            }
        }
        
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

    }
}
