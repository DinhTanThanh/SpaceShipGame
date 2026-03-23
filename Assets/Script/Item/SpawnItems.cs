using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : PoolPrefab
{
    public static SpawnItems instance;
    public Transform ManageItems;
    private void Reset()
    {
        LoadComponent();
    }
    private void Awake()
    {
        LoadComponent();
        SpawnItems.instance = this;
    }
    public void LoadComponent()
    {
        if (ManageItems != null) return;
        this.ManageItems = GameObject.Find("ManageItems").transform;
    }
    public void SpawnItem(List<DropItem> DropList, Vector3 pos, Quaternion rot)
    {
        int indexItem = Random.Range(0, DropList.Count);
        GameObject item = GameObject.Find(DropList[indexItem].prefabObject.itemCode.ToString());
        if (item == null)
        {
            Debug.Log("Không tìm thấy");
            return;
        };
        GameObject itemDrop = SetPosition(item, pos, rot);
        itemDrop.transform.SetParent(transform);
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
