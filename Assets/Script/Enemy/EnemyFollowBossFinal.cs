using UnityEngine;

public class EnemyFollowBossFinal : LoadMonoBehaviour
{
    [SerializeField] protected float speed = 0.5f;
    [SerializeField] protected Transform target;
    [SerializeField] protected BossFinalController bossFinalController;
    public BossFinalController BossFinalController => bossFinalController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossFinalController();
        this.LoadTarget();
    }
    private void Update()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
        Vector3 start = transform.parent.position;
        Vector3 target = this.target.position;
        this.transform.parent.position = Vector3.Lerp(start, target, Time.deltaTime * this.speed);
    }
    protected virtual void LoadBossFinalController()
    {
        if (this.bossFinalController != null) return;
        this.bossFinalController = FindFirstObjectByType<BossFinalController>();
        Debug.LogWarning("Load BossFinalController: " + transform.name);
    }
    protected virtual void LoadTarget()
    {
        if (this.target != null) return;
        string name = this.transform.parent.name.Replace("Enemy_", "");
        this.target = this.bossFinalController.ManagerPosController.GetPositionByName(name);
    }
}
