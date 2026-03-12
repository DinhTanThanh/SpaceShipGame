using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;
    public bool AddItem(ItemCode itemCode,int itemCount)
    {
        ItemInventory itemInventory = GetItemByCode(itemCode);
        if (itemInventory == null)
        {
            return false;
        }
        int newCount = itemInventory.itemCount + itemCount;
        Debug.Log(newCount);

        if (newCount > itemInventory.maxStack) return false;
        itemInventory.itemCount= newCount;
        return true;
    }
    public ItemInventory GetItemByCode(ItemCode itemCode)
    {
        ItemInventory itemInventory = this.items.Find((item) => item.itemProfileSO.itemCode == itemCode);
        if (itemInventory == null)
        {
            itemInventory = AddEmptyItem(itemCode);
        }
        return itemInventory;
    }
    public ItemInventory AddEmptyItem(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("ItemProfile", typeof(ItemProfileSO));
        foreach(ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            ItemInventory itemInventory = new ItemInventory()
            {
                itemProfileSO = profile,
                maxStack = profile.defaultStack
            };
            this.items.Add(itemInventory);
            return itemInventory;
        }
        return null;
    }
}
