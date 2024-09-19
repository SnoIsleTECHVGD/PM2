using UnityEngine;

public partial class WaveSpawner
{
    [System.Serializable]
    public class Wave
    {
        public string name;
        public GameObject[] enemies;
        public float delay;
    }
}
