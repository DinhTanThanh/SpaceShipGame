using UnityEngine;

public class EnemyMotherShipCtrl : ShottingController
{
    [SerializeField] protected SpawnEnemy spawnEnemy;
    public SpawnEnemy SpawnEnemy =>spawnEnemy;
    protected override void Reset()
    {
        LoadComponentEnable();
        LoadMeteoriteSO();
    }
    protected override void Awake()
    {
        LoadComponentEnable();
        LoadMeteoriteSO();
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
}
