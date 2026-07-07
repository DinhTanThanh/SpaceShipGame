using UnityEngine;

public class EnemyVGetHpBar : LoadMonoBehaviour
{
    [SerializeField] protected EnemyVController enemyVController;
    public EnemyVController EnemyVController => enemyVController;
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
        this.LoadEnemyVController();
    }
    protected virtual void LoadEnemyVController()
    {
        if (this.enemyVController != null) return;
        this.enemyVController=GetComponentInParent<EnemyVController>();
        Debug.LogWarning("Load EnemyVController: " + transform.name);
    }
    protected virtual void GetHpBar()
    {
        if (SpawnHpBar.Instance == null) return;
        GameObject objHpBar = SpawnHpBar.Instance.SetPosition(SpawnHpBar.Instance.HpBar,this.enemyVController.transform.position,Quaternion.identity);
        HpBar hpBar = objHpBar.GetComponent<HpBar>();
        if (hpBar == null) return;
        hpBar.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        hpBar.SetShootingController(this.enemyVController);
        hpBar.FollowTarget.SetTarget(transform.parent);
    }
}
