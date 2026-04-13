using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public void ItemPickup(ItemPickupable itemPickupable)
    {
        //ItemCode itemCode=itemPickupable.GetItemCode();
        ItemInventory itemInventory = itemPickupable.GetComponentInParent<ItemCtrl>().ItemInventory;
        if (this.playerCtrl.ShipController.Inventory.AddItem(itemInventory))
        {
            itemPickupable.Pickup(itemPickupable.transform.parent.gameObject);
        }
    }
}
