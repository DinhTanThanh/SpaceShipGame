using UnityEngine;

public class EnemyController : ShottingController
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
        string nameMeteoriteSO = "Shotting/Enemy/" + transform.name;
        this.shottingSO = Resources.Load<ShottingSO>(nameMeteoriteSO);
    }
    protected virtual void LoadLookatObjByShip()
    {
        if(this.lookatObjectShip != null) return;
        this.lookatObjectShip = GetComponentInChildren<LookatObjByShip>();
    }
}
