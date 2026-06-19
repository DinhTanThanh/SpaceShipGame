using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]
public class EnemyV2DameReceive : DameReceiver
{
    [SerializeField] protected PolygonCollider2D polygonCollider2D;
    [SerializeField] protected EnemyV2Controller enemyV2Controller;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPolygonCollider2D();
        this.LoadEnemyV2Controller();
    }
    protected virtual void LoadPolygonCollider2D()
    {
        if (this.polygonCollider2D != null) return;
        this.polygonCollider2D = GetComponent<PolygonCollider2D>();
        this.polygonCollider2D.isTrigger = true;
        Debug.LogWarning("Load PolygonCollider2D: " + transform.name);
    }
    protected virtual void LoadEnemyV2Controller()
    {
        if (this.enemyV2Controller != null) return;
        this.enemyV2Controller = GetComponentInParent<EnemyV2Controller>();
        Debug.LogWarning("Load EnemyV2Controller: " + transform.name);
    }
    private void Update()
    {
        if (!this.isDead) return;
        Transform pos = this.enemyV2Controller.transform;
        SpawnSmoke.instance.SetPosition(SpawnSmoke.instance.Smoke, pos.position, pos.rotation);
        
    }
}
