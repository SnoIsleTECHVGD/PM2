using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public MonoBehaviour[] scripts;
    public GameObject player;
    public float distanceBetween;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < distanceBetween)
        {
            scripts[0].enabled = true;
            scripts[1].enabled = false;
        }
        else
        {
            scripts[1].enabled = true;
            scripts[0].enabled = false;
        }
    }
}
