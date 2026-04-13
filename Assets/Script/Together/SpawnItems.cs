using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : PoolPrefab
{
    public static SpawnItems instance;
    public Transform ManageItems;
    public GameObject item;
    protected override void Reset()
    {
        LoadComponent();
    }
    protected override void Awake()
    {
        LoadComponent();
        SpawnItems.instance = this;
    }
    protected override void LoadComponent()
    {
        if (ManageItems != null) return;
        this.ManageItems = GameObject.Find("ManageItems").transform;
    }
    public void SpawnItem(List<DropItem> DropList, Vector3 pos, Quaternion rot)
    {
        int indexItem = Random.Range(0, DropList.Count);
        item = GameObject.Find(DropList[indexItem].prefabObject.itemCode.ToString());
        if (item == null)
        {
            Debug.Log("Không tìm thấy");
            return;
        };
        GameObject itemDrop = SetPosition(item, pos, rot);
        itemDrop.transform.SetParent(transform);
        ItemCtrl itemCtrl = itemDrop.GetComponent<ItemCtrl>();
        if (itemCtrl == null) return;
        ItemCtrl itemCtrlFind = item.GetComponent<ItemCtrl>();
        if (itemCtrlFind == null) return;
        ItemInventory tempInventory = new ItemInventory()
        {
            itemProfileSO = itemCtrlFind.ItemInventory.itemProfileSO,
            itemCount = 1
        };
        itemCtrl.SetItemInventory(tempInventory);
    }
    public GameObject SpawnItem(ItemInventory itemInventory, Vector3 pos, Quaternion rot)
    {
        GameObject item = GameObject.Find(itemInventory.itemProfileSO.itemCode.ToString());
        if (item == null)
        {
            Debug.Log("Không tìm thấy");
            return null;
        };
        GameObject itemDrop = SetPosition(item, pos, rot);
        itemDrop.transform.SetParent(transform);
        return itemDrop;
    }
    public GameObject FindObjectChild(string name)
    {
        foreach (Transform chil in ManageItems)
        {
            if (chil.name == name)
            {
                return chil.gameObject;
            }
        }
        return null;
    }
}
