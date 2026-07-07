using System.Collections.Generic;
using UnityEngine;

public class BossSpaceController : ShootingController
{
    [SerializeField] protected BossSpaceGateWayController bossSpaceGetwayController;
    [SerializeField] protected ManagerPosController managerPosController;
    [SerializeField] protected Transform posOnEnable;
    [SerializeField] protected List<EnemyVController> listEnemyV=new List<EnemyVController>();
    public ManagerPosController ManagerPosController => managerPosController;
    public BossSpaceGateWayController BossSpaceGateWayController => bossSpaceGetwayController;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.transform.position = this.posOnEnable.position;
        foreach(EnemyVController enemyV in this.listEnemyV)
        {
            enemyV.DameReceiver.Reborn();
        }
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySO();
        this.LoadBossSpaceGateWayController();
        this.LoadManagerPosController();
        this.LoadPosOnEnable();
        this.GetListEnemyV();
    }
    protected virtual void GetListEnemyV()
    {
        if (this.listEnemyV.Count > 0) return;
        this.listEnemyV=new List<EnemyVController>(FindObjectsByType<EnemyVController>(FindObjectsSortMode.None));
        Debug.LogWarning("Get ListEnemyV");
    }
    public override void LoadEnemySO()
    {
        if (this.shootingSO != null) return;
        string path = "Shooting/Enemy/" + transform.name;
        Debug.Log(path);
        this.shootingSO = Resources.Load<ShootingSO>(path);
    }
    protected virtual void LoadPosOnEnable()
    {
        if(this.posOnEnable != null) return;
        this.posOnEnable = GameObject.Find("PosOnEnable")?.transform;
        Debug.LogWarning("Load PosOnEnable: " + transform.name);
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
