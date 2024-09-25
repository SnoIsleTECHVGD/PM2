using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointgun : MonoBehaviour
{
    private Camera mainCam;
    private Vector2 mousePos;
    public SpriteRenderer gun;
    public Transform gunRotate;
    //Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    //Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        transform.right = mousePos - (Vector2)transform.position;

        if (gunRotate.transform.right.x > 0)
        {
            gunRotate.localScale = new Vector2(-0.1f, -0.1f);
        }
        else if (gunRotate.transform.right.x < 0)
        {
            gunRotate.localScale = new Vector2(-0.1f, 0.1f);
        }
    }
}
