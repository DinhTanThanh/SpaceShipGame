using UnityEngine;

public class AbilityRecoveryKI : BaseAbility
{
    [SerializeField] protected AbilityWarpCtrl abilityWarpCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.SetDelayTimer();
        this.LoadAbilityWarpCtrl();
    }
    protected virtual void LoadAbilityWarpCtrl()
    {
        if (this.abilityWarpCtrl != null) return;
        this.abilityWarpCtrl=GetComponentInParent<AbilityWarpCtrl>();
        Debug.LogWarning("Load AbilityWarpCtrl: " + transform.name);
    }
    protected override void SetDelayTimer()
    {
        this.timer = 0f;
        this.timeDelay = 0.2f;
    }
    private void Update()
    {
        this.RecoveryKI();
    }
    protected virtual void RecoveryKI()
    {
        if (!this.Timing()) return;
        this.abilityWarpCtrl.PlayerController.DameReceiver.RecoveryKi(1);
    }
}
