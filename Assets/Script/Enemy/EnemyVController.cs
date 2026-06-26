using UnityEngine;

public class EnemyVController : ShootingController
{
    [SerializeField] protected EnemyVDameReceive enemyVDameReceive;
    public EnemyVDameReceive EnemyVDameReceive => enemyVDameReceive;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySO();
        this.LoadEnemyVDameReceive();
    }
    protected virtual void LoadEnemyVDameReceive()
    {
        if (this.enemyVDameReceive != null) return;
        this.enemyVDameReceive = GetComponentInChildren<EnemyVDameReceive>();
        Debug.LogWarning("Load EnemyVDameReceive: " + transform.name);
    }
    public override void LoadEnemySO()
    {
        if (this.shootingSO != null) return;
        string path = "Shooting/Enemy/" + transform.name;
        this.shootingSO = Resources.Load<ShootingSO>(path);
        Debug.LogWarning("Load EnemyV2SO: " + transform.name);
    }
}
