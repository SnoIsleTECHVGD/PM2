using UnityEngine.Events;

public partial class EnemyNewAI
{
    [System.Serializable]
    public struct Enemy
    {
        public UnityEvent ability;
        public float scrapMax;
        public float scrapMin;
        public float speed;
        public float maxSpeed;
    }
}
