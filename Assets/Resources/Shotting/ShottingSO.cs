using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ShottingAbleObject",menuName ="ScriptableObject/Shotting")]
public class ShottingSO : ScriptableObject
{
    public string enemyName = "Shotting";
    public ShottingType shottingType = ShottingType.DefaultEnemy;
    public int maxHP = 2;
    public List<ItemDropRate> dropItems = new List<ItemDropRate>();
}
