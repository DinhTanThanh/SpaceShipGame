using UnityEngine;

public class SupportShipAppearWithoutShooting : SupportShipControllerAbstract,IObjAppearObserver
{
    [Header("SupportShip Appear WithoutShoot")]
    [SerializeField] protected SupportShipAprearingBigger supportShipAprearingBigger;
    protected SupportShipAprearingBigger SupportShipAprearingBigger => supportShipAprearingBigger;
    protected override void OnEnable()
    {
        this.RegisterAppearEvent();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.supportShipAprearingBigger = GetComponent<SupportShipAprearingBigger>();
    }
    protected virtual void RegisterAppearEvent()
    {
        this.supportShipAprearingBigger.ObserverAdd(this);
    }

    public void OnAppearStart()
    {
        this.supportShipController.SupportShooting.gameObject.SetActive(false);
    }

    public void OnAppearFinish()
    {
        this.supportShipController.SupportShooting.gameObject.SetActive(true);
    }
}
