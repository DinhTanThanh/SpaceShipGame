using UnityEngine;

public class RecoverySkill : BaseSkill
{
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeDelay = 40f;
    [SerializeField] protected float maxPercentRecovery=0.5f;
    [SerializeField] protected float percentRecovery=0.1f;
    [SerializeField] protected bool isOpen=false;
    [SerializeField] protected PlayerController playerController;
    public PlayerController PlayerController => playerController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerController();
    }
    protected virtual void LoadPlayerController()
    {
        if (this.playerController != null) return;
        this.playerController=FindFirstObjectByType<PlayerController>();
        Debug.LogWarning("Load PlayerController: " + transform.name);
    }
    public virtual void SetIsOpen(bool isOpen)
    {
        this.isOpen = isOpen;
    }
    private void Update()
    {
        if (this.playerController.AbilityWarpCtrl.PlayerRecovery.IsDone)
        {
            this.timer += Time.deltaTime;
            if (this.timer <= this.timeDelay) return;
            this.timer = 0f;
            this.PlayerController.AbilityWarpCtrl.PlayerRecovery.SetIsDone(false);
        }
    }
    public override void ActiveSkill()
    {
        if (this.playerController.AbilityWarpCtrl.PlayerRecovery.IsDone) return;
        bool newStatus = !this.isOpen;
        int maxRecovery = (int)(this.playerController.DameReceiver.MaxHp * this.maxPercentRecovery);
        int hpRecovery = (int)(maxRecovery * this.percentRecovery);
        this.playerController.AbilityWarpCtrl.PlayerRecovery.gameObject.SetActive(newStatus);
        this.playerController.AbilityWarpCtrl.PlayerRecovery.SetMaxRecovery(maxRecovery);
        this.playerController.AbilityWarpCtrl.PlayerRecovery.SetHpRecovery(hpRecovery);
        this.playerController.AbilityWarpCtrl.PlayerRecovery.SetIsDone(true);
        this.isOpen = newStatus;
    }
}
