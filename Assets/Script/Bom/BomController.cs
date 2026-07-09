using UnityEngine;

public class BomController : LoadMonoBehaviour
{
    [SerializeField] protected BomDameReceiver bomDameReceiver;
    public BomDameReceiver BomDameReceiver => bomDameReceiver;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBomDameReceiver();
    }
    protected virtual void LoadBomDameReceiver()
    {
        if (this.bomDameReceiver != null) return;
        this.bomDameReceiver = GetComponentInChildren<BomDameReceiver>();
        Debug.LogWarning("Load BomDameReceiver: " + transform.name);
    }
}
