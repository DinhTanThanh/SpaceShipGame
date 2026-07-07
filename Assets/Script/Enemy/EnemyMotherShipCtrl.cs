using UnityEngine;

public class EnemyMotherShipCtrl : ShootingController
{
    [SerializeField] protected GameObject posOnEnable;
    [SerializeField] protected GameObject managerEnemy;
    public GameObject ManagerEnemy => managerEnemy;
    [SerializeField] protected AbilitySummonController abilitySummonController;
    public AbilitySummonController AbilitySummonController => abilitySummonController;
    protected override void OnEnable()
    {
        base.OnEnable();
        this.transform.position = this.posOnEnable.transform.position;
        this.abilitySummonController.EnergyShieldYellowController.DameReceiver.Reborn();
        this.abilitySummonController.EnergyShieldYellowController.gameObject.SetActive(true);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManagerEnemy();
        this.LoadabilitySummonController();
        this.LoadPosOnEnable();
        this.LoadEnemySO();
    }
    protected virtual void LoadPosOnEnable()
    {
        if (this.posOnEnable != null) return;
        this.posOnEnable = GameObject.Find("PosOnEnable");
        Debug.LogWarning("Load PosOnEnable: " + transform.name);
    }
    protected virtual void LoadabilitySummonController()
    {
        if (this.abilitySummonController != null) return;
        this.abilitySummonController=GetComponentInChildren<AbilitySummonController>();
        Debug.LogWarning("Load AbilitySummonController: " + transform.name);
    }
    protected override void LoadComponentEnable()
    {
        LoadEnemySO();
    }
    protected virtual void LoadManagerEnemy()
    {
        if (this.managerEnemy != null) return;
        this.managerEnemy = GameObject.Find("ManagerEnemy");
        Debug.LogWarning("Load ManagerEnemy: " + transform.name);
    }
    public override void LoadEnemySO()
    {
        string nameMeteoriteSO = "Shooting/Enemy/" + transform.name;
        this.shootingSO = Resources.Load<ShootingSO>(nameMeteoriteSO);
        //Debug.LogWarning("Load ShottingSO: " + transform.name);
    }
}
