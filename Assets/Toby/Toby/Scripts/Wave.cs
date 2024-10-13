using UnityEngine;
using UnityEngine.Events;

public partial class WaveSpawner
{
    [System.Serializable]
    public class Wave
    {
        public string name;
        public GameObject[] enemies;
        public float delay;
        public UnityEvent waveEventStart;
        public UnityEvent waveEventEnd;
        public bool hasEvent;
    }
}
