using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteorite : SpawnShootingAbleObject
{
    [SerializeField] protected int numberLimit;
    [SerializeField] protected EnemyMotherShipCtrl enemyMotherShipController;
    public int NumberLimit => numberLimit;
    public static SpawnMeteorite instance;
    protected override void SetNameManager()
    {
        this.namePosManager = "PosManager";
        this.nameMonterManager = "ManagerMeteorite";
    }
    protected override void Reset()
    {
        SetNameManager();
        this.SetNumberLimit(10);
        base.Reset();
    }
    protected override void LoadComponent()
    {
        this.posManager = GameObject.Find(namePosManager);
        this.monterManager = GameObject.Find(nameMonterManager);
        this.LoadEnemyMotherShipCtrl();
    }
    protected virtual void LoadEnemyMotherShipCtrl()
    {
        if (this.enemyMotherShipController != null) return;
        this.enemyMotherShipController = FindFirstObjectByType<EnemyMotherShipCtrl>();
        Debug.LogWarning("Load EnemyMotherShipCtrl: " + transform.name);
    }
    protected virtual void SetNumberLimit(int numberLimit)
    {
        this.numberLimit = numberLimit;
    }
    protected override void Awake()
    {
        SpawnMeteorite.instance= this;
        this.SetNameManager();
        this.SetNumberLimit(10);
        base.Awake();
    }
    private void Update()
    {
        if (this.enemyMotherShipController.DameReceiver.IsDead) return;
        this.TrySpawnMeteorite();
    }
    protected virtual void TrySpawnMeteorite()
    {
        if (!this.IsLimitReached()) return;
        if (!this.DelaySpawn()) return;
        Transform meteorite= SpawnRandom_Object();
    }
    protected virtual bool IsLimitReached()
    {
        int tempt = this.CountChildEnable();
        return tempt < this.numberLimit;
    }
}
