using UnityEngine;

public class BossSpaceGetHpBar : LoadMonoBehaviour
{
    [SerializeField] protected BossSpaceController bossSpaceController;
    public BossSpaceController BossSpaceController => bossSpaceController;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetHpBar();
    }
    protected override void Start()
    {
        base.Start();
        this.GetHpBar();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossSpaceController();
    }
    protected virtual void LoadBossSpaceController()
    {
        if (this.bossSpaceController != null) return;
        this.bossSpaceController = GetComponentInParent<BossSpaceController>();
        Debug.LogWarning("Load BossSpaceController: " + transform.name);
    }
    protected virtual void GetHpBar()
    {
        if (SpawnHpBar.Instance == null) return;
        GameObject objHpBar = SpawnHpBar.Instance.SetPosition(SpawnHpBar.Instance.HpBar, this.bossSpaceController.transform.position, Quaternion.identity);
        HpBar hpBar = objHpBar.GetComponent<HpBar>();
        if (hpBar == null) return;
        hpBar.transform.localScale = new Vector3(2f,3f, 2f);
        hpBar.SetShootingController(this.bossSpaceController);
        hpBar.FollowTarget.SetTarget(transform.parent);
    }
}
