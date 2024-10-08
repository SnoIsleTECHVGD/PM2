using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public partial class Shop : MonoBehaviour
{
    public enum UpgradeType { Health, Speed, Dash, Damage, Landmine, Shotgun}
    public StatsDisplay statsDisplay;
    public IncrementCost[] costs;
    public Stats playerStats;
    public topDownMovement playerMovement;
    public gun playerGunStats;
    public minePlace playerMines;
    public Scraps scrapCount;
    public UnityEvent rejectionCost;
    public UnityEvent rejectionTier;
    public UnityEvent rejectionShotgun;
    public Upgrade healthUpgrade;
    public Upgrade speedUpgrade;
    public Upgrade dashUpgrade;
    public Upgrade damageUpgrade;
    public Upgrade bulletDelayUpgrade;
    public Upgrade landmine;
    public Upgrade shotgun;
    public GameObject reject;
    // Start is called before the first frame update
    void Start()
    {
        landmine.cost = landmine.initalCost;
        shotgun.cost = shotgun.initalCost;
        if (healthUpgrade.upgradeTier == 0)
        {
            healthUpgrade.cost = healthUpgrade.initalCost;
        }
        if (speedUpgrade.upgradeTier == 0)
        {
            speedUpgrade.cost = speedUpgrade.initalCost;
        }
        if (dashUpgrade.upgradeTier == 0)
        {
            dashUpgrade.cost = dashUpgrade.initalCost;
        }
        if (damageUpgrade.upgradeTier == 0)
        {
            damageUpgrade.cost = damageUpgrade.initalCost;
        }
        if (bulletDelayUpgrade.upgradeTier == 0)
        {
            bulletDelayUpgrade.cost = bulletDelayUpgrade.initalCost;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseHealth()
    {
        if (scrapCount.scrapCount < healthUpgrade.cost || healthUpgrade.upgradeTier >= healthUpgrade.maxUpgradeTier)
        {
            if (scrapCount.scrapCount < healthUpgrade.cost)
            {
                rejectionCost.Invoke();
                reject.SetActive(true);
            }
            else if (healthUpgrade.upgradeTier >= healthUpgrade.maxUpgradeTier)
            {
                rejectionTier.Invoke();
                reject.SetActive(true);
            }
            return; 
        }
        else if (scrapCount.scrapCount >= healthUpgrade.cost)
        {
            scrapCount.scrapCount -= healthUpgrade.cost;
            float maxScraps = 0;
            float minScraps = 0;
            scrapCount.IncrementScrapCount(maxScraps, minScraps);
            playerStats.health += (int)healthUpgrade.upgradeIncrease;
            healthUpgrade.upgradeTier++;
            healthUpgrade.cost += healthUpgrade.costIncrease;
            statsDisplay.IncrementStats();
            foreach (IncrementCost c in costs)
            {
                c.IncrementCosts();
            }
        }
    }



    public void IncreaseSpeed()
    {
        if (scrapCount.scrapCount < speedUpgrade.cost || speedUpgrade.upgradeTier >= speedUpgrade.maxUpgradeTier)
        {
            if (scrapCount.scrapCount < speedUpgrade.cost)
            {
                rejectionCost.Invoke();
                reject.SetActive(true);
            }
            else if (speedUpgrade.upgradeTier >= speedUpgrade.maxUpgradeTier)
            {
                rejectionTier.Invoke();
                reject.SetActive(true);
            }
            return;
        }
        else if (scrapCount.scrapCount >= speedUpgrade.cost)
        {
            scrapCount.scrapCount -= speedUpgrade.cost;
            float maxScraps = 0;
            float minScraps = 0;
            scrapCount.IncrementScrapCount(maxScraps, minScraps);
            playerMovement.moveSpeed += speedUpgrade.upgradeIncrease;
            speedUpgrade.upgradeTier++;
            speedUpgrade.cost += speedUpgrade.costIncrease;
            statsDisplay.IncrementStats();
            foreach (IncrementCost c in costs)
            {
                c.IncrementCosts();
            }
        }
    }

    public void UpgradeDash()
    {
        if (scrapCount.scrapCount < dashUpgrade.cost || dashUpgrade.upgradeTier >= dashUpgrade.maxUpgradeTier)
        {
            if (scrapCount.scrapCount < dashUpgrade.cost)
            {
                rejectionCost.Invoke();
                reject.SetActive(true);
            }
            else if (dashUpgrade.upgradeTier >= dashUpgrade.maxUpgradeTier)
            {
                rejectionTier.Invoke();
                reject.SetActive(true);
            }
            return;
        }
        else if (scrapCount.scrapCount >= dashUpgrade.cost)
        {
            scrapCount.scrapCount -= dashUpgrade.cost;
            float maxScraps = 0;
            float minScraps = 0;
            scrapCount.IncrementScrapCount(maxScraps, minScraps);
            playerMovement.dashSpeed += dashUpgrade.upgradeIncrease;
            playerMovement.dashLength += 0.1f;
            dashUpgrade.upgradeTier++;
            dashUpgrade.cost += dashUpgrade.costIncrease;
            statsDisplay.IncrementStats();
            foreach (IncrementCost c in costs)
            {
                c.IncrementCosts();
            }
        }
    }

    public void IncreaseDamage()
    {
        if (scrapCount.scrapCount < damageUpgrade.cost || damageUpgrade.upgradeTier >= damageUpgrade.maxUpgradeTier)
        {
            if (scrapCount.scrapCount < damageUpgrade.cost)
            {
                rejectionCost.Invoke();
                reject.SetActive(true);
            }
            else if (damageUpgrade.upgradeTier >= damageUpgrade.maxUpgradeTier)
            {
                rejectionTier.Invoke();
                reject.SetActive(true);
            }
            return;
        }
        else if (scrapCount.scrapCount >= damageUpgrade.cost)
        {
            scrapCount.scrapCount -= damageUpgrade.cost;
            float maxScraps = 0;
            float minScraps = 0;
            scrapCount.IncrementScrapCount(maxScraps, minScraps);
            playerStats.attack += (int)damageUpgrade.upgradeIncrease;
            damageUpgrade.upgradeTier++;
            damageUpgrade.cost += damageUpgrade.costIncrease;
            statsDisplay.IncrementStats();
            foreach (IncrementCost c in costs)
            {
                c.IncrementCosts();
            }
        }
    }

    public void DecreaseBulletDelay()
    {
        if (scrapCount.scrapCount < bulletDelayUpgrade.cost || bulletDelayUpgrade.upgradeTier >= bulletDelayUpgrade.maxUpgradeTier || playerGunStats.shotgunActive == true)
        {
            if (scrapCount.scrapCount < bulletDelayUpgrade.cost)
            {
                rejectionCost.Invoke();
                reject.SetActive(true);
            }
            else if (bulletDelayUpgrade.upgradeTier >= bulletDelayUpgrade.maxUpgradeTier)
            {
                rejectionTier.Invoke();
                reject.SetActive(true);
            }
            else if (playerGunStats.shotgunActive == true)
            {
                rejectionShotgun.Invoke();
                reject.SetActive(true);
            }    
            return;
        }
        else if (scrapCount.scrapCount >= bulletDelayUpgrade.cost && playerGunStats.shotgunActive == false)
        {
            scrapCount.scrapCount -= bulletDelayUpgrade.cost;
            float maxScraps = 0;
            float minScraps = 0;
            scrapCount.IncrementScrapCount(maxScraps, minScraps);
            playerGunStats.bulletDelayTime -= bulletDelayUpgrade.upgradeIncrease;
            bulletDelayUpgrade.upgradeTier++;
            bulletDelayUpgrade.cost += bulletDelayUpgrade.costIncrease;
            statsDisplay.IncrementStats();
            foreach (IncrementCost c in costs)
            {
                c.IncrementCosts();
            }
        }
    }

    public void BuyLandmine()
    {
        if (scrapCount.scrapCount < landmine.cost)
        {
            rejectionCost.Invoke();
            reject.SetActive(true);
            return;
        }
        else if (scrapCount.scrapCount >= landmine.cost)
        {
            scrapCount.scrapCount -= landmine.cost;
            float maxScraps = 0;
            float minScraps = 0;
            scrapCount.IncrementScrapCount(maxScraps, minScraps);
            playerMines.mineCount += 1;
            statsDisplay.IncrementStats();
            foreach (IncrementCost c in costs)
            {
                c.IncrementCosts();
            }
        }
    }

    public void UnlockShotgun()
    {
        if (scrapCount.scrapCount < shotgun.cost || shotgun.upgradeTier >= shotgun.maxUpgradeTier)
        {
            if (scrapCount.scrapCount < shotgun.cost)
            {
                rejectionCost.Invoke();
                reject.SetActive(true);
            }
            else if (shotgun.upgradeTier >= shotgun.maxUpgradeTier)
            {
                rejectionTier.Invoke();
                reject.SetActive(true);
            }
            return;
        }
        else if (scrapCount.scrapCount >= shotgun.cost)
        {
            scrapCount.scrapCount -= shotgun.cost;
            float maxScraps = 0;
            float minScraps = 0;
            scrapCount.IncrementScrapCount(maxScraps, minScraps);
            playerGunStats.hasShotgun = true;
            bulletDelayUpgrade.upgradeTier++;
            statsDisplay.IncrementStats();
            foreach (IncrementCost c in costs)
            {
                c.IncrementCosts();
            }
        }
    } 
}
