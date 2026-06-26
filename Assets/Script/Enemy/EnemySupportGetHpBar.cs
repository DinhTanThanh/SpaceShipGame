using UnityEngine;

public class EnemySupportGetHpBar : LoadMonoBehaviour
{
    [SerializeField] protected EnemySupportController enemySupportController;
    public EnemySupportController EnemySupportController => enemySupportController;
    protected override void Start()
    {
        base.Start();
        this.GetHpBar();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySupportController();
    }
    protected virtual void LoadEnemySupportController()
    {
        if (this.enemySupportController != null) return;
        this.enemySupportController = GetComponentInParent<EnemySupportController>();
        Debug.LogWarning("Load EnemySupportController: " + transform.name);
    }
    protected virtual void GetHpBar()
    {
        GameObject objHpBar = SpawnHpBar.Instance.SetPosition(SpawnHpBar.Instance.HpBar, this.enemySupportController.transform.position, Quaternion.identity);
        HpBar hpBar = objHpBar.GetComponent<HpBar>();
        if (hpBar == null) return;
        hpBar.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        hpBar.SetShootingController(this.enemySupportController);
        hpBar.FollowTarget.SetTarget(transform.parent);
    }
}
