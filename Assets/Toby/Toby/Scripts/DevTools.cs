using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevTools : MonoBehaviour
{
    public KeyCode ammoIncrement;
    public KeyCode statIncrement;
    public KeyCode scrapsUp;
    public KeyCode waveUp;
    public KeyCode waveDown;
    public Stats stats;
    public gun gun;
    public Scraps scraps;
    public WaveSpawner waves;
    public bool isDev;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDev)
        {
            if (Input.GetKeyDown(statIncrement))
            {
                stats.health += 200;
            }
            if (Input.GetKeyDown(ammoIncrement))
            {
                gun.Ammo += 200;
            }
            else if (Input.GetKeyDown(scrapsUp))
            {
                scraps.scrapCount += 10000;
            }
            else if (Input.GetKeyDown(waveUp))
            {
                waves.currentWave += 1;
            }
            else if (Input.GetKeyDown(waveDown))
            {
                waves.currentWave -= 1;
            }
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.CompareTag("Duck") && collision.gameObject.CompareTag("Player"))
        {
            isDev = true;
        }
    }
}
