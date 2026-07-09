using Unity.VisualScripting;
using UnityEngine;
public class EnemyShooting : Shoot
{
    [SerializeField] protected float disLimit;
    public float DisLimit => disLimit;
    [SerializeField] protected GameObject managerBulletEnemy;
    public GameObject ManagerBulletEnemy=>managerBulletEnemy;
    [SerializeField] protected Transform gatewayShotting;
    public Transform GatewayShotting => gatewayShotting;
    [SerializeField] protected Transform objTarget;
    public Transform ObjTarget => objTarget;
    protected override void Awake()
    {
        LoadComponent();
    }
    protected override void Reset()
    {
        LoadComponent();
        this.SetDisLimit(18);
    }
    private void Update()
    {
        TimeDelay();
    }
    protected override void LoadComponent()
    {
        this.SetTimeDelay(0.8f);
        this.LoadObjectTarget();
        this.shooter = GameObject.Find(transform.parent.name);
        this.bullet = this.getGameObject();
        this.spawnBullett = GameObject.Find("SpawnBulletEnemy");
        this.gatewayShotting = transform.parent.Find("GatewayShotting");
    }
    protected override void TimeDelay()
    {
        timer += Time.deltaTime;
        if (timer < timeDelay) return;
        timer = 0f;
        if (!this.CheckLimitWithTarget()) return;
        ExecuteSpawn();
    }
    protected override void LoadComponentEnable()
    {
        this.SetTimeDelay(0.8f);
    }
    protected override bool getControllerToSpawn()
    {
        //tự động bắn nên không cần code để auto true đẻ cho nó tự kiểm tra tự bắn
        return true;
    }
    protected override void ExecuteSpawn()
    {
        SoundFX.Instance.PlayOneShotSoundShoot();
        GameObject bulletObject = SpawnBulletEnemy.instance.SetPosition(this.bullet, this.gatewayShotting.position,this.shooter.transform.rotation);
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
    protected int RandomTimeSpawn()
    {
        return Random.Range(3, 7);
    }

    protected virtual void LoadObjectTarget()
    {
        if (this.objTarget != null) return;
        this.objTarget = GameObject.Find("Player")?.transform;
        Debug.LogWarning("Load ObjectTarget: " + transform.name);
    }
    protected virtual bool CheckLimitWithTarget()
    {
        float dis = Vector3.Distance(this.objTarget.position, transform.parent.position);
        if (dis < this.disLimit) return true;
        return false;
    }
    protected virtual void SetDisLimit(float disLimit)
    {
        this.disLimit = disLimit;
    }
}
