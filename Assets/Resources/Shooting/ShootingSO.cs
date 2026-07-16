using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ShottingAbleObject",menuName ="ScriptableObject/Shotting")]
public class ShootingSO : ScriptableObject
{
    public string enemyName = "Shotting";
    public ShootingType shottingType = ShootingType.DefaultEnemy;
    public int maxHP = 2;
    public int maxKI = 0;
    public List<ItemDropRate> dropItems = new List<ItemDropRate>();
}
