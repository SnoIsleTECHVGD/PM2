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
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        //Movement script
        if (Input.GetKey(MoveUp))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        }
        if (Input.GetKey(MoveDown))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
        }
        if (Input.GetKey(MoveLeft))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }
        if (Input.GetKey(MoveRight))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
        //Dash script
        //if (Input.GetKeyDown(Dash))
      

    }
}
