using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class gun : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public bool canShoot = true;
    public int Ammo = 20;
    // Update is called once per frame
    void Update()
    {//if get button AND other variable called like "has fired" or smth
        if(Input.GetButton("Fire1") && canShoot && Ammo >=1)
        {
            Shoot();
            canShoot = false;
            //StartCoroutine(bulletDelay());
            Ammo -= 1;
        }
    }
    void Shoot()
    {

        //shooting logic
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
    /*IEnumerator bulletDelay()
    {
        print(Time.time);
        yield return new WaitForSeconds(bulletDelayTime);
        print(Time.time);
        canShoot = true;
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ammo"))
        {
            Ammo += collision.gameObject.GetComponent<ammoProperties>().ammoGiven;
            Destroy(collision.gameObject);
        }
    }
}
