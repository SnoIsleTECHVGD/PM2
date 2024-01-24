using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loseCondition : MonoBehaviour
{
    public Stats stats;
    public Timer timer;
    void Update()
    {
        if(stats.health <= 0)
        {
            SceneManager.LoadScene(5);
        }
        if(timer.remainingTime <= 0)
        {
            SceneManager.LoadScene(5);
        }
    }
}
