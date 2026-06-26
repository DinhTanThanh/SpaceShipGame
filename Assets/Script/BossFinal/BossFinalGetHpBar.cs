using UnityEngine;

public class BossFinalGetHpBar : LoadMonoBehaviour
{
    [SerializeField] protected BossFinalController bossFinalController;
    public BossFinalController BossFinalController => bossFinalController;
    protected override void Start()
    {
        base.Start();
        this.GetHpBar();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossFinalController();
    }
    protected virtual void LoadBossFinalController()
    {
        if (this.bossFinalController != null) return;
        this.bossFinalController = GetComponentInParent<BossFinalController>();
        Debug.LogWarning("Load BossFinalController: " + transform.name);
    }
    protected virtual void GetHpBar()
    {
        GameObject objHpBar = SpawnHpBar.Instance.SetPosition(SpawnHpBar.Instance.HpBar, this.bossFinalController.transform.position, Quaternion.identity);
        HpBar hpBar = objHpBar.GetComponent<HpBar>();
        if (hpBar == null) return;
        hpBar.transform.localScale = new Vector3(3f, 3f, 2f);
        hpBar.SetShootingController(this.bossFinalController);
        hpBar.FollowTarget.SetTarget(transform.parent);
    }
}
