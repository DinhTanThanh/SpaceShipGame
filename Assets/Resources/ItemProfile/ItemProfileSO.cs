using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="DefaultName",menuName ="ScriptableObject/ItemProfile")]
[Serializable]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode=ItemCode.NullItem;
    public ItemType itemType=ItemType.ItemNull;
    public string nameItem = "no-name";
    public int defaultStack = 7;
    public Sprite sprite;
    [SerializeField] protected List<ItemRecipe> listUpgradeLevel;
    public List<ItemRecipe> ListUpgradeLevel=>listUpgradeLevel;
}
