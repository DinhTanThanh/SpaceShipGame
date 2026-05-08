using UnityEngine;

public abstract class ShottingController : LoadMonoBehaviour
{
    [SerializeField] protected ShottingSO shottingSO;
    public ShottingSO ShottingSO => shottingSO;
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
