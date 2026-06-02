using UnityEngine;

public class PlayerRecovery : LoadMonoBehaviour
{
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeDelay = 0.5f;
    [SerializeField] protected bool isDone = false;
    public bool IsDone => isDone;
    [SerializeField] protected int maxRecovery;
    public int MaxRecovery => maxRecovery;
    [SerializeField] protected int hpRecovery;
    public int HpRecovery => hpRecovery;
    [SerializeField] protected AbilityWarpCtrl abilityWarpCtrl;
    public AbilityWarpCtrl AbilityWarpCtrl => abilityWarpCtrl;
    [SerializeField] protected RecoverySkill recoverySkill;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAbilityWarpCtrl();
        this.LoadRecoverySkill();
    }
    protected virtual void LoadRecoverySkill()
    {
        if (this.recoverySkill != null) return;
        this.recoverySkill=FindFirstObjectByType<RecoverySkill>();
        Debug.LogWarning("Load RecoverySkill: " + transform.name);
    }
    protected virtual void LoadAbilityWarpCtrl()
    {
        if (this.abilityWarpCtrl != null) return;
        this.abilityWarpCtrl=GetComponentInParent<AbilityWarpCtrl>();
        Debug.LogWarning("Load AbilityWarpCtrl: " + transform.name);
    }
    public virtual void SetHpRecovery(int hpRecovery)
    {
        this.hpRecovery = hpRecovery;
    }
    public virtual void SetTimeDelay(float timeDelay)
    {
        this.timeDelay = timeDelay;
    }
    public virtual void SetMaxRecovery(int maxRecovery)
    {
        this.maxRecovery = maxRecovery;
    }
    public virtual void SetIsDone(bool isDone)
    {
        this.isDone = isDone;
    }
    private void Update()
    {
        if (!this.isDone) return;
        if (this.maxRecovery <= 0)
        {
            this.recoverySkill.SetIsOpen(false);
            this.transform.gameObject.SetActive(false);
            return;
        }
        if (!this.Timing()) return;
        int hp = this.abilityWarpCtrl.PlayerController.DameReceiver.Hp;
        int maxHp = this.abilityWarpCtrl.PlayerController.DameReceiver.MaxHp;
        int newHp = hp + this.hpRecovery;
        this.maxRecovery -= this.hpRecovery;
        if (newHp > maxHp)
        {
            int tempHP = maxHp - hp;
            if (tempHP <= 0) return;
            this.abilityWarpCtrl.PlayerController.DameReceiver.AddHP(tempHP);
            return;
        }
        this.abilityWarpCtrl.PlayerController.DameReceiver.AddHP(this.hpRecovery);
    }
    protected virtual bool Timing()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.timeDelay) return false;
        this.timer = 0f;
        return true;
    }
}
