using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class EnemyMotherDameReceiver : DameReceiver
{
    public PolygonCollider2D polygonCollider2D;
    public EnemyMotherShipCtrl EnemyMotherShipCtrl;
    protected override void LoadComponent()
    {
        EnemyMotherShipCtrl = transform.parent.GetComponent<EnemyMotherShipCtrl>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        polygonCollider2D.isTrigger = true;
        Reborn();
    }
    protected override void LoadComponentEnable()
    {
        Reborn();
    }
    private void Update()
    {
        if (IsDead == true)
        {
            SpawnSmoke.instance.SetPosition(SpawnSmoke.instance.Smoke, transform.position, transform.rotation);
            transform.parent.gameObject.SetActive(false);
            SpawnItems.instance.DropItem(this.EnemyMotherShipCtrl.ShootingSO.dropItems, transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
    public override void Reborn()
    {
        this.hp = this.EnemyMotherShipCtrl.ShootingSO.maxHP;
        this.maxHp = this.EnemyMotherShipCtrl.ShootingSO.maxHP;
        this.IsDead = false;
    }
}
