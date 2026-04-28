using UnityEngine;

public class EnemyController : ShottingController
{
    [SerializeField] protected SpawnEnemy spawnEnemy;
    public SpawnEnemy SpawnEnemy =>spawnEnemy;
    [SerializeField] protected EnemyShooting enemyShooting;
    public EnemyShooting EnemyShooting => enemyShooting;
    [SerializeField] protected LookatObjByShip lookatObjectShip;
    public LookatObjByShip LookatObjShip=>lookatObjectShip;
    protected override void Reset()
    {
        LoadComponentEnable();
        LoadMeteoriteSO();
        LoadObjectShooting();
        LoadLookatObjByShip();
    }
    protected override void Awake()
    {
        LoadComponentEnable();
        LoadMeteoriteSO();
        LoadObjectShooting();
        LoadLookatObjByShip();
    }
    protected virtual void LoadObjectShooting()
    {
        if (this.enemyShooting != null) return;
        this.enemyShooting=GetComponentInChildren<EnemyShooting>();
    }
    protected override void LoadComponentEnable()
    {
        LoadMeteoriteSO();
        this.spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
    }
    public override void LoadMeteoriteSO()
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
