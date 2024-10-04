using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public WaveSpawner waveSpawner;
    public float remainingTime;
    public bool isOn;

    void Start()
    {
        remainingTime = waveSpawner.waveCountdown;
    }
    void Update()
    {
        if(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if(remainingTime < 0)
        {
            remainingTime = 0;
            timerText.color = Color.red;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void RestartTimer()
    {
        remainingTime = waveSpawner.waveCountdown;
        timerText.color = Color.white;
    }    

    public void Bool()
    {
        isOn = true;
    }
}
