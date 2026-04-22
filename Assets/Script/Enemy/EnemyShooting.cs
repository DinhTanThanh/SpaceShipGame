using UnityEngine;

public class EnemyShooting : Shoot
{
    [SerializeField] protected GameObject managerBulletEnemy;
    public GameObject ManagerBulletEnemy=>managerBulletEnemy;
    protected override void Awake()
    {
        LoadComponent();
    }
    protected override void Reset()
    {
        LoadComponent();
    }
    private void Update()
    {
        TimeDelay();
    }
    protected override void LoadComponent()
    {
        this.SetTimeDelay();
        this.shooter = GameObject.Find(transform.parent.name);
        this.bullet = this.getGameObject();
        this.spawnBullett = GameObject.Find("SpawnBulletEnemy");
    }
    protected override bool getControllerToSpawn()
    {
        //tự động bắn nên không cần code để auto true đẻ cho nó tự kiểm tra tự bắn
        return true;
    }
    protected override void ExecuteSpawn()
    {
        GameObject bulletObject = SpawnBulletEnemy.instance.SetPosition(bullet, shooter.transform.position, shooter.transform.rotation);
        Vector3 pos = bulletObject.transform.position;
        bulletObject.transform.SetParent(spawnBullett.transform);
        pos.z = 1f;
        bulletObject.transform.position = pos;
    }
    protected void LoadManager()
    {
        if (ManagerBulletEnemy != null) return;
        this.managerBulletEnemy = GameObject.Find("ManagerBulletEnemy");
    }
    protected GameObject getGameObject()
    {
        this.LoadManager();
        if (ManagerBulletEnemy == null) return null;
        if (ManagerBulletEnemy.transform.childCount <= 0) return null;
        return managerBulletEnemy.transform.GetChild(0).gameObject;
    }
    protected override void SetTimeDelay()
    {
        this.timeDelay = 1f;
    }
}
