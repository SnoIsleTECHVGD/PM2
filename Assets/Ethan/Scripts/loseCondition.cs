using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loseCondition : MonoBehaviour
{
    public Stats stats;
    void Update()
    {
        if(stats.health <= 0)
        {
            SceneManager.LoadScene(5);
        }
    }
}
