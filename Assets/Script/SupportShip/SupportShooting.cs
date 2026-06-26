using UnityEngine;

public class SupportShooting : Shoot
{
    [SerializeField] protected Transform gatewayShotting;
    public Transform GatewayShotting => gatewayShotting;
    [SerializeField] protected SupportShipController supportShipController;
    public SupportShipController SupportShipController => supportShipController;
    private void Update()
    {
        TimeDelay();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSupportShipController();
        this.SetTimeDelay(this.supportShipController.PlayerController.Shooting.timeDelay * 1.2f);
        this.shooter = transform.parent.gameObject;
        this.LoadBullet();
        this.spawnBullett = GameObject.Find("SpawnBullet");
        this.gatewayShotting = transform.parent.Find("GatewayShotting");
    }
    protected virtual void LoadSupportShipController()
    {
        if (this.supportShipController != null) return;
        this.supportShipController = GetComponentInParent<SupportShipController>();
        Debug.LogWarning("Load SupportShipController: " + transform.name);
    }
    protected virtual void LoadBullet()
    {
        if (this.bullet != null) return;
        this.bullet = GameObject.Find("Bullet");
        Debug.LogWarning("Load Bullet: " + transform.name);
    }
    protected override void TimeDelay()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.timeDelay) return;
        this.timer = 0f;
        ExecuteSpawn();
    }
    protected override void LoadComponentEnable()
    {
        this.SetTimeDelay(this.supportShipController.PlayerController.Shooting.timeDelay * 1.2f);
    }
    protected override bool getControllerToSpawn()
    {
        //tự động bắn nên không cần code để auto true đẻ cho nó tự kiểm tra tự bắn
        return true;
    }
    protected override void ExecuteSpawn()
    {
        GameObject bulletObject = SpawnBullet.instance.SetPosition(this.bullet, this.gatewayShotting.position, this.shooter.transform.rotation);
        Vector3 pos = bulletObject.transform.position;

        bulletObject.transform.SetParent(spawnBullett.transform);
        pos.z = 1f;
        bulletObject.transform.position = pos;
    }
}
