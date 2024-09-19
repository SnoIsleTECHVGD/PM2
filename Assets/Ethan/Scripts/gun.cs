using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float bulletDelayTime;
    public Transform firepoint;
    public GameObject bulletPrefab;
    public bool canShoot = true;
    // Update is called once per frame
    void Update()
    {//if get button AND other variable called like "has fired" or smth
        if(Input.GetButton("Fire1") && canShoot)
        {
            Shoot();
            canShoot = false;
            StartCoroutine(bulletDelay());           
        }
    }
    void Shoot()
    {

        //shooting logic
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
    IEnumerator bulletDelay()
    {
        print(Time.time);
        yield return new WaitForSeconds(bulletDelayTime);
        print(Time.time);
        canShoot = true;
    }
}
