using UnityEngine;

public class EnemyBirdController : ShootingController
{
    [SerializeField] protected EnemyBirdDameReceiver enemyBirdDameReceiver;
    public EnemyBirdDameReceiver EnemyBirdDameReceiver => enemyBirdDameReceiver;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySO();
        this.LoadEnemyBirdDameReceiver();
    }
    protected virtual void LoadEnemyBirdDameReceiver()
    {
        if (this.enemyBirdDameReceiver != null) return;
        this.enemyBirdDameReceiver = GetComponentInChildren<EnemyBirdDameReceiver>();
        Debug.LogWarning("Load EnemyBirdDameReceiver: " + transform.name);
    }
    public override void LoadEnemySO()
    {
        if (shootingSO != null) return;
        string nameMeteoriteSO = "Shooting/Enemy/" + transform.name;
        shootingSO = Resources.Load<ShootingSO>(nameMeteoriteSO);
    }
}
