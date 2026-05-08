using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonEnemy : BaseAbility
{
    [SerializeField] protected AbilitySummonController abilitySummonController;
    [SerializeField] protected GameObject enemy;
    [SerializeField] protected Transform gateWaySpawn;
    [SerializeField] protected List<GameObject> ListEnemySpawned = new List<GameObject>();
    [SerializeField] protected string stringNameEnemy;
    [SerializeField] protected int countLimitEnemy;
    [SerializeField] protected int numberEnemy=1;
    public AbilitySummonController AbilitySummonController => abilitySummonController;
    public GameObject Enemy => enemy;
    public Transform GateWaySpawn => gateWaySpawn;
    public string StringNameEnemy => stringNameEnemy;
    public int NumberEnemy=> numberEnemy;
    public int CountLimitEnemy => countLimitEnemy;
    private void Update()
    {
        SpawnEnemy();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.abilitySummonController=GetComponentInParent<AbilitySummonController>();
        LoadGameObjectEnemy();
        LoadGateWaySpawn();
        SetDelayTimer();
        SetNameEnemy();
        SetCountLimitEnemy();
    }
    protected virtual void LoadGameObjectEnemy()
    {
        Transform managerEnemy = abilitySummonController.EnemyMotherShipCtrl.ManagerEnemy?.transform;
        if (managerEnemy == null)
        {
            Debug.LogWarning("NOT LOADED MANAGER ENEMY");
            return;
        }
        this.enemy = managerEnemy.GetChild(0).gameObject;
    }
    protected override void SetDelayTimer()
    {
        this.timer = 0f;
        this.timeDelay = 4f;
    }
    protected virtual void SetNameEnemy()
    {
        this.stringNameEnemy = "Enemy_";
    }
    protected virtual void SetCountLimitEnemy()
    {
        this.countLimitEnemy = 3;
    }
    protected virtual void LoadGateWaySpawn()
    {
        this.gateWaySpawn = transform.GetChild(0);
    }
    protected virtual void SpawnEnemy()
    {
        if (!Timing()) return;
        if (CheckLimitEnemy())
        {
            EnableAndResetPos();
            return;
        }
        GameObject enemySpawned = Spawn.Instance.SpawnObject(this.enemy, this.gateWaySpawn.position, this.abilitySummonController.EnemyMotherShipCtrl.transform.rotation);
        enemySpawned.name = this.stringNameEnemy + numberEnemy;
        this.SpawnHpBarEnemy(enemySpawned);

        this.ListEnemySpawned.Add(enemySpawned);
        enemySpawned.transform.SetParent(this.abilitySummonController.EnemyMotherShipCtrl.ManagerEnemy.transform);
        enemySpawned.SetActive(true);
        
        this.numberEnemy++;
    }
    protected virtual void SpawnHpBarEnemy(GameObject enemy)
    {
        GameObject newHpBar = SpawnHpBar.Instance.SetPosition(SpawnHpBar.Instance.HpBar, enemy.transform.position, Quaternion.identity);
        HpBar hpBar = newHpBar.GetComponent<HpBar>();
        if (hpBar == null)
        {
            Debug.LogWarning("Null hpbar");
            return;
        }
        hpBar.SetEnemyController(enemy.GetComponent<EnemyController>());
        hpBar.FollowTarget.SetTarget(enemy.transform);
        newHpBar.SetActive(true);
    }
    protected virtual bool CheckLimitEnemy()
    {
        return this.ListEnemySpawned.Count>=this.countLimitEnemy;
    }
    protected virtual void EnableAndResetPos()
    {
        foreach(GameObject enemyEnable in this.ListEnemySpawned)
        {
            if (enemyEnable.activeSelf) continue;
            this.SpawnHpBarEnemy(enemyEnable);
            enemyEnable.SetActive(true);
            enemyEnable.transform.position = this.gateWaySpawn.position;
            enemyEnable.transform.rotation = this.abilitySummonController.EnemyMotherShipCtrl.transform.rotation;
            return;
        }
    }
}
