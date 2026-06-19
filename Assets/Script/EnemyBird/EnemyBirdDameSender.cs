using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]
public class EnemyBirdDameSender : DameSender
{
    [SerializeField] protected PolygonCollider2D polygonCollider2D;
    [SerializeField] protected EnemyBirdController enemyBirdController;
    public EnemyBirdController EnemyBirdController => enemyBirdController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyBirdController();
        this.LoadPolygonCollider2D();
        this.polygonCollider2D.isTrigger = true;
    }
    protected virtual void LoadPolygonCollider2D()
    {
        if (this.polygonCollider2D != null) return;
        this.polygonCollider2D = GetComponentInParent<PolygonCollider2D>();
        Debug.LogWarning("Load PolygonCollider2D: " + transform.name);
    }
    protected virtual void LoadEnemyBirdController()
    {
        if (this.enemyBirdController != null) return;
        this.enemyBirdController = GetComponentInParent<EnemyBirdController>();
        Debug.LogWarning("Load EnemyBirdController: " + transform.name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerDameReceiver playerDameReceive = collision.transform.parent?.parent?.GetComponentInChildren<PlayerDameReceiver>();
        if (playerDameReceive == null) return;
        playerDameReceive.Receive(3);
        SpawnSmoke.instance.SetPosition(SpawnSmoke.instance.Smoke, transform.position, transform.rotation);
        transform.parent.gameObject.SetActive(false);
        SpawnEnemyBird.Instance.GoBackList(transform.parent.gameObject);
        SpawnItems.instance.DropItem(this.EnemyBirdController.ShootingSO.dropItems, transform.position, Quaternion.Euler(0, 0, 0));
    }
}
