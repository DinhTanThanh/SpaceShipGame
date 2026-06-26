using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]
public class BossFinalDameReceiver : DameReceiver
{
    [SerializeField] protected ShakeCamera shakeCamera;
    [SerializeField] protected PolygonCollider2D polygonCollider2D;
    [SerializeField] protected BossFinalController bossFinalController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossFinalController();
        this.LoadPolygonCollider2D();
        this.LoadShakeCamera();
        this.Reborn();
    }
    protected virtual void LoadBossFinalController()
    {
        if (this.bossFinalController != null) return;
        this.bossFinalController = transform.parent.GetComponent<BossFinalController>();
        Debug.LogWarning("Load BossFinalController: " + transform.name);
    }
    protected virtual void LoadPolygonCollider2D()
    {
        if (this.polygonCollider2D != null) return;
        this.polygonCollider2D = GetComponent<PolygonCollider2D>();
        this.polygonCollider2D.isTrigger = true;
        Debug.LogWarning("Load PolygonCollider2D: " + transform.name);
    }
    protected virtual void LoadShakeCamera()
    {
        if (this.shakeCamera != null) return;
        this.shakeCamera = FindFirstObjectByType<ShakeCamera>();
        Debug.LogWarning("Load ShakeCamera: " + transform.name);
    }
    private void Update()
    {
        if (this.IsDead == true)
        {
            this.shakeCamera.SetIsShake(true);
            SpawnExplosionFire.Instance.SetPosition(SpawnExplosionFire.Instance.ExplosionFire, transform.position, transform.rotation);
            transform.parent.gameObject.SetActive(false);
            SpawnItems.instance.DropItem(bossFinalController.ShootingSO.dropItems, transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
    public override void Reborn()
    {
        this.hp = this.bossFinalController.ShootingSO.maxHP;
        this.maxHp = this.bossFinalController.ShootingSO.maxHP;
        this.IsDead = false;
    }
}
