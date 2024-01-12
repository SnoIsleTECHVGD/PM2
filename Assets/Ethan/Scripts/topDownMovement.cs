using System.Collections.Generic;
using UnityEngine;

public class topDownMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    

    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = .5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
       
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb2d.velocity = moveInput * activeMoveSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
        
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
        if (activeMoveSpeed == dashSpeed)
        {
            
        }
        else
        {

        }
    }
}
