using UnityEngine;

public abstract class ShootingController : LoadMonoBehaviour
{
    [SerializeField] protected ShootingSO shootingSO;
    [SerializeField] protected DameReceiver damgeReceiver;
    [SerializeField] protected PlayerController playerController;
    public ShootingSO ShootingSO => shootingSO;
    public DameReceiver DameReceiver => damgeReceiver;
    public PlayerController PlayerController => playerController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDameReceiver();
        this.LoadplayerController();
    }
    protected virtual void LoadplayerController()
    {
        if (this.playerController != null) return;
        this.playerController = FindFirstObjectByType<PlayerController>();
        Debug.LogWarning("Load PlayerController: " + transform.name);
    }
    protected virtual void LoadDameReceiver()
    {
        this.damgeReceiver=GetComponentInChildren<DameReceiver>();
    }
    public abstract void LoadEnemySO();
}
