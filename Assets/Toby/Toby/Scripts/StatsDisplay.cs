using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsDisplay : MonoBehaviour
{
    public Stats playerStats;
    public topDownMovement playerMovement;
    public gun playerGunStats;
    public minePlace playerMines;
    public Shop dashLvl;
    public TextMeshProUGUI statsText;
    // Start is called before the first frame update
    void Start()
    {
        IncrementStats();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void IncrementStats()
    {
        statsText.text = $"Health: {playerStats.health} \r\n\r\nSpeed: {playerMovement.moveSpeed}\r\n\r\nDash LVL: {dashLvl.dashUpgrade.upgradeTier}\r\n\r\nBullet Damage: {playerStats.attack + 1}\r\n\r\nBullet Speed: {playerGunStats.bulletDelayTime}\r\n\r\nLandmines: {playerMines.mineCount}\r\n\r\nHasShotgun: {playerGunStats.hasShotgun}\r\n";
    }
}
