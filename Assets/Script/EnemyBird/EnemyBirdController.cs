using UnityEngine;

public class EnemyBirdController : ShootingController
{
    [SerializeField] protected EnemyBirdDameReceiver enemyBirdDameReceiver;
    [SerializeField] protected GameObject bossSpace;
    public EnemyBirdDameReceiver EnemyBirdDameReceiver => enemyBirdDameReceiver;
    private void Update()
    {
        if (this.bossSpace.activeSelf) return;
        this.damgeReceiver.IsDead = true;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySO();
        this.LoadEnemyBirdDameReceiver();
        this.LoadBossSpace();
    }
    protected virtual void LoadBossSpace()
    {
        if (this.bossSpace != null) return;
        this.bossSpace = GameObject.Find("BossSpace");
        Debug.LogWarning("Load BossSpace: " + transform.name);
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
