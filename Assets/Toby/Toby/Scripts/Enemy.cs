using UnityEngine.Events;

public partial class EnemyNewAI
{
    [System.Serializable]
    public struct Enemy
    {
        public UnityEvent ability;
        public bool hasAbility;
        public float scrapMax;
        public float scrapMin;
        public float speed;
    }
}
