using UnityEngine;

public class EnemyController : ShootingController
{
    [SerializeField] protected EnemyShooting enemyShooting;
    public EnemyShooting EnemyShooting => enemyShooting;
    [SerializeField] protected LookatObjByShip lookatObjectShip;
    public LookatObjByShip LookatObjShip=>lookatObjectShip;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadComponentEnable();
        LoadEnemySO();
        LoadObjectShooting();
        LoadLookatObjByShip();
    }
    protected virtual void LoadObjectShooting()
    {
        if (this.enemyShooting != null) return;
        this.enemyShooting=GetComponentInChildren<EnemyShooting>();
        Debug.LogWarning("Load ObjectShooting: " + transform.name);
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
