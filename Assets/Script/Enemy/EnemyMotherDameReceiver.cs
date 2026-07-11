using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class EnemyMotherDameReceiver : DameReceiver
{
    [SerializeField] protected UIVictoryController uiController;
    [SerializeField] protected ShakeCamera shakeCamera;
    public PolygonCollider2D polygonCollider2D;
    public EnemyMotherShipCtrl EnemyMotherShipCtrl;
    protected override void LoadComponent()
    {
        this.EnemyMotherShipCtrl = transform.parent.GetComponent<EnemyMotherShipCtrl>();
        this.polygonCollider2D = GetComponent<PolygonCollider2D>();
        this.polygonCollider2D.isTrigger = true;
        this.LoadShakeCamera();
        this.LoadUIController();
        this.Reborn();
    }
    protected virtual void LoadUIController()
    {
        if (this.uiController != null) return;
        this.uiController=FindFirstObjectByType<UIVictoryController>();
        Debug.LogWarning("Load UIController: " + transform.name);
    }
    protected override void LoadComponentEnable()
    {
        this.Reborn();
    }
    private void Update()
    {
        if (this.IsDead == true)
        {
            SoundFX.Instance.PlayOneShotSoundBigExplosion();
            this.shakeCamera.SetIsShake(true);
            SpawnExplosionFire.Instance.SetPosition(SpawnExplosionFire.Instance.ExplosionFire, transform.position, transform.rotation);
            transform.parent.gameObject.SetActive(false);
            SpawnItems.instance.DropItem(this.EnemyMotherShipCtrl.ShootingSO.dropItems, transform.position, Quaternion.Euler(0, 0, 0));
            this.uiController.SetIsShowUI(true);
            SpawnItemVitalityUp.Instance.SetPosition(SpawnItemVitalityUp.Instance.ItemVitalityUp, this.transform.parent.position, Quaternion.Euler(0, 0, 0));
        }
    }
    protected virtual void LoadShakeCamera()
    {
        if (this.shakeCamera != null) return;
        this.shakeCamera = FindFirstObjectByType<ShakeCamera>();
        Debug.LogWarning("Load ShakeCamera: " + transform.name);
    }
    public override void Reborn()
    {
        this.hp = this.EnemyMotherShipCtrl.ShootingSO.maxHP;
        this.maxHp = this.EnemyMotherShipCtrl.ShootingSO.maxHP;
        this.IsDead = false;
    }
}
