using System;
using System.Collections.Generic;
using UnityEngine;

public class TestDropRate : PoolPrefab
{
    public int dropCount = 0;
    public float gameDropRate=10;
    public GameObject item;
    public MeteoriteController meteoriteCtr;
    public List<ShowingTesting> showingTestings;

    protected override void Reset()
    {
        this.meteoriteCtr = GetComponentInParent<MeteoriteController>();
    }
    protected override void Start()
    {
        InvokeRepeating(nameof(SpawnTest), 2f, 0.5f);
    }
    protected void SpawnTest()
    {
        this.dropCount++;
        List<ItemDropRate> listItemWillDrop = DropItemRate(meteoriteCtr.ShottingSO.dropItems);
        if (listItemWillDrop.Count <= 0) return;
        ShowingTesting showing;
        foreach (ItemDropRate itemDrop in listItemWillDrop)
        {
            this.item = GameObject.Find(itemDrop.prefabObject.itemCode.ToString());
            if (item == null)
            {
                Debug.LogWarning("Không tìm thấy");
                return;
            }
            GameObject itemdroped = SetPosition(item, transform.position, transform.rotation);
            itemdroped.transform.SetParent(transform);
            ItemCtrl itemCtrl = itemdroped.GetComponent<ItemCtrl>();
            if (itemCtrl == null) return;
            Debug.Log(itemCtrl.ItemInventory.itemProfileSO.name);
            showing = showingTestings.Find(i => i.nameObject == itemCtrl.ItemInventory.itemProfileSO.name);
            if (showing == null)
            {
                Debug.Log("Chua ton tai");
                showing=new ShowingTesting();
                showing.nameObject = itemCtrl.ItemInventory.itemProfileSO.name;
                showingTestings.Add(showing);
            }
            showing.count += 1;
            showing.rateDrop = (float)Math.Round((float)showing.count / this.dropCount,2);

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
        int countDropMore;
        List<ItemDropRate> ListItemDropRate = new List<ItemDropRate>();
        foreach (ItemDropRate item in items)
        {
            rate = UnityEngine.Random.Range(0, 1f);
            Debug.Log(rate);
            itemRate =((float)item.dropRate / 100000) * this.GameDropRate();
            Debug.Log(itemRate);
            countDropMore = Mathf.FloorToInt(itemRate);
            if (countDropMore > 0)
            {
                itemRate -= countDropMore;
                for(int i = 0; i < countDropMore; i++)
                {
                    ListItemDropRate.Add(item);
                }
            }
            if (rate <= itemRate)
            {
                ListItemDropRate.Add(item);
            }
            else
            {
                Debug.LogWarning("Khong trung");
            }
        }
        return ListItemDropRate;
    }
    protected virtual float GameDropRate()
    {
        return this.gameDropRate;
    }
}
[Serializable]
public class ShowingTesting
{
    public string nameObject;
    public int count;
    public float rateDrop;
}
