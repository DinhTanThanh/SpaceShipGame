using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]
public class EnemyVDameReceive : DameReceiver
{
    [SerializeField] protected PolygonCollider2D polygonCollider2D;
    [SerializeField] protected EnemyVController enemyVController;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPolygonCollider2D();
        this.LoadEnemyV2Controller();
        this.Reborn();
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
        if (this.enemyVController != null) return;
        this.enemyVController = GetComponentInParent<EnemyVController>();
        Debug.LogWarning("Load EnemyV2Controller: " + transform.name);
    }
    private void Update()
    {
        if (!this.isDead) return;
        SoundFX.Instance.PlayOneShotSoundSmallExplosion();
        Transform pos = this.enemyVController.transform;
        SpawnSmoke.instance.SetPosition(SpawnSmoke.instance.Smoke, pos.position, pos.rotation);
        SpawnItems.instance.DropItem(this.enemyVController.ShootingSO.dropItems, this.transform.parent.position, Quaternion.identity);
        transform.parent.gameObject.SetActive(false);
    }
    public override void Reborn()
    {
        if (this.enemyVController == null) return;
        this.maxHp = this.enemyVController.ShootingSO.maxHP;
        this.hp = this.enemyVController.ShootingSO.maxHP;
        this.isDead = false;
    }
}
