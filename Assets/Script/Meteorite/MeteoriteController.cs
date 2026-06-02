using UnityEngine;

public class MeteoriteController : ShootingController
{
    [SerializeField] protected MeteoriteDamereceiver meoteoriteDamereceiver;
    public MeteoriteDamereceiver MeoteoriteDamereceiver => meoteoriteDamereceiver;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySO();
        this.meoteoriteDamereceiver=GetComponentInChildren<MeteoriteDamereceiver>();
    }
    public override void LoadEnemySO()
    {
        if (shootingSO != null) return;
        string nameMeteoriteSO= "Shooting/Meteorite/" + transform.name;
        shootingSO=Resources.Load<ShootingSO>(nameMeteoriteSO);
    }
}
