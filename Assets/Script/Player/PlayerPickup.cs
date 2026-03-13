using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public void ItemPickup(ItemPickupable itemPickupable)
    {
        ItemCode itemCode=itemPickupable.GetItemCode();
        if (this.playerCtrl.ShipController.Inventory.AddItem(itemCode, 1))
        {
            itemPickupable.Pickup(itemPickupable.transform.parent.gameObject);
        }
    }
}
