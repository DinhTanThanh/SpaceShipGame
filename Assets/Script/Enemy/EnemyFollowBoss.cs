using UnityEngine;

public class EnemyFollowBoss : LoadMonoBehaviour
{
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected Transform target;
    [SerializeField] protected BossSpaceController bossSpaceController;
    public BossSpaceController BossSpaceController => bossSpaceController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossSpaceController();
        this.LoadTarget();
    }
    private void Update()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        Vector3 start = transform.parent.position;
        Vector3 target=this.target.position;
        this.transform.parent.position = Vector3.Lerp(start, target, Time.deltaTime*this.speed);
    }
    protected virtual void LoadBossSpaceController()
    {
        if (this.bossSpaceController != null) return;
        this.bossSpaceController=FindFirstObjectByType<BossSpaceController>();
        Debug.LogWarning("Load BossSpaceController: " + transform.name);
    }
    protected virtual void LoadTarget()
    {
        if(this.target != null) return;
        string name = this.transform.parent.name.Replace("Enemy_", "");
        this.target = this.bossSpaceController.ManagerPosController.GetPositionByName(name);
    }
}
