using UnityEngine;

public class ItemCtrl : LoadMonoBehaviour
{
    public ItemInventory ItemInventory;
    public void LoadItemProfileSO()
    {
        string nameObj = transform.name.Replace("(Clone)", "");
        string path = "ItemProfile/" + nameObj;
        ItemInventory.itemProfileSO=Resources.Load<ItemProfileSO>(path);
        ItemInventory.itemCount = 1;
    }
    protected override void OnEnable()
    {
        LoadItemProfileSO();
    }
    protected override void Reset()
    {
        LoadItemProfileSO();
    }
    protected override void Awake()
    {
        LoadItemProfileSO();
    }
    public void SetItemInventory(ItemInventory itemInventory)
    {
        ItemInventory= itemInventory;
    }
}
