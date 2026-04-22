using UnityEngine;

public class EnemyController : ShottingController
{
    [SerializeField] protected SpawnEnemy spawnEnemy;
    public SpawnEnemy SpawnEnemy =>spawnEnemy;
    protected override void Reset()
    {
        LoadComponentEnable();
        LoadMeteoriteSO();
    }
    protected override void LoadComponentEnable()
    {
        this.spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
    }
    public override void LoadMeteoriteSO()
    {
        if (ShottingSO != null) return;
        string nameMeteoriteSO = "Shotting/Enemy/" + transform.name;
        shottingSO = Resources.Load<ShottingSO>(nameMeteoriteSO);
    }
}
