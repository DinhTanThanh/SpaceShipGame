using JetBrains.Annotations;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemyBird : PoolPrefab
{
    [Header("Spawn Enemy Bird")]
    private static SpawnEnemyBird instance;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeDelay = 3f;
    [SerializeField] protected int indexPosCurrent=0;
    [SerializeField] protected GameObject enemyBird;
    [SerializeField] protected Transform posManager;
    [SerializeField] protected GameObject spawnHpBar;
    [SerializeField] protected List<Transform> listPosition;
    [SerializeField] protected List<GameObject> listSpawnEnemy;
    [SerializeField] protected BossSpaceController bossSpaceController;
    public static SpawnEnemyBird Instance => instance;

    public List<Transform> ListPosition=> listPosition;
    public GameObject EnemyBird => enemyBird;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyBird();
        this.LoadPosManager();
        this.GetListPosition();
        this.LoadSpawnHpBar();
        this.LoadBossSpaceController();
    }
    protected virtual void LoadBossSpaceController()
    {
        if (this.bossSpaceController != null) return;
        this.bossSpaceController=FindFirstObjectByType<BossSpaceController>();
        Debug.LogWarning("Load BossSpaceController: " + transform.name);
    }
    protected virtual void LoadSpawnHpBar()
    {
        if (this.spawnHpBar != null) return;
        this.spawnHpBar = GameObject.Find("SpawnHpBar");
        Debug.LogWarning("Load SpawnHpBar: " + transform.name);
    }
    protected virtual void GetListPosition()
    {
        if (this.posManager == null) return;
        if (this.listPosition.Count > 0) return;
        foreach (Transform child in this.posManager)
        {
            this.listPosition.Add(child);
        }
    }
    protected virtual void LoadPosManager()
    {
        if (this.posManager != null) return;
        this.posManager = GameObject.Find("PosManager")?.transform;
        Debug.LogWarning("Load PosManager: " + transform.name);
    }
    protected virtual void LoadEnemyBird()
    {
        if (this.enemyBird != null) return;
        this.enemyBird = GameObject.Find("EnemyBird");
        Debug.LogWarning("Load EnemyBird: " + transform.name);
    }
    protected override void Awake()
    {
        base.Awake();
        SpawnEnemyBird.instance= this;
    }
    private void FixedUpdate()
    {
        if (!this.bossSpaceController.transform.gameObject.activeSelf) return;
        if (this.bossSpaceController.DameReceiver.IsDead) return;
        if (this.CountEnemyBirdInList() > 4) return;
        if (!this.Timing()) return;
        Transform tranformPos = this.GetPosition();
        float valueRandom = Random.Range(-5, 6);
        Vector3 randomPos = new Vector3(0, 0, valueRandom);
        GameObject enemyBird = SpawnEnemyBird.Instance.SetPosition(this.enemyBird, tranformPos.position + randomPos, tranformPos.rotation);
        this.listSpawnEnemy.Add(enemyBird);
        enemyBird.transform.SetParent(transform);
        GameObject objHpBar = SpawnHpBar.Instance.SetPosition(SpawnHpBar.Instance.HpBar, enemyBird.transform.position, Quaternion.identity);
        objHpBar.transform.SetParent(this.spawnHpBar.transform);
        HpBar hpBar = objHpBar.GetComponent<HpBar>();
        if (hpBar == null) return;
        hpBar.transform.localScale = new Vector3(1f, 2f, 1f);
        EnemyBirdController enemyBirdController = enemyBird.GetComponent<EnemyBirdController>();
        if (enemyBirdController == null) return;
        enemyBirdController.DameReceiver.Reborn();
        hpBar.SetShootingController(enemyBirdController);
        hpBar.FollowTarget.SetTarget(enemyBird.transform);
    }
    protected virtual int CountEnemyBirdInList()
    {
        int count = 0;
        for(int i=0;i<this.listSpawnEnemy.Count;i++)
        {
            if (!this.listSpawnEnemy[i].activeSelf)
            {
                this.listSpawnEnemy.RemoveAt(i);
                continue;
            }
            count++;
        }
        return count;
    }
    protected virtual int RandomIndexPosition()
    {
        return Random.Range(0, this.listPosition.Count);
    }
    protected virtual Transform GetPosition()
    {
        int index = this.RandomIndexPosition();
        while (index == this.indexPosCurrent)
        {
            index = this.RandomIndexPosition();
        }
        this.indexPosCurrent = index;
        return this.listPosition[this.indexPosCurrent];
    }
    protected virtual bool Timing()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.timeDelay) return false;
        this.timer = 0f;
        return true;
    }
}
