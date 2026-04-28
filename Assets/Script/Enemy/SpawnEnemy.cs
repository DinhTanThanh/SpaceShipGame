using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : PoolPrefab
{
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected bool isReady = false;
    [SerializeField] protected int countLimitObject = 3;
    [SerializeField] protected GameObject managerEnemy;
    [SerializeField] protected List<Transform> minions;
    [SerializeField] protected Transform motherShip_1;
    public Transform MotherShip_1 => motherShip_1;
    public GameObject ManagerEnemy=>managerEnemy;
    public int CountLimitObject=> countLimitObject; 
    public static SpawnEnemy instance;
    protected override void SetLimitObject()
    {
        this.sttLimitObject = countLimitObject;
    }
    protected override void LoadComponent()
    {
        this.managerEnemy = GameObject.Find("ManagerEnemy");
        this.motherShip_1 = GameObject.Find("MotherShip_1").transform;
    }
    protected override void Reset()
    {
        SetLimitObject();
        base.Reset();
    }
    protected override void Awake()
    {
        SpawnEnemy.instance = this;
        base.Awake();
    }
    private void Update()
    {
        Timing();
        ExecuteSpawnMonter();
        ClearnListMinionDead();
    }
    protected void ExecuteSpawnMonter()
    {
        if (!isReady) return;
        if(CountObjectSpawn()>=countLimitObject) return;
        float rot_z=motherShip_1.eulerAngles.z;
        GameObject Enemy= SetPosition(TakeObjectChild(), GetRandomGatewaySpawnEnemy(), Quaternion.Euler(0,0,rot_z));
        this.minions.Add(Enemy.transform);
        Vector3 newPosEnemy = Enemy.transform.position;
        newPosEnemy.z = 1f;
        Enemy.transform.position = newPosEnemy;
        Enemy.transform.SetParent(managerEnemy.transform);
        Active();
    }
    protected void Timing()
    {
        this.timer += Time.deltaTime;
        if (timer < delay) return;
        this.isReady= true; 
    }
    protected void Active()
    {
        this.isReady = false;
        this.timer= 0f; 
    }
    protected GameObject TakeObjectChild()
    {
        return managerEnemy.transform.GetChild(0).gameObject;
    }
    protected int CountObjectSpawn()
    {
        return this.minions.Count;
    }
    protected Vector3 GetRandomGatewaySpawnEnemy()
    {
        int index = Random.Range(0, transform.childCount);
        return transform.GetChild(index).position;
    }
    protected void ClearnListMinionDead()
    {
        foreach(Transform minion in this.minions)
        {
            if (minion.gameObject.activeSelf == false)
            {
                this.minions.Remove(minion);
                return;
            }
        }
    }
}
