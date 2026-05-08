using Unity.VisualScripting;
using UnityEngine;
public class EnemyShooting : Shoot
{
    [SerializeField] protected GameObject managerBulletEnemy;
    public GameObject ManagerBulletEnemy=>managerBulletEnemy;
    [SerializeField] protected Transform tempt;
    public Transform Tempt => tempt;
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
        this.tempt = transform.parent.Find("temp");
    }
    protected override void LoadComponentEnable()
    {
        this.SetTimeDelay();
    }
    protected override bool getControllerToSpawn()
    {
        //tự động bắn nên không cần code để auto true đẻ cho nó tự kiểm tra tự bắn
        return true;
    }
    protected override void ExecuteSpawn()
    {
        GameObject bulletObject = SpawnBulletEnemy.instance.SetPosition(bullet,tempt.position /*shooter.transform.position*/,shooter.transform.rotation);
        Vector3 pos = bulletObject.transform.position;

        bulletObject.transform.SetParent(spawnBullett.transform);
        pos.z = 1f;
        bulletObject.transform.position = pos;
    }
    protected Quaternion Direct(Vector3 target,Vector3 objectNow)
    {
        Vector3 newPos = target - objectNow;
        float dir = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0, 0, dir - 100);
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
        this.timeDelay = 0.2f;
    }
    protected int RandomTimeSpawn()
    {
        return Random.Range(3, 7);
    }
}
