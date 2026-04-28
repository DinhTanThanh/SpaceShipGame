using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class ItemPickupable : LoadMonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D collider2;
    [SerializeField] protected ItemCtrl itemCtrl;
    public ItemCtrl ItemCtrl=>itemCtrl;
    protected override void Reset()
    {
        LoadComponent();
        if (rb == null) return;
        rb.gravityScale = 0;
        if (collider2 == null) return;
        collider2.isTrigger = true;
    }
    protected override void Awake()
    {
        LoadComponent();
        if (rb == null) return;
        rb.gravityScale=0;
        if (collider2 == null) return;
        collider2.isTrigger= true;
    }
    protected override void LoadComponent()
    {
        rb= GetComponent<Rigidbody2D>();
        collider2= GetComponent<Collider2D>();
        this.itemCtrl=GetComponentInParent<ItemCtrl>();
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
        SpawnItems.instance.GoBackList(gameObject);
        gameObject.SetActive(false);
    }
    private void OnMouseDown()
    {
        //Debug.Log(transform.parent.name);
        PlayerCtrl.Instance.PlayerPickup.ItemPickup(this);
    }
}
