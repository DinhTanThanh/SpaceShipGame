using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;
    public List<ItemInventory> Items => items;
    [SerializeField] protected List<IObjChangeItemObserver> listChangeItem=new List<IObjChangeItemObserver>();
    //kết hợp observer và dirty flag pattern đẻ tổi ưu hiệu xuất hiển thị danh sách item trông túi đồ UI
    //observer để khi inventory có thay đổi mới load
    //dirty flag chi load những item bị thay đổi
    public void AddItemChange(IObjChangeItemObserver objChangeItem)
    {
        this.listChangeItem.Add(objChangeItem);
    }
    protected void OnChangeItem()
    {
        foreach(IObjChangeItemObserver itemChange in this.listChangeItem)
        {
            itemChange.OnChangeItem();
        }
    }
    public bool AddItem(ItemInventory itemInventory)
    {
        if (CheckMaxSlot())
        {
            if (itemInventory.itemProfileSO.itemType == ItemType.Equiment)
            {
                foreach(ItemInventory child in items)
                {
                    if (child.itemProfileSO.itemCode == itemInventory.itemProfileSO.itemCode)
                    {
                        int newCount = child.itemCount + itemInventory.itemCount;
                        child.isDirty = true;
                        if (newCount > child.maxStack)
                        {
                            itemInventory.itemCount -= child.maxStack - child.itemCount;
                            child.itemCount = child.maxStack;
                        }
                        else
                        {
                            child.itemCount = newCount;
                            return true;
                        }
                    }
                }
                items.Add(itemInventory);
                itemInventory.isDirty = true;
            }
            else
            {
                AddItem(itemInventory.itemProfileSO.itemCode, 1);
            }
            OnChangeItem();
            return true;
        }
        else return false;   
    }
    public bool AddItem(ItemCode itemCode, int itemCount)
    {
        while (true)
        {
            var result = GetListItemByCode(itemCode);
            if (result.item != null)
            {
                int newCount = result.item.itemCount + itemCount;
                if (newCount > result.item.maxStack)
                {
                    int newCountEmpty = result.item.maxStack - result.item.itemCount;
                    result.item.itemCount += newCountEmpty;
                    itemCount -= newCountEmpty;
                    result.item.isDirty = true;
                    continue;
                }
                result.item.itemCount = newCount;
                result.item.isDirty = true;
                break;
            }
            return false;
        }
        return true;
    }
    public (ItemInventory item, bool isSlot) GetListItemByCode(ItemCode itemCode)
    {
        //chỉ láy những item trong inventory đang chưa full stack còn nếu full hết (không có thằng nào trong này là còn trống stack thì trả về null)
        //nếu danh sách không null thì tìm những thằng mà còn trống stack
        List<ItemInventory> itemInventory = this.items.FindAll((item) => item.itemProfileSO.itemCode == itemCode);
        foreach (ItemInventory item in itemInventory)
        {
            if (item.itemCount < item.maxStack)
            {
                return (item, CheckMaxSlot());
            }
        }
        if (CheckMaxSlot()) return (AddEmptyItem(itemCode), CheckMaxSlot());
        return (null, false);
    }
    public bool CheckMaxSlot()
    {
        return items.Count < this.maxSlot;
    }
    public ItemInventory AddEmptyItem(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("ItemProfile", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
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
    public bool DeductItem(ItemCode itemCode, int countItem)
    {
        if (!TryDeductItem(itemCode, countItem)) return false;
        ItemInventory itemInventory = this.items.Find(item => item.itemProfileSO.itemCode == itemCode);
        int newCout = itemInventory.itemCount - countItem;
        itemInventory.itemCount = newCout;
        return true;
    }
    public bool TryDeductItem(ItemCode itemCode, int countItem)
    {
        ItemInventory itemInventory = this.items.Find((item) => item.itemProfileSO.itemCode == itemCode);
        int newCount = itemInventory.itemCount - countItem;
        if (newCount < 0) return false;
        return true;
    }
}
