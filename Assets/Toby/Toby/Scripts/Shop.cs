using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public partial class Shop : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseHealth()
    {
        if (healthUpgrade.upgradeTier == 0)
        {
            healthUpgrade.cost = healthUpgrade.initalCost;
        }
        if (scrapCount.scrapCount < healthUpgrade.cost || healthUpgrade.upgradeTier >= healthUpgrade.maxUpgradeTier)
        {
            if (scrapCount.scrapCount < healthUpgrade.cost)
            {
                rejectionCost.Invoke();
            }
            else if (healthUpgrade.upgradeTier >= healthUpgrade.maxUpgradeTier)
            {
                rejectionTier.Invoke();
            }
            return; 
        }
        else if (scrapCount.scrapCount >= healthUpgrade.cost)
        {
            scrapCount.scrapCount -= healthUpgrade.cost;
            playerStats.health += (int)healthUpgrade.upgradeIncrease;
            healthUpgrade.upgradeTier++;
            healthUpgrade.cost += healthUpgrade.costIncrease;
        }
    }



    public void IncreaseSpeed()
    {
        if (speedUpgrade.upgradeTier == 0)
        {
            speedUpgrade.cost = speedUpgrade.initalCost;
        }
        if (scrapCount.scrapCount < speedUpgrade.cost || speedUpgrade.upgradeTier >= speedUpgrade.maxUpgradeTier)
        {
            if (scrapCount.scrapCount < speedUpgrade.cost)
            {
                rejectionCost.Invoke();
            }
            else if (speedUpgrade.upgradeTier >= speedUpgrade.maxUpgradeTier)
            {
                rejectionTier.Invoke();
            }
            return;
        }
        else if (scrapCount.scrapCount >= speedUpgrade.cost)
        {
            scrapCount.scrapCount -= speedUpgrade.cost;
            playerMovement.moveSpeed += speedUpgrade.upgradeIncrease;
            speedUpgrade.upgradeTier++;
            speedUpgrade.cost += speedUpgrade.costIncrease;
        }
    }

    public void UpgradeDash()
    {
        if (dashUpgrade.upgradeTier == 0)
        {
            dashUpgrade.cost = dashUpgrade.initalCost;
        }
        if (scrapCount.scrapCount < dashUpgrade.cost || dashUpgrade.upgradeTier >= dashUpgrade.maxUpgradeTier)
        {
            if (scrapCount.scrapCount < dashUpgrade.cost)
            {
                rejectionCost.Invoke();
            }
            else if (dashUpgrade.upgradeTier >= dashUpgrade.maxUpgradeTier)
            {
                rejectionTier.Invoke();
            }
            return;
        }
        else if (scrapCount.scrapCount >= dashUpgrade.cost)
        {
            scrapCount.scrapCount -= dashUpgrade.cost;
            playerMovement.dashSpeed += dashUpgrade.upgradeIncrease;
            playerMovement.dashLength += 0.1f;
            dashUpgrade.upgradeTier++;
            dashUpgrade.cost += dashUpgrade.costIncrease;
        }
    }

    public void IncreaseDamage()
    {
        if (damageUpgrade.upgradeTier == 0)
        {
            damageUpgrade.cost = damageUpgrade.initalCost;
        }
        if (scrapCount.scrapCount < damageUpgrade.cost || damageUpgrade.upgradeTier >= damageUpgrade.maxUpgradeTier)
        {
            if (scrapCount.scrapCount < damageUpgrade.cost)
            {
                rejectionCost.Invoke();
            }
            else if (damageUpgrade.upgradeTier >= damageUpgrade.maxUpgradeTier)
            {
                rejectionTier.Invoke();
            }
            return;
        }
        else if (scrapCount.scrapCount >= damageUpgrade.cost)
        {
            scrapCount.scrapCount -= damageUpgrade.cost;
            playerStats.attack += (int)damageUpgrade.upgradeIncrease;
            damageUpgrade.upgradeTier++;
            damageUpgrade.cost += damageUpgrade.costIncrease;
        }
    }

    public void DecreaseBulletDelay()
    {
        if (bulletDelayUpgrade.upgradeTier == 0)
        {
            bulletDelayUpgrade.cost = bulletDelayUpgrade.initalCost;
        }
        if (scrapCount.scrapCount < bulletDelayUpgrade.cost || bulletDelayUpgrade.upgradeTier >= bulletDelayUpgrade.maxUpgradeTier || playerGunStats.shotgunActive == true)
        {
            if (scrapCount.scrapCount < bulletDelayUpgrade.cost)
            {
                rejectionCost.Invoke();
            }
            else if (bulletDelayUpgrade.upgradeTier >= bulletDelayUpgrade.maxUpgradeTier)
            {
                rejectionTier.Invoke();
            }
            else if (playerGunStats.shotgunActive == true)
            {
                rejectionShotgun.Invoke();
            }    
            return;
        }
        else if (scrapCount.scrapCount >= bulletDelayUpgrade.cost && playerGunStats.shotgunActive == false)
        {
            scrapCount.scrapCount -= bulletDelayUpgrade.cost;
            playerGunStats.bulletDelayTime -= bulletDelayUpgrade.upgradeIncrease;
            bulletDelayUpgrade.upgradeTier++;
            bulletDelayUpgrade.cost += bulletDelayUpgrade.costIncrease;
        }
    }

    public void BuyLandmine()
    {
        landmine.cost = landmine.initalCost;
        if (scrapCount.scrapCount < landmine.cost)
        {
            rejectionCost.Invoke();
            return;
        }
        else if (scrapCount.scrapCount >= landmine.cost)
        {
            scrapCount.scrapCount -= landmine.cost;
            playerMines.mineCount += 1;
        }
    }

    public void UnlockShotgun()
    {
        shotgun.cost = shotgun.initalCost;
        if (scrapCount.scrapCount < shotgun.cost || shotgun.upgradeTier >= shotgun.maxUpgradeTier)
        {
            if (scrapCount.scrapCount < shotgun.cost)
            {
                rejectionCost.Invoke();
            }
            else if (shotgun.upgradeTier >= shotgun.maxUpgradeTier)
            {
                rejectionTier.Invoke();
            }
            return;
        }
        else if (scrapCount.scrapCount >= shotgun.cost)
        {
            scrapCount.scrapCount -= shotgun.cost;
            playerGunStats.hasShotgun = true;
            bulletDelayUpgrade.upgradeTier++;
        }
    } 
}
