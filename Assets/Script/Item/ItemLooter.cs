using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class ItemLooter : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D collider2;
    public Inventory inventory;
    public PlayerController Ship;
    private void Reset()
    {
        LoadComponent();
    }
    private void Awake()
    {
        LoadComponent();
        if (rb == null) return;
        rb.gravityScale = 0;
        if(collider2 == null) return;
        collider2.isTrigger= true;
    }
    public void LoadComponent()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2 = GetComponent<Collider2D>();
        inventory=transform.parent.GetComponent<Inventory>();
        Ship=GetComponentInParent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemPickupable itemPickupable=collision.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;
        //Debug.Log("Can pickup");
        ItemCode itemCode=itemPickupable.GetItemCode();
        if (itemCode == ItemCode.NullItem) return;
        if (Ship.PlayerCtrl.ShipController.Inventory.AddItem(itemCode, 1))
        {
            itemPickupable.Pickup(collision.transform.parent.gameObject);
        }
        
    }
}
