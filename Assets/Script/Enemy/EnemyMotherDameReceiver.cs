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
            //Debug.Log("object đã chết");
            SpawnSmoke.instance.SetPosition(SpawnSmoke.instance.Smoke, transform.position, transform.rotation);
            transform.parent.gameObject.SetActive(false);
            Reborn();
            SpawnEnemy.instance.GoBackList(transform.parent.gameObject);
            SpawnItems.instance.SpawnItem(EnemyMotherShipCtrl.ShottingSO.dropItems, transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
    public override void Reborn()
    {
        this.HP = EnemyMotherShipCtrl.ShottingSO.maxHP;
        this.IsDead = false;
    }
}
