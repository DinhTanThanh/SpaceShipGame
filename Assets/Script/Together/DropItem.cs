using System;
using UnityEngine;
[Serializable]

public class DropItem
{
    public ItemSO prefabObject;
    public int dropRate=100000;
    public int minItem=0;
    public int maxItem=0;
}
