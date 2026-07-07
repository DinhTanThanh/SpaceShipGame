using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]
public class EnemySupportDameReceiver : DameReceiver
{
    [SerializeField] protected PolygonCollider2D polygonCollider2D;
    [SerializeField] protected EnemySupportController enemySupportController;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPolygonCollider2D();
        this.LoadEnemySupportController();
        this.Reborn();
    }
    protected virtual void LoadPolygonCollider2D()
    {
        if (this.polygonCollider2D != null) return;
        this.polygonCollider2D = GetComponent<PolygonCollider2D>();
        this.polygonCollider2D.isTrigger = true;
        Debug.LogWarning("Load PolygonCollider2D: " + transform.name);
    }
    protected virtual void LoadEnemySupportController()
    {
        if (this.enemySupportController != null) return;
        this.enemySupportController = GetComponentInParent<EnemySupportController>();
        Debug.LogWarning("Load EnemySupportController: " + transform.name);
    }
    private void Update()
    {
        if (!this.isDead) return;
        Transform pos = this.enemySupportController.transform;
        SpawnSmoke.instance.SetPosition(SpawnSmoke.instance.Smoke, pos.position, pos.rotation);
        SpawnItems.instance.DropItem(this.enemySupportController.ShootingSO.dropItems, this.transform.parent.position, Quaternion.identity);
        transform.parent.gameObject.SetActive(false);
    }
    public override void Reborn()
    {
        if (this.enemySupportController == null) return;
        this.maxHp = this.enemySupportController.ShootingSO.maxHP;
        this.hp = this.enemySupportController.ShootingSO.maxHP;
        this.isDead = false;
    }
}
