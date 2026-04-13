using UnityEngine;

public class SpawnMeteorite : SpawnShootingAbleObject
{
    public static SpawnMeteorite instance;
    protected override void SetNameManager()
    {
        this.namePosManager = "PosManager";
        this.nameMonterManager = "ManagerMeteorite";
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
        SpawnMeteorite.instance= this;
        SetNameManager();
        base.Awake();

    }
    private void Update()
    {
        if (DelaySpawn()) Spawn();
    }
}
