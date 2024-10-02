using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minePlace : MonoBehaviour
{
    public Transform droppoint;
    public int mineCount = 1;
    public GameObject minePrefab;
    public Vector3 mineOffset;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && mineCount > 0)
        {
            Console.WriteLine("Yuh");
            Instantiate(minePrefab, droppoint.position + mineOffset, droppoint.rotation);
            mineCount -= 1;
        }
    }
}
