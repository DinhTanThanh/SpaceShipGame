using UnityEngine;

public class EnemyVController : ShootingController
{
    [SerializeField] protected EnemyVDameReceive enemyVDameReceive;
    [SerializeField] protected GameObject bossSpace;
    public EnemyVDameReceive EnemyVDameReceive => enemyVDameReceive;
    private void Update()
    {
        if (this.bossSpace.activeSelf) return;
        this.transform.gameObject.SetActive(false);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySO();
        this.LoadEnemyVDameReceive();
        this.LoadBossSpace();
    }
    protected virtual void LoadBossSpace()
    {
        if (this.bossSpace != null) return;
        this.bossSpace = GameObject.Find("BossSpace");
        Debug.LogWarning("Load BossSpace: " + transform.name);
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
