using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashScript : MonoBehaviour
{
    public moveScript msPaint;
    public KeyCode dash;
    public float dashCounter = 0;
    public float dashDuration = 1.0f;
    public float dashSpeed;


    // Start is called before the first frame update
    void Start()
    {
       // to reference, do msPaint.speed
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(dash))
        {
            if (dashCounter <= 0)
            {
                dashDuration -= Time.deltaTime;
                msPaint.speed = dashSpeed;
            }
        }
        



        if (dashDuration <= 0.0f)
        {
            msPaint.speed = 4;
            dashCounter = 0;
        }
    }
}
