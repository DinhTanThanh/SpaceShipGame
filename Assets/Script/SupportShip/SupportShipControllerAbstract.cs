using UnityEngine;

public class SupportShipControllerAbstract : LoadMonoBehaviour
{
    [SerializeField] protected SupportShipController supportShipController;
    public SupportShipController SupportShipController => supportShipController;
    protected override void LoadComponent()
    {
        if (supportShipController != null) return;
        this.supportShipController = GetComponentInParent<SupportShipController>();
    }
}
