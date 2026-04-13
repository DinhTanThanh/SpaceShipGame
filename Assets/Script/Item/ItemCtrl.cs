using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    public ItemInventory ItemInventory;
    public void LoadItemProfileSO()
    {
        string path = "ItemProfile/" + transform.name;
        ItemInventory.itemProfileSO=Resources.Load<ItemProfileSO>(path);
        ItemInventory.itemCount = 1;
    }
    private void Reset()
    {
        LoadItemProfileSO();
    }
    private void Awake()
    {
        LoadItemProfileSO();
    }
    public void SetItemInventory(ItemInventory itemInventory)
    {
        ItemInventory= itemInventory;
    }
}
