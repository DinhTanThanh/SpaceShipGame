using UnityEngine;

public class SupportShipGetHpbar : LoadMonoBehaviour
{
    [SerializeField] protected SupportShipController supportShipController;
    public SupportShipController SupportShipController => supportShipController;
    protected override void Start()
    {
        base.Start();
        this.GetHpBar();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetHpBar();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSupportShipController();
    }
    protected virtual void LoadSupportShipController()
    {
        if (this.supportShipController != null) return;
        this.supportShipController = GetComponentInParent<SupportShipController>();
        Debug.LogWarning("Load SupportShipController: " + transform.name);
    }
    protected virtual void GetHpBar()
    {
        if (SpawnHpBar.Instance == null) return;
        GameObject objHpBar = SpawnHpBar.Instance.SetPosition(SpawnHpBar.Instance.HpBar, this.supportShipController.transform.position, Quaternion.identity);
        HpBar hpBar = objHpBar.GetComponent<HpBar>();
        if (hpBar == null) return;
        hpBar.SliderChangeHp.ChangeColorHpbar(Color.blue);
        hpBar.transform.localScale = new Vector3(1f, 1f, 1f);
        hpBar.SetShootingController(this.supportShipController);
        hpBar.FollowTarget.SetTarget(transform.parent);
    }
}
