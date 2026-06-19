using JetBrains.Annotations;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemyBird : PoolPrefab
{
    private static SpawnEnemyBird instance;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeDelay = 1f;
    [SerializeField] protected int indexPosCurrent=0;
    [SerializeField] protected GameObject enemyBird;
    [SerializeField] protected Transform posManager;
    [SerializeField] protected List<Transform> listPosition;
    public static SpawnEnemyBird Instance => instance;

    public List<Transform> ListPosition=> listPosition;
    public GameObject EnemyBird => enemyBird;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyBird();
        this.LoadPosManager();
        this.GetListPosition();
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
    private void Update()
    {
        if (!this.Timing()) return;
        Transform tranformPos = this.GetPosition();
        float valueRandom = Random.Range(-5, 6);
        Vector3 randomPos = new Vector3(0, 0, valueRandom);
        GameObject enemyBird=SpawnEnemyBird.Instance.SetPosition(this.enemyBird, tranformPos.position+randomPos, tranformPos.rotation);
        enemyBird.transform.SetParent(transform);
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
        this.timer += Time.deltaTime;
        if (this.timer < this.timeDelay) return false;
        this.timer = 0f;
        return true;
    }
}
