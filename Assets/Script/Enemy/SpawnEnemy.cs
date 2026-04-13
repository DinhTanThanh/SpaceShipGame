using UnityEngine;

public class SpawnEnemy : SpawnShootingAbleObject
{
    public static SpawnEnemy instance;
    protected override void SetNameManager()
    {
        this.namePosManager = "PosManager";
        this.nameMonterManager = "ManagerEnemy";
    }
    protected override void Reset()
    {
        SetNameManager();
        base.Reset();
    }
    protected override void LoadComponent()
    {
        this.posManager = GameObject.Find(namePosManager);
        this.monterManager = GameObject.Find(nameMonterManager);
    }
    protected override void Awake()
    {
        SpawnEnemy.instance = this;
        SetNameManager();
        base.Awake();

    }
    private void Update()
    {
        if (DelaySpawn()) Spawn();
    }
}
