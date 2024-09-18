using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState  {Spawning, Waiting, Counting}
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemies;
        public int count;
        public float rate;
        public float delay;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints; 
    public float timeBetweenWaves;
    public float waveCountdown;
    public Transform nextEnemy;

    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.Counting;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Wave w in waves)
        {
            foreach (Transform enemy in w.enemies)
            {
                
            }
        }
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("ERROR: No spawn points!");
        }
        waveCountdown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == SpawnState.Waiting)
        {
            if(!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0)
        {
            if(state != SpawnState.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
        }
        else
        {
            nextWave++;
        }
    }
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
        
    }
    
    IEnumerator SpawnWave (Wave _wave)
    {
        state = SpawnState.Spawning;

        for (int i = 0; i < _wave.count; i++)
        {
            //SpawnEnemy(_wave);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        state = SpawnState.Waiting;
        yield break;
    }

    void SpawnEnemy (Transform enemy)
    {
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemy, sp.position, sp.rotation);
    }
}
