using UnityEngine;

public class BossSpaceController : ShootingController
{
    [SerializeField] protected BossSpaceGateWayController bossSpaceGetwayController;
    [SerializeField] protected ManagerPosController managerPosController;
    public ManagerPosController ManagerPosController => managerPosController;
    public BossSpaceGateWayController BossSpaceGateWayController => bossSpaceGetwayController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySO();
        this.LoadBossSpaceGateWayController();
        this.LoadManagerPosController();
    }
    public override void LoadEnemySO()
    {
        if (this.shootingSO != null) return;
        string path = "Shooting/Enemy/" + transform.name;
        Debug.Log(path);
        this.shootingSO = Resources.Load<ShootingSO>(path);
    }
    protected virtual void LoadManagerPosController()
    {
        if (this.managerPosController != null) return;
        this.managerPosController = GetComponentInChildren<ManagerPosController>();
        Debug.LogWarning("Load ManagerPosController: " + transform.name);
    }
    protected virtual void LoadBossSpaceGateWayController()
    {
        if (this.bossSpaceGetwayController != null) return;
        this.bossSpaceGetwayController = GetComponentInChildren<BossSpaceGateWayController>();
        Debug.LogWarning("Load BossSpaceGateWayController: " + transform.name);
    }
}
