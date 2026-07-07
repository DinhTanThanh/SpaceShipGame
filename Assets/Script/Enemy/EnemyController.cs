using UnityEngine;

public class EnemyController : ShootingController
{
    [SerializeField] protected GameObject motherShip;
    [SerializeField] protected EnemyShooting enemyShooting;
    [SerializeField] protected LookatObjByShip lookatObjectShip;
    public EnemyShooting EnemyShooting => enemyShooting;
    public LookatObjByShip LookatObjShip=>lookatObjectShip;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadComponentEnable();
        this.LoadEnemySO();
        this.LoadObjectShooting();
        this.LoadLookatObjByShip();
        this.LoadMotherShip();
    }
    private void Update()
    {
        if (this.motherShip.activeSelf) return;
        this.damgeReceiver.IsDead = true;
    }
    protected virtual void LoadObjectShooting()
    {
        if (this.enemyShooting != null) return;
        this.enemyShooting=GetComponentInChildren<EnemyShooting>();
        Debug.LogWarning("Load ObjectShooting: " + transform.name);
    }
    protected virtual void LoadMotherShip()
    {
        if(this.motherShip != null) return;
        this.motherShip = GameObject.Find("MotherShip_1");
        Debug.LogWarning("Load MotherShip_1: " + transform.name);
    }
    protected override void LoadComponentEnable()
    {
        LoadEnemySO();
    }
    public override void LoadEnemySO()
    {
        string nameMeteoriteSO = "Shooting/Enemy/" + transform.name;
        this.shootingSO = Resources.Load<ShootingSO>(nameMeteoriteSO);
        if (this.shootingSO == null)
        {
            this.shootingSO = Resources.Load<ShootingSO>("Shooting/Enemy/EnemyDefault");
        }
    }
    protected virtual void LoadLookatObjByShip()
    {
        if(this.lookatObjectShip != null) return;
        this.lookatObjectShip = GetComponentInChildren<LookatObjByShip>();
    }
}
