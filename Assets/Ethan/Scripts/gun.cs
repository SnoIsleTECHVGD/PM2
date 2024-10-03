using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public partial class gun : MonoBehaviour
{
    public Transform firepoint;
    public Transform firepoint2;
    public Transform firepoint3;
    public GameObject bulletPrefab;
    public KeyCode switchToShotgun;
    public bool canShoot = true;
    public int Ammo = 20;
    public float bulletDelayTime;
    public float bulletDelayStorage;
    public float shotgunDelayTime;
    public bool hasShotgun;
    public bool shotgunActive;
    public UnityEvent shotgunSwitch;
    public UnityEvent gunSwitch;
    // Update is called once per frame
    void Update()
    {//if get button AND other variable called like "has fired" or smth
        if(Input.GetButton("Fire1") && canShoot && Ammo >=1)
        {
            Shoot();
            canShoot = false;
            StartCoroutine(BulletDelay());
            if (shotgunActive == false)
            {
                Ammo -= 1;
            }
            else if (shotgunActive == true)
            {
                Ammo -= 3;
            }
        }
        if (Input.GetKeyDown(switchToShotgun) && shotgunActive == false && hasShotgun == true)
        {
            shotgunSwitch.Invoke();
            shotgunActive = true;
            bulletDelayStorage = bulletDelayTime;
            bulletDelayTime = shotgunDelayTime;
        }
        else if (Input.GetKeyDown(switchToShotgun) && shotgunActive == true && hasShotgun == true)
        {
            gunSwitch.Invoke();
            shotgunActive = false;
            bulletDelayTime = bulletDelayStorage;
        }
    }
    public void Shoot()
    {
        if (shotgunActive == false)
        {
            Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        }
        else if (shotgunActive == true)
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
