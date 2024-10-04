using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCount : MonoBehaviour
{
    public gun gun;
    public Stats player;
    public WaveSpawner waveCheck;
    public TextMeshProUGUI ammo;
    public TextMeshProUGUI health;
    public TextMeshProUGUI wave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammo.text = $"{gun.Ammo}";
        health.text = $"{player.health}";
        wave.text = $"Wave: {waveCheck.currentWave + 1}";
    }

}
