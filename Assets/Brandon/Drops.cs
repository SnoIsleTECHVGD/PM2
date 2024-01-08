using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Drops : ScriptableObject
{
    public Sprite dropSprite;
    public string dropName;
    public int dropChance;

    public Drops(string dropName, int dropChance)
    {
        this.dropName = dropName;
        this.dropChance = dropChance;
    }
}
