using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : SpawnShootingAbleObject
{
    [SerializeField] protected int countLimitObject = 3;
    public int CountLimitObject=> countLimitObject; 
    public static SpawnEnemy instance;
    protected override void SetLimitObject()
    {
        this.sttLimitObject = countLimitObject;
    }
    protected override void SetNameManager()
    {
        this.namePosManager = "PosManager";
        this.nameMonterManager = "ManagerEnemy";
    }
    protected override void Reset()
    {
        SetLimitObject();
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
        ExecuteSpawnMonter();
    }
    //vấn đề gặp là khi sô lượng chưa giới hạn thì spawn ra enemy nhanh quá làm cho enemy vừa bị hạ chưa kịp vào poolobject lại
    //giải pháp là khi chưa đạt gới hạn số lượng thì sẽ delay spawn enemy 1s
    protected void ExecuteSpawnMonter()
    {
        if (DelaySpawn())
        {
            if (CheckCountChildMonter(countLimitObject))
            {
                SpawnRandom_Object();
            }
        }
    }
}
