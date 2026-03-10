using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public static SpawnItems instance;
    private void Awake()
    {
        SpawnItems.instance = this; 
    }
    public void SpawnItem(List<DropItem> DropList,Vector3 pos, Quaternion rot)
    {
        int indexItem=Random.Range(0,DropList.Count);
        GameObject item = GameObject.Find(DropList[indexItem].prefabObject.itemName);
        if (item == null) return;
        GameObject itemDrop = Instantiate(item);
        itemDrop.transform.position = pos;
        itemDrop.transform.rotation = rot;
    }
}
