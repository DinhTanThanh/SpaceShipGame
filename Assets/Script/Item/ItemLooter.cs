using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class ItemLooter : LoadMonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D collider2;
    public Inventory inventory;
    public PlayerController Ship;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delay = 0.5f;
    protected override void LoadComponent()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2 = GetComponent<Collider2D>();
        inventory = transform.parent.GetComponent<Inventory>();
        Ship = GetComponentInParent<PlayerController>();
        if (rb == null) return;
        rb.gravityScale = 0;
        if (collider2 == null) return;
        collider2.isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemPickupable itemPickupable = collision.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;
        ItemCtrl itemCtrl = itemPickupable.ItemCtrl;//nếu getcomponentinparent thì nó sẽ bị race condition (giải pháp là lưu luôn thằng cha không cần phải tìm lại)
        if (itemCtrl == null)
        {
            Debug.Log("Chưa tạo kịp");
            return;
        }
        ItemInventory itemInventory = itemCtrl.ItemInventory;
        if (Ship.PlayerCtrl.ShipController.Inventory.AddItem(itemInventory))
        {
            SoundFX.Instance.PlayOneShotSoundLoot();
            itemPickupable.Pickup(collision.transform.parent.gameObject);
        }
    }
    protected void DelayPickupItem()
    {
        while (true)
        {
            this.timer += Time.deltaTime;
            if (timer >= delay)
            {
                this.timer = 0f;
                return;
            } 
        }
    }
}
