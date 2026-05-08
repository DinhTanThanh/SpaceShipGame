using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : PoolPrefab
{
    [Header("SpawnItems")]
    public static SpawnItems instance;
    [SerializeField] protected Transform manageItems;
    public Transform ManageItems => manageItems;
    public float gameDropRate = 1;
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
        this.manageItems = GameObject.Find("ManageItems").transform;
    }
    public void DropItem(List<ItemDropRate> DropList, Vector3 pos, Quaternion rot)
    {
        List<ItemDropRate> listItemWillDrop = DropItemRate(DropList);
        if (listItemWillDrop.Count <= 0) return;
        GameObject item;
        foreach (ItemDropRate itemDrop in listItemWillDrop)
        {
            item = GameObject.Find(itemDrop.prefabObject.itemCode.ToString());
            if (item == null)
            {
                Debug.LogWarning("Không tìm thấy");
                return;
            }
            GameObject itemdroped = SetPosition(item, pos, rot);
            itemdroped.transform.SetParent(transform);
            ItemCtrl itemCtrl = itemdroped.GetComponent<ItemCtrl>();
            if (itemCtrl == null) return;
            ItemInventory tempInventory = new ItemInventory()
            {
                itemProfileSO = itemCtrl.ItemInventory.itemProfileSO,
                itemCount = 1
            };
            itemCtrl.SetItemInventory(tempInventory);
        }
    }
    protected List<ItemDropRate> DropItemRate(List<ItemDropRate> items)
    {
        float rate, itemRate;
        int countSpawnMore;
        List<ItemDropRate> ListItemDropRate = new List<ItemDropRate>();
        foreach (ItemDropRate item in items)
        {
            rate = Random.Range(0, 1f);
            itemRate = (item.dropRate / 100000) * this.GameDropRate();
            countSpawnMore = Mathf.FloorToInt(itemRate);
            //thỏa điệu kiên này thì chắc chắn tỷ lệ rơi hiện tại của nó >= 100%
            if (countSpawnMore > 0)
            {
                itemRate -= countSpawnMore;
                for (int i = 0; i < countSpawnMore; i++)
                {
                    ListItemDropRate.Add(item);
                }
            }
            if (rate <= itemRate)
            {
                ListItemDropRate.Add(item);
            }
        }
        return ListItemDropRate;
    }
    protected virtual float GameDropRate()
    {
        return this.gameDropRate;
    }
    public GameObject DropItemInventory(ItemInventory itemInventory, Vector3 pos, Quaternion rot)
    {
        GameObject item = GameObject.Find(itemInventory.itemProfileSO.itemCode.ToString());
        if (item == null)
        {
            Debug.LogWarning("Không tìm thấy");
            return null;
        }
        ;
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
