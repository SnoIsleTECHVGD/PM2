using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public partial class WaveSpawner : MonoBehaviour
{
    public enum SpawnState  {Spawning, Waiting, Counting}

    public Wave[] waves;
    public Wave CurrentWave => waves[currentWave];
    public int currentWave = 0;

    public GameObject[] spawnPoints; 
    public float timeBetweenWaves;
    public float waveCountdown;
    private GameObject nextEnemy;
    public Timer timer;
    private float searchCountdown = 1f;

    public SpawnState state = SpawnState.Counting;
    
    private Queue<GameObject> enemiesToSpawn;
    public static List<GameObject> enemies = new();
    public GameObject arrow;
    public UnityEvent fridgeLightOff;
    public UnityEvent fridgeLightOn;
    public UnityEvent waveEventStart;
    public UnityEvent waveEventEnd;
    public bool hasEvent;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new();
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("ERROR: No spawn points!");
        }
        waveCountdown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(EnemyIsAlive());
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
                StartCoroutine(SpawnWave(waves[currentWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        if (hasEvent == true)
        {
            waveEventEnd.Invoke();
        }
        fridgeLightOn.Invoke();
        arrow.SetActive(false);
        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;
        timer.RestartTimer();
        enemiesToSpawn.Clear();
        if (currentWave + 1 > waves.Length - 1)
        {
            SceneManager.LoadScene("Win");
        }
        else
        {
            currentWave++;
        }
    }
    bool EnemyIsAlive()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            return false;
        }
        return true;
        
        
    }
    
    IEnumerator SpawnWave (Wave thisWave)
    {
        if (hasEvent == true)
        {
            waveEventStart.Invoke();
        }
        fridgeLightOff.Invoke();
        arrow.SetActive(true);
        state = SpawnState.Spawning;
        QueueEnemy(thisWave);
        for (int i = 0; i < thisWave.enemies.Length; i++)
        {
            SpawnEnemy(thisWave.enemies[i]);
            yield return new WaitForSeconds(thisWave.delay);
        }
        state = SpawnState.Waiting;
        yield break;
    }
    void QueueEnemy(Wave thisWave)
    {
        enemiesToSpawn = new();

        foreach (GameObject enemy in thisWave.enemies)
        {
            enemiesToSpawn.Enqueue(enemy);
        }
    } 
    
    void SpawnEnemy (GameObject enemy)
    {
        GameObject sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject newEnemy = Instantiate(enemy, sp.transform.position, sp.transform.rotation);
        enemies.Add(newEnemy);
    }

}
