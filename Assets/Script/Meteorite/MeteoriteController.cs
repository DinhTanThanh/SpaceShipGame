using UnityEngine;

public class MeteoriteController : ShottingController
{
    [SerializeField] protected MeoteoriteDamereceiver meoteoriteDamereceiver;
    public MeoteoriteDamereceiver MeoteoriteDamereceiver => meoteoriteDamereceiver;
    protected override void Reset()
    {
        LoadEnemySO();
        LoadComponent();
    }
    protected override void Awake()
    {
        LoadEnemySO();
        LoadComponent();
    }
    protected override void LoadComponent()
    {
        this.meoteoriteDamereceiver=GetComponentInChildren<MeoteoriteDamereceiver>();
    }
    public override void LoadEnemySO()
    {
        if (shottingSO != null) return;
        string nameMeteoriteSO= "Shotting/Meteorite/" + transform.name;
        shottingSO=Resources.Load<ShottingSO>(nameMeteoriteSO);
    }
}
