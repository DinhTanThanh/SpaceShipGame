using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventorySpawnerCtrl : LoadMonoBehaviour,IObjChangeItemObserver
{
    [SerializeField] protected Transform holder;
    public Transform Holder => holder;
    [SerializeField] protected Inventory inventoryPlayer;
    public Inventory InventoryPlayer => inventoryPlayer;
    [SerializeField] protected Dictionary<ItemInventory,GameObject> dicItem=new Dictionary<ItemInventory,GameObject>();
    public Dictionary<ItemInventory, GameObject> DicItem => dicItem;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHolder();
        this.LoadInventoryPlayer();
    }
    protected override void Start()
    {
        base.Start();
        this.inventoryPlayer.AddItemChange(this);
        RefreshUIInventory();
    }
    protected virtual void LoadInventoryPlayer()
    {
        if (this.inventoryPlayer != null) return;
        this.inventoryPlayer = GameObject.Find("Player")?.GetComponentInChildren<Inventory>();
        Debug.LogWarning("Load InventoryPlayer: " + transform.name);
    }
    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("UIInventory").Find("Scroll View").Find("Viewport").Find("Content");
        Debug.LogWarning("Load Holder: " + transform.name);
    }
    protected virtual void UpdatedirtyItem()
    {
        foreach(ItemInventory item in this.InventoryPlayer.Items)
        {
            if (!this.dicItem.ContainsKey(item))
            {
                this.CreateNewUIItemSlot(item);
                continue;
            }
            if (item.isDirty)
            {
                Debug.Log("cap nhat");
                this.UpdateNumberUISlot(item, dicItem[item]);
                item.isDirty = false;
            }
        }
    }
    protected virtual void CreateNewUIItemSlot(ItemInventory itemInventory)
    {
        GameObject uiItem = UIInventorySpawnerItem.Instance.SetPosition(UIInventorySpawnerItem.Instance.Prefab, Vector3.zero, Quaternion.identity);
        uiItem.transform.SetParent(this.holder);
        UpdateUISlot(itemInventory, uiItem);
        uiItem.transform.localScale = new Vector3(1f, 1f, 1f);
        uiItem.SetActive(true);
        itemInventory.isDirty = false;
        this.dicItem.Add(itemInventory, uiItem);
    }
    protected virtual void UpdateNumberUISlot(ItemInventory item,GameObject uiItem)
    {
        uiItem.transform.Find("ItemNumber").GetComponent<TextMeshProUGUI>().text = "x"+item.itemCount.ToString();
    }
    protected virtual void UpdateUISlot(ItemInventory item,GameObject uiItem)
    {
        uiItem.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = item.itemProfileSO.nameItem;
        uiItem.transform.Find("ItemImage").GetComponent<Image>().sprite = item.itemProfileSO.sprite;
        this.UpdateNumberUISlot(item, uiItem);
    }
    protected virtual void RefreshUIInventory()
    {
        //this.dicItem.Clear();
        UpdatedirtyItem();
    }
    public void OnChangeItem()
    {
        UpdatedirtyItem();
    }
}
