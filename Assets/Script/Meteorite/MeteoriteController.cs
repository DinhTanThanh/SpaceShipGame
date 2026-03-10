using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    [SerializeField]private MeteoriteSO meteoriteSO;
    public MeteoriteSO MeteoriteSO { get { return meteoriteSO; } }
    [SerializeField] private MeoteoriteDamereceiver damereceiver;
    public MeoteoriteDamereceiver Damereceiver { get { return damereceiver; } }
    private void Reset()
    {
        LoadMeteoriteSO();
        LoadMeteoriteDameReceiver();
    }
    public void LoadMeteoriteSO()
    {
        if (MeteoriteSO != null) return;
        string nameMeteoriteSO= "Meteorite/" + transform.name;
        meteoriteSO=Resources.Load<MeteoriteSO>(nameMeteoriteSO);
    }
    public void LoadMeteoriteDameReceiver()
    {
        if(this.Damereceiver != null) return;
        damereceiver=transform.GetComponentInChildren<MeoteoriteDamereceiver>();
    }
}
