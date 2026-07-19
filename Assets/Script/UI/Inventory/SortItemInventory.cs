using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SortItemInventory : LoadMonoBehaviour
{
    [SerializeField] protected UIInventorySpawnerCtrl inventorySpawnerCtrl;
    public UIInventorySpawnerCtrl InventorySpawnerCtrl => inventorySpawnerCtrl;
    [SerializeField] protected EnumInventorySort sort = EnumInventorySort.NoSortItem;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventorySpawnerCtrl();
    }
    protected virtual void LoadInventorySpawnerCtrl()
    {
        if (this.inventorySpawnerCtrl != null) return;
        this.inventorySpawnerCtrl = GetComponentInParent<UIInventorySpawnerCtrl>();
        Debug.LogWarning("Load UIInventorySpawnerCtrl: " + transform.name);
    }
    private void Update()
    {
        this.Sorting();
    }
    protected virtual void Sorting()
    {
        switch (this.sort)
        {
            case EnumInventorySort.NoSortItem:
                break;
            case EnumInventorySort.SortItemName:
                this.SortItemInventoryByName();
                break;
            default:
                this.SortItemInventoryByCount();
                break;
        }
    }
    protected virtual void SortItemInventoryByName()
    {
        List<ItemInventory> Items = this.inventorySpawnerCtrl.InventoryPlayer.Items.OrderBy(t=>t.itemProfileSO.nameItem).ToList();
        this.UpdateUIItemInventory(Items);
        
    }
    protected virtual void SortItemInventoryByCount()
    {
        List<ItemInventory> Items=this.inventorySpawnerCtrl.InventoryPlayer.Items.OrderBy(t=>t.itemCount).ToList();
        this.UpdateUIItemInventory(Items);
    }
    protected virtual void UpdateUIItemInventory(List<ItemInventory> Items)
    {
        int itemCount = this.inventorySpawnerCtrl.Holder.childCount;
        Transform currentInventory;
        for (int i = 0; i < itemCount; i++)
        {
            currentInventory = this.inventorySpawnerCtrl.Holder.GetChild(i);
            currentInventory.SetSiblingIndex(this.inventorySpawnerCtrl.DicItem[Items[i]].transform.GetSiblingIndex());
        }
    }
    
    protected virtual void Swap(Transform currentItem, Transform nextItem)
    {
        int indexCurrentItem = currentItem.GetSiblingIndex();
        int indexNextItem = nextItem.GetSiblingIndex();
        currentItem.SetSiblingIndex(indexNextItem);
        nextItem.SetSiblingIndex(indexCurrentItem);
    }
}
