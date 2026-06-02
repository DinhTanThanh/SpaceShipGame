using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class EnemyDameReceiver : DameReceiver
{
    public PolygonCollider2D polygonCollider2D;
    public EnemyController EnemyCtrl;
    protected override void LoadComponent()
    {
        this.LoadEnemyController();
        this.LoadPolygonCollider2D();
        this.polygonCollider2D.isTrigger = true;
        this.Reborn();
    }
    protected virtual void LoadPolygonCollider2D()
    {
        if (this.polygonCollider2D != null) return;
        this.polygonCollider2D = GetComponent<PolygonCollider2D>();
        Debug.LogWarning("Load PolygonCollider2D: " + transform.name);
    }
    protected virtual void LoadEnemyController()
    {
        if (this.EnemyCtrl != null) return;
        this.EnemyCtrl = transform.parent.GetComponent<EnemyController>();
        Debug.LogWarning("Load EnemyController: " + transform.name);
    }
    protected override void LoadComponentEnable()
    {
        this.Reborn();
    }
    private void Update()
    {
        this.OnDead();
    }
    protected virtual void OnDead()
    {
        if (this.IsDead == true)
        {
            SpawnSmoke.instance.SetPosition(SpawnSmoke.instance.Smoke, transform.position, transform.rotation);
            transform.parent.gameObject.SetActive(false);
            SpawnItems.instance.DropItem(this.EnemyCtrl.ShootingSO.dropItems, transform.position, Quaternion.Euler(0, 0, 0));
            Vector3 posDrop = this.transform.position;
            posDrop.x += 0.7f;
            posDrop.y += 0.7f;
            SpawnItemVitalityUp.Instance.SetPosition(SpawnItemVitalityUp.Instance.ItemVitalityUp, posDrop, Quaternion.Euler(0, 0, 0));
        }
    }
    public override void Reborn()
    {
        this.hp = this.EnemyCtrl.ShootingSO.maxHP;
        this.maxHp=this.EnemyCtrl.ShootingSO.maxHP;
        this.IsDead = false;
    }
}
