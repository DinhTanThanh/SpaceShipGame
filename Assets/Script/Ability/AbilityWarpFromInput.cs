using UnityEngine;

public class AbilityWarpFromInput : AbilityWarp
{
    [SerializeField] protected AbilityWarpCtrl abilityWarpCtrl;
    public AbilityWarpCtrl AbilityWarpCtrl => abilityWarpCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.abilityWarpCtrl = GetComponentInParent<AbilityWarpCtrl>();
        this.teleport = this.abilityWarpCtrl.AnimatorTeleport;
    }
    protected override void Update()
    {
        base.Update();
        this.keyDirection = InputManager.Instance.Direction;
    }
}
