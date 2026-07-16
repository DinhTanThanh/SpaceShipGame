using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]
public class BossFinalDameReceiver : DameReceiver
{
    [SerializeField] protected ShakeCamera shakeCamera;
    [SerializeField] protected PolygonCollider2D polygonCollider2D;
    [SerializeField] protected BossFinalController bossFinalController;
    [SerializeField] protected UIVictoryController uiController;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossFinalController();
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
            SoundFX.Instance.PlayOneShotSoundBigExplosion();
            this.shakeCamera.SetIsShake(true);
            SpawnExplosionFire.Instance.SetPosition(SpawnExplosionFire.Instance.ExplosionFire, transform.position, transform.rotation);
            transform.parent.gameObject.SetActive(false);
            if (!this.bossFinalController.PlayerController.DameReceiver.IsDead)
            {
                SpawnItems.instance.DropItem(bossFinalController.ShootingSO.dropItems, transform.position, Quaternion.Euler(0, 0, 0));
            }
            this.uiController.SetIsShowUI(true);
        }
    }
    public override void Reborn()
    {
        if (this.bossFinalController == null) return;
        this.hp = this.bossFinalController.ShootingSO.maxHP;
        this.maxHp = this.bossFinalController.ShootingSO.maxHP;
        this.IsDead = false;
    }
}
