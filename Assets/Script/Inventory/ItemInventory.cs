using System;
using UnityEngine;
[Serializable]
public class ItemInventory
{
    public ItemProfileSO itemProfileSO;
    public int itemCount=0;
    public int maxStack = 7;
    public int currentLevel = 0;
    public bool isDirty = false;
    public bool isDirtySkill = true;
}
    
