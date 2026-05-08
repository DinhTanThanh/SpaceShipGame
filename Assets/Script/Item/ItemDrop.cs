using UnityEngine;

public class ItemDrop : InventoryAbstract
{
    [SerializeField] Transform player;
    protected override void LoadComponent()
    {
        inventory=GetComponentInParent<Inventory>();
    }
    protected override void Reset()
    {
        base.Reset();
        player=GameObject.Find("Player").transform;
    }
    protected override void Awake()
    {
        base.Awake();
        Invoke("TestDrop", 5);
    }
    protected void TestDrop()
    {
        DropItem(1);
    }
    protected bool DropItem(int indexItem)
    {
        if (Inventory.Items.Count <= indexItem)
        {
            Debug.Log("Nằm ngoài vùng nhớ");
            return false;
        }
        ItemInventory temp = Inventory.Items[indexItem];
        Inventory.Items.Remove(temp);
        Vector3 pos = player.position;
        pos.x += 2.5f;
        GameObject itemDrop= SpawnItems.instance.DropItemInventory(temp, pos,Quaternion.Euler(0,0,0));
        ItemCtrl itemCtrl=itemDrop.GetComponent<ItemCtrl>();
        itemCtrl.SetItemInventory(temp);
        return true;
    }
}
