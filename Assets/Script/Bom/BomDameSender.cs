using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]
public class BomDameSender : DameSender
{
    [SerializeField] protected PolygonCollider2D polygonCollider2D;
    [SerializeField] protected BomController bomController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPolygonCollider2D();
        this.LoadBomController();
    }
    protected virtual void LoadBomController()
    {
        if (this.bomController != null) return;
        this.bomController=GetComponentInParent<BomController>();
        Debug.LogWarning("Load BomController: " + transform.name);
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
        Debug.Log("Va chom");
        PlayerDameReceiver playerDameReceiver=collision.transform.parent?.parent?.GetComponentInChildren<PlayerDameReceiver>();
        if (playerDameReceiver == null) return;
        Debug.Log("Vao va cham");
        SendDame(playerDameReceiver,2);
        this.bomController.BomDameReceiver.IsDead = true;
    }
}
