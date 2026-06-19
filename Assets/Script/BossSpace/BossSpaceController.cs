using UnityEngine;

public class BossSpaceController : LoadMonoBehaviour
{
    [SerializeField] protected ShootingSO bossSpace;
    [SerializeField] protected BossSpaceGateWayController bossSpaceGetwayController;
    [SerializeField] protected ManagerPosController managerPosController;
    public ManagerPosController ManagerPosController => managerPosController;
    public BossSpaceGateWayController BossSpaceGateWayController => bossSpaceGetwayController;
    public ShootingSO BossSpace => bossSpace;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySO();
        this.LoadBossSpaceGateWayController();
        this.LoadManagerPosController();
    }
    protected virtual void LoadEnemySO()
    {
        if (this.bossSpace != null) return;
        string path = "Shooting/Enemy/" + transform.name;
        Debug.Log(path);
        this.bossSpace = Resources.Load<ShootingSO>(path);
    }
    protected virtual void LoadManagerPosController()
    {
        if(this.managerPosController != null) return;
        this.managerPosController=GetComponentInChildren<ManagerPosController>();
        Debug.LogWarning("Load ManagerPosController: " + transform.name);
    }
    protected virtual void LoadBossSpaceGateWayController()
    {
        if (this.bossSpaceGetwayController != null) return;
        this.bossSpaceGetwayController = GetComponentInChildren<BossSpaceGateWayController>();
        Debug.LogWarning("Load BossSpaceGateWayController: " + transform.name);
    }
}
