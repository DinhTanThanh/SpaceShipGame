using UnityEngine;

public class SpawnEnemyExplosion : PoolPrefab
{
    private static SpawnEnemyExplosion instance;
    public static SpawnEnemyExplosion Instance => instance;
    [SerializeField] protected GameObject enemyExplosion;
    public GameObject EnemyExplosion => enemyExplosion;
    protected override void Awake()
    {
        base.Awake();
        SpawnEnemyExplosion.instance = this;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyExplosion();
    }
    protected virtual void LoadEnemyExplosion()
    {
        if (this.enemyExplosion != null) return;
        this.enemyExplosion = GameObject.Find("EnemyExplosion");
    }
}
