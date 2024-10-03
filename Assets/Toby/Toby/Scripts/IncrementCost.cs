using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IncrementCost : MonoBehaviour
{
    public enum UpgradeType { Health, Speed, Dash, Damage, Landmine, Shotgun, BulletSpeed }
    public UpgradeType thisType;
    public Shop upgrade;
    public TextMeshProUGUI statsText;
    // Start is called before the first frame update
    void Start()
    {
        IncrementCosts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncrementCosts()
    {
        switch (thisType)
        {
            case UpgradeType.Health:
                statsText.text = $"{upgrade.healthUpgrade.cost}";
                break;
            case UpgradeType.Speed:
                statsText.text = $"{upgrade.speedUpgrade.cost}";
                break;
            case UpgradeType.Dash:
                statsText.text = $"{upgrade.dashUpgrade.cost}";
                break;
            case UpgradeType.Damage:
                statsText.text = $"{upgrade.damageUpgrade.cost}";
                break;
            case UpgradeType.Landmine:
                statsText.text = $"{upgrade.landmine.cost}";
                break;
            case UpgradeType.Shotgun:
                statsText.text = $"{upgrade.shotgun.cost}";
                break;
            case UpgradeType.BulletSpeed:
                statsText.text = $"{upgrade.bulletDelayUpgrade.cost}";
                break;
            default:
                break;
        }
    }
    
}
