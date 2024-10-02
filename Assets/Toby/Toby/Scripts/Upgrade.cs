public partial class Shop
{
    [System.Serializable]
    public struct Upgrade
    {
        public int initalCost;
        public int cost;
        public int costIncrease;
        public int upgradeTier;
        public int maxUpgradeTier;
        public float upgradeIncrease;
    }
}
