using UnityEngine;

public class BossFinalController : ShootingController
{
    [SerializeField] protected BossGateWayController bossGateWayController;
    [SerializeField] protected ManagerPosController managerPosController;
    [SerializeField] protected AbilityMoving abilityMoving;
    public ManagerPosController ManagerPosController => managerPosController;
    public BossGateWayController BossGateWayController => bossGateWayController;
    public AbilityMoving AbilityMoving => abilityMoving;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySO();
        this.LoadBossGateWayController();
        this.LoadManagerPosController();
        this.LoadAbilityMoving();
    }
    protected virtual void LoadAbilityMoving()
    {
        if (this.abilityMoving != null) return;
        this.abilityMoving = GetComponentInChildren<AbilityMoving>();
        this.abilityMoving.SetLimitDistance(25f);
        Debug.LogWarning("Load AbilityMoving: " + transform.name);
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
    protected virtual void LoadBossGateWayController()
    {
        if (this.bossGateWayController != null) return;
        this.bossGateWayController = GetComponentInChildren<BossGateWayController>();
        Debug.LogWarning("Load BossGateWayController: " + transform.name);
    }
}
