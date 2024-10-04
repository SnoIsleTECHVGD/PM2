using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class noMoreBoom : MonoBehaviour
{
    public float waitToDes;
    public void Start()
    {
        if (this.enabled == true)
        {
            Destroy(this.gameObject, waitToDes);
        }
    }
}
