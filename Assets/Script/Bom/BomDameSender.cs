using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]
public class BomDameSender : DameSender
{
    [SerializeField] protected PolygonCollider2D polygonCollider2D;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPolygonCollider2D();
    }
    protected virtual void LoadPolygonCollider2D()
    {
        if (this.polygonCollider2D != null) return;
        this.polygonCollider2D=GetComponent<PolygonCollider2D>();
        this.polygonCollider2D.isTrigger = true;
        Debug.LogWarning("Load PolygonCollider2D: " + transform.name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerDameReceiver playerDameReceiver=collision.transform.parent?.parent?.GetComponentInChildren<PlayerDameReceiver>();
        if (playerDameReceiver == null) return;
        SendDame(playerDameReceiver,2);
    }
}
