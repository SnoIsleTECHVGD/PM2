using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbilities : MonoBehaviour
{
    public GameObject[] summonableEnemies;
    private Queue<GameObject> enemiesSetToSpawn;
    public Vector3 offset;

    public void Summon()
    {
        //TO DO: Make it so it doesn't spawn in buildings
        GameObject enemy = summonableEnemies[Random.Range(0, summonableEnemies.Length)];
        Instantiate(enemy, this.transform.position + offset, this.transform.rotation);
    }
}
