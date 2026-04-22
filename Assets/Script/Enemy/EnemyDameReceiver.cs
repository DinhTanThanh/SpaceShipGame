using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class EnemyDameReceiver : DameReceiver
{
    public PolygonCollider2D polygonCollider2D;
    public EnemyController EnemyCtrl;
    private void Reset()
    {
        EnemyCtrl = transform.parent.GetComponent<EnemyController>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        polygonCollider2D.isTrigger = true;
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
            //spawnitems.instance.spawnitem(meteoritectrller.meteoriteso.dropitems, transform.position, quaternion.euler(0, 0, 0));
        }
    }
    public override void Reborn()
    {
        this.HP = EnemyCtrl.ShottingSO.maxHP;
        this.IsDead = false;
    }
}
