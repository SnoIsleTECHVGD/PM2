using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBullet : MonoBehaviour
{
    public GameObject bullet;
    public Vector3 mousePos;
    public GameObject theCamera;
    public Vector3 HELPPP;
    public int bulletSpeed = 5;
    public int bulletDelayTime;
    // Update is called once per frame
    void Update()
    {
        HELPPP = Input.mousePosition;
        mousePos = theCamera.transform.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            Vector2 target = theCamera.transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = target - myPos;
            direction.Normalize();
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            GameObject projectile = Instantiate(bullet, transform.position, rotation);
            projectile.SetActive(true);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * 5 * bulletSpeed;
            StartCoroutine(bulletDelay());
        }
    }
    IEnumerator bulletDelay()
    {
        print(Time.time);
        yield return new WaitForSeconds(bulletDelayTime);
        print(Time.time);
    }
   
}
