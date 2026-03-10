using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Meteorite",menuName ="ScriptableObject/Meteorite")]
public class MeteoriteSO : ScriptableObject
{
    public string meteoriteName = "Meteorite";
    public int maxHP = 2;
    public List<DropItem> dropItems = new List<DropItem>();
}
