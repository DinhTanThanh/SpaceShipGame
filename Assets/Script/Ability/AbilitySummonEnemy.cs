using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonEnemy : BaseAbility
{
    [Header("Ability Summon Enemy")]
    [SerializeField] protected int countLimitEnemy;
    [SerializeField] protected int numberEnemy = 1;
    [SerializeField] protected string stringNameEnemy;
    [SerializeField] protected AbilitySummonController abilitySummonController;
    [SerializeField] protected GameObject enemy;
    [SerializeField] protected Transform gateWaySpawn;
    [SerializeField] protected List<GameObject> ListEnemySpawned = new List<GameObject>();

    public int NumberEnemy => numberEnemy;
    public int CountLimitEnemy => countLimitEnemy;
    public string StringNameEnemy => stringNameEnemy;
    public AbilitySummonController AbilitySummonController => abilitySummonController;
    public GameObject Enemy => enemy;
    public Transform GateWaySpawn => gateWaySpawn;
  
    private void Update()
    {
        this.SpawnEnemy();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAbilitySummonController();
        this.LoadGameObjectEnemy();
        this.LoadGateWaySpawn();
        this.SetDelayTimer();
        this.SetNameEnemy();
        this.SetCountLimitEnemy();
    }
    protected virtual void LoadAbilitySummonController()
    {
        if (this.abilitySummonController != null) return;
        this.abilitySummonController = GetComponentInParent<AbilitySummonController>();
        Debug.LogWarning("Load AbilitySummonController: " + transform.name);
    }
    protected virtual void LoadGameObjectEnemy()
    {
        Transform managerEnemy = abilitySummonController.EnemyMotherShipCtrl.ManagerEnemy?.transform;
        if (managerEnemy == null)
        {
            Debug.LogWarning("NOT LOADED MANAGER ENEMY");
            return;
        }
        this.enemy = managerEnemy.Find("Enemy_1")?.gameObject;
        Debug.LogWarning("Load Enemy: " + transform.name);
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
        this.countLimitEnemy = 7;
    }
    protected virtual void LoadGateWaySpawn()
    {
        this.gateWaySpawn = transform.GetChild(0);
    }
    protected virtual void SpawnEnemy()
    {
        if (this.numberEnemy >= this.countLimitEnemy) return;
        if (!this.Timing()) return;
        if (this.CheckLimitEnemy())
        {
            this.EnableAndResetPos();
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
        hpBar.SetShootingController(enemy.GetComponent<EnemyController>());
        hpBar.FollowTarget.SetTarget(enemy.transform);
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
            this.numberEnemy++;
            return;
        }
    }
    public virtual int GetCountEnemyInList()
    {
        return this.numberEnemy;
    }
    public virtual List<GameObject> GetListEnemy()
    {
        return this.ListEnemySpawned;
    }
    public virtual void ResetNumberEnemy()
    {
        this.numberEnemy = 1;
    }
}
