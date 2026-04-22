using System;
using UnityEngine;

public class EnemyMoving : LoadMonoBehaviour
{
    public float speed;
    public int limitSpace = 7;
    [SerializeField] protected EnemySpawnController enemySpawnController;
    public EnemySpawnController EnemySpawnController => enemySpawnController;
    [SerializeField] protected Transform posEne;
    public Transform PosEne => posEne;
    [SerializeField] protected Transform target;
    public Transform Target => target;
    protected override void LoadComponentEnable()
    {
        Debug.Log(transform.parent.name);
        this.enemySpawnController = FindFirstObjectByType<EnemySpawnController>();
        this.target = ChangeObjectTarget();
        string nameObject ="Pos"+ReplaceNameGameObject(transform.parent.name);
        this.posEne = GameObject.Find(nameObject).transform;
    }
    protected override void LoadComponent()
    {
        LoadComponentEnable();
        SetSpeed();
    }

    private void Update()
    {
        Vector3 posEnemy = transform.parent.position;
        if (!CheckObjectActive(target))
        {
            this.target=ChangeObjectTarget();
        }
        if (target == null)
        {
            Debug.Log("Tất cả các Player dã chết");
            return;
        }
        Vector3 posTarget = target.position;

        float dis = Vector3.Distance(posEnemy, posTarget);
        if (dis < limitSpace)
        {
            Direct(posTarget);
            return;
        }
        Direct(posTarget);
        Moving(posEne.position);
    }
    protected void Moving(Vector3 target)
    {
        Vector3 positionShip = transform.parent.position;
        Vector3 newPosition = Vector3.Lerp(transform.parent.position, target, speed);
        newPosition.z = 0f;
        transform.parent.position = newPosition;
    }
    protected void Direct(Vector3 target)
    {
        Vector3 posShip = transform.parent.position;
        Vector3 newPos = target - posShip;
        float dir = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0, 0, dir - 90);
    }
    protected void SetSpeed()
    {
        this.speed = 0.002f;
    }
    protected string ReplaceNameGameObject(string nameGameObject)
    {
        return nameGameObject.Replace("(Clone)", "");
    }
    protected bool CheckObjectActive(Transform objectTarget)
    {
        return objectTarget.gameObject.activeSelf;
    }
    protected Transform ChangeObjectTarget()
    {
        if (enemySpawnController == null) return null;
        foreach(Transform childTarget in enemySpawnController.ManagerPlayer.transform)
        {
            if (!CheckObjectActive(childTarget)) continue;
            return childTarget;
        }
        return null;    
    }
}
