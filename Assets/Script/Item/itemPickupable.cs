using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class ItemPickupable : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D collider2;
    private void Reset()
    {
        LoadComponent();
        if (rb == null) return;
        rb.gravityScale = 0;
        if (collider2 == null) return;
        collider2.isTrigger = true;
    }
    private void Awake()
    {
        LoadComponent();
        if (rb == null) return;
        rb.gravityScale=0;
        if (collider2 == null) return;
        collider2.isTrigger= true;
    }
    public void LoadComponent()
    {
        rb= GetComponent<Rigidbody2D>();
        collider2= GetComponent<Collider2D>();
    }
    public ItemCode GetItemCode()
    {
        return String2ItemCode(transform.parent.name);
    }
    public ItemCode String2ItemCode(string itemName)
    {
        itemName = itemName.Replace("(Clone)", "");
        return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
    }
    public void Pickup(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
