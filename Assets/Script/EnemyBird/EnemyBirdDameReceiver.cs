using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]
public class EnemyBirdDameReceiver : DameReceiver
{
    public PolygonCollider2D polygonCollider2D;
    public EnemyBirdController EnemyBirdController;
    protected override void Reset()
    {
        this.EnemyBirdController = transform.parent.GetComponent<EnemyBirdController>();
        this.polygonCollider2D = GetComponent<PolygonCollider2D>();
        this.polygonCollider2D.isTrigger = true;
        Reborn();
    }
    private void Update()
    {
        if (IsDead == true)
        {
            SpawnSmoke.instance.SetPosition(SpawnSmoke.instance.Smoke, transform.position, transform.rotation);
            transform.parent.gameObject.SetActive(false);
            Reborn();
            SpawnEnemyBird.Instance.GoBackList(transform.parent.gameObject);
            SpawnItems.instance.DropItem(EnemyBirdController.ShootingSO.dropItems, transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
    public override void Reborn()
    {
        this.hp = this.EnemyBirdController.ShootingSO.maxHP;
        this.maxHp = this.EnemyBirdController.ShootingSO.maxHP;
        this.IsDead = false;
    }
}
