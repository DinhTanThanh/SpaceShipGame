using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]
public class BossSpaceDameReceiver : DameReceiver
{
    [SerializeField] protected ShakeCamera shakeCamera;
    [SerializeField] protected PolygonCollider2D polygonCollider2D;
    [SerializeField] protected BossSpaceController BossSpaceController;
    [SerializeField] protected UIVictoryController uiController;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossSpaceController();
        this.LoadPolygonCollider2D();
        this.LoadShakeCamera();
        this.LoadUIController();
        this.Reborn();
    }
    protected virtual void LoadUIController()
    {
        if (this.uiController != null) return;
        this.uiController = FindFirstObjectByType<UIVictoryController>();
        Debug.LogWarning("Load UIController: " + transform.name);
    }
    protected virtual void LoadBossSpaceController()
    {
        if (this.BossSpaceController != null) return;
        this.BossSpaceController = transform.parent.GetComponent<BossSpaceController>();
        Debug.LogWarning("Load BossSpaceController: " + transform.name);
    }
    protected virtual void LoadPolygonCollider2D()
    {
        if(this.polygonCollider2D!=null) return;
        this.polygonCollider2D= GetComponent<PolygonCollider2D>();
        this.polygonCollider2D.isTrigger = true;
        Debug.LogWarning("Load PolygonCollider2D: " + transform.name);
    }
    protected virtual void LoadShakeCamera()
    {
        if (this.shakeCamera != null) return;
        this.shakeCamera=FindFirstObjectByType<ShakeCamera>();
        Debug.LogWarning("Load ShakeCamera: " + transform.name);
    }
    private void Update()
    {
        if (this.IsDead == true)
        {
            this.shakeCamera.SetIsShake(true);
            SpawnExplosionFire.Instance.SetPosition(SpawnExplosionFire.Instance.ExplosionFire, transform.position, transform.rotation);
            transform.parent.gameObject.SetActive(false);
            SpawnItems.instance.DropItem(BossSpaceController.ShootingSO.dropItems, transform.position, Quaternion.Euler(0, 0, 0));
            this.uiController.SetIsShowUI(true);
        }
    }
    public override void Reborn()
    {
        this.hp = this.BossSpaceController.ShootingSO.maxHP;
        this.maxHp = this.BossSpaceController.ShootingSO.maxHP;
        this.IsDead = false;
    }
}
