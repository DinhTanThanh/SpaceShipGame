using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class ItemLooter : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D collider2;
    public Inventory inventory;
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemPickupable itemPickupable=collision.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;
        Debug.Log("Can pickup");
        ItemCode itemCode=itemPickupable.GetItemCode();
        if (itemCode == ItemCode.NullItem) return;
        if (inventory.AddItem(itemCode, 1))
        {
            itemPickupable.Pickup(collision.transform.parent.gameObject);
        }
        
    }
}
