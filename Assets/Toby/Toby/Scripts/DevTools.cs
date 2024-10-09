using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevTools : MonoBehaviour
{
    public KeyCode statIncrement;
    public KeyCode scrapsUp;
    public KeyCode waveUp;
    public KeyCode waveDown;
    public Stats stats;
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
                stats.health += 20;
            }
            else if (Input.GetKeyDown(scrapsUp))
            {
                scraps.scrapCount += 100;
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
}
