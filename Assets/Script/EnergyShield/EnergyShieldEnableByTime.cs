using Unity.VisualScripting;
using UnityEngine;

public class EnergyShieldEnableByTime : EnableByTime
{
    [SerializeField] protected EnergyShieldController energyShieldController;
    private void Reset()
    {
        this.SetLimitTime();
        this.LoadEnergyShieldController();
    }
    protected virtual void LoadEnergyShieldController()
    {
        if (this.energyShieldController != null) return;
        this.energyShieldController = GetComponentInParent<EnergyShieldController>();
        Debug.LogWarning("Load EnergyShieldController: " + transform.name);
    }
    private void Update()
    {
        if (!this.CheckAchieveLimit()) return;
        this.energyShieldController.DameReceiver.IsDead = true;
    }
    public override void SetLimitTime()
    {
        this.TimeLimit = 15f;
    }
} 
