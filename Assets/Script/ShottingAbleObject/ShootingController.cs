using UnityEngine;

public abstract class ShootingController : LoadMonoBehaviour
{
    [SerializeField] protected ShootingSO shootingSO;
    public ShootingSO ShootingSO => shootingSO;
    [SerializeField] protected DameReceiver damgeReceiver;
    public DameReceiver DameReceiver => damgeReceiver;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDameReceiver();
    }
    protected virtual void LoadDameReceiver()
    {
        this.damgeReceiver=GetComponentInChildren<DameReceiver>();
    }
    public abstract void LoadEnemySO();
}
