using UnityEngine;

public class SupportShipController : ShootingController
{
    [SerializeField] protected SupportShooting supportShooting;
    public SupportShooting SupportShooting => supportShooting;
    [SerializeField] protected PlayerController playerController;
    public PlayerController PlayerController => playerController;
    [SerializeField] protected Transform player;
    public Transform Player => player;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadComponentEnable();
        this.LoadEnemySO();
        this.LoadObjectShooting();
        this.LoadPlayerController();
        this.LoadPlayer();
    }
    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("Player")?.transform;
        Debug.LogWarning("Load Player: " + transform.name);
    }
    protected virtual void LoadPlayerController()
    {
        if (this.playerController != null) return;
        this.playerController = FindFirstObjectByType<PlayerController>();
        Debug.LogWarning("Load PlayerController: " + transform.name);
    }
    protected virtual void LoadObjectShooting()
    {
        if (this.supportShooting != null) return;
        this.supportShooting = GetComponentInChildren<SupportShooting>();
        Debug.LogWarning("Load ObjectShooting: " + transform.name);
    }
    protected override void LoadComponentEnable()
    {
        LoadEnemySO();
    }
    public override void LoadEnemySO()
    {
        string nameMeteoriteSO = "Shooting/SupportShip/" + transform.name;
        this.shootingSO = Resources.Load<ShootingSO>(nameMeteoriteSO);
        if (this.shootingSO == null)
        {
            this.shootingSO = Resources.Load<ShootingSO>("Shotting/SupportShip/EnemyDefault");
        }
    }
}
