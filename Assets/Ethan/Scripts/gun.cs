using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class gun : MonoBehaviour
{
    public Transform firepoint;
    public Transform firepoint2;
    public Transform firepoint3;
    public GameObject bulletPrefab;
    public bool canShoot = true;
    public int Ammo = 20;
    public float bulletDelayTime;
    public bool hasShotgun;
    // Update is called once per frame
    void Update()
    {//if get button AND other variable called like "has fired" or smth
        if(Input.GetButton("Fire1") && canShoot && Ammo >=1)
        {
            Shoot();
            canShoot = false;
            StartCoroutine(BulletDelay());
            if (hasShotgun == false)
            {
                Ammo -= 1;
            }
            else if (hasShotgun == true)
            {
                Ammo -= 3;
            }
        }
    }
    public void Shoot()
    {
        if (hasShotgun == false)
        {
            Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        }
        else if (hasShotgun == true)
        {
            ShotgunShoot();
        }
        return;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ammo"))
        {
            Ammo += collision.gameObject.GetComponent<ammoProperties>().ammoGiven;
            Destroy(collision.gameObject);
        }
    }
    IEnumerator BulletDelay()
    {
        yield return new WaitForSeconds(bulletDelayTime);
        canShoot = true;
    }
    public void ShotgunShoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Instantiate(bulletPrefab, firepoint2.position, firepoint2.rotation);
        Instantiate(bulletPrefab, firepoint3.position, firepoint3.rotation);
    }
    
}
