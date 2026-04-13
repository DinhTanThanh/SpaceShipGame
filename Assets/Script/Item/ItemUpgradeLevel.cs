using System.Collections.Generic;
using UnityEngine;

public class ItemUpgradeLevel : InventoryAbstract
{
    protected override void LoadComponent()
    {
        this.inventory=GetComponentInParent<Inventory>();
    }
    protected override void Awake()
    {
        base.Awake();
        Invoke("Test", 2);
    }
    protected void Test()
    {
        UpgradeItem(4);
    }
    protected bool UpgradeItem(int indexItem)
    {
        if (!CheckItemInventory(indexItem)) return false;
        if (Inventory.Items[indexItem].itemCount == 0) return false;
        int currentLevel = Inventory.Items[indexItem].currentLevel;
        if (!CheckLevelItem(indexItem,currentLevel+1)) return false;
        if (!HasEnoughToUpgrade(indexItem, currentLevel)) return false;
        if (!Inventory.CheckMaxSlot())
        {
            Debug.Log("Hết chỗ trống");
            return false;
        }
        Inventory.Items[indexItem].currentLevel++;
        //logic chưa thực sự hoàn thành còn cơ chế thêm đồ nâng cấp mới nữa
        DetroyItemFinishedUpgrade(Inventory.Items[indexItem].itemProfileSO.ListUpgradeLevel[currentLevel].ListIngredient);
        return true;
    }
    protected bool CheckItemInventory(int indexItem)
    {
        int countItem = Inventory.Items.Count;
        if (indexItem < 0 || indexItem >= countItem)
        {
            Debug.Log("Out ở đây");
            return false;
        }
        return true;
    }
    protected bool CheckLevelItem(int indexItem,int levelToUp)
    {
        if (Inventory.Items[indexItem].itemProfileSO.ListUpgradeLevel.Count < levelToUp) return false;
        return true;
    }
    protected bool HasEnoughToUpgrade(int indexItem,int levelToUp)
    {
        if (!CheckItemIngredient(Inventory.Items[indexItem].itemProfileSO.ListUpgradeLevel[levelToUp].ListIngredient)) return false;
        return true;
    }
    protected bool CheckItemIngredient(List<ItemRecipeIngredient> ListIngredient)
    {
        foreach(ItemRecipeIngredient child in ListIngredient)
        {
            if (SumCountItemByCode(Inventory.Items, child.itemProfileSO.itemCode) < child.countItem)
            {
                Debug.Log(SumCountItemByCode(Inventory.Items, child.itemProfileSO.itemCode));

                Debug.Log(child.itemProfileSO.itemCode);
                return false;
            }
        }
        return true;
    }
    protected int SumCountItemByCode(List<ItemInventory> items,ItemCode itemCode)
    {
        int count = 0;
        foreach(ItemInventory child in items)
        {
            if (child.itemProfileSO.itemCode == itemCode)
            {
                count+=child.itemCount;
            }
        }
        return count;
    }
    protected void DetroyItemFinishedUpgrade(List<ItemRecipeIngredient> ListIngredient)
    {
        foreach (ItemRecipeIngredient child in ListIngredient)
        {
            int countItem = child.countItem;
            for(int i = Inventory.Items.Count - 1; i >= 0; i--)
            {
                ItemInventory itemInventory = Inventory.Items[i];
                if (itemInventory.itemProfileSO.itemCode == child.itemProfileSO.itemCode)
                {
                    if (countItem >= itemInventory.itemCount)
                    {
                        countItem -= itemInventory.itemCount;
                        Inventory.Items.Remove(itemInventory);
                    }
                    else
                    {
                        itemInventory.itemCount -= countItem;
                        countItem = 0;
                        break;
                    }
                }
            } 
        }
    }
}
