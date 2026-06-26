using UnityEngine;

public class EnergyShieldAbility : LoadMonoBehaviour
{
    [SerializeField] protected bool isEnergyShield = true;
    [SerializeField] protected int shieldHp = 0;
    [SerializeField] protected BossFinalController bossFinalController;
    [SerializeField] protected EnergyShieldController energyShieldController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossFinalController();
        this.GetShieldHp();
        this.LoadEnergyShieldController();
    }
    protected virtual void LoadEnergyShieldController()
    {
        if (this.energyShieldController != null) return;
        this.energyShieldController = GetComponentInChildren<EnergyShieldController>();
        Debug.LogWarning("Load EnergyShieldController: " + transform.name);
    }
    protected virtual void LoadBossFinalController()
    {
        if (this.bossFinalController != null) return;
        this.bossFinalController = GetComponentInParent<BossFinalController>();
        Debug.LogWarning("Load BossFinalController: " + transform.name);
    }
    protected virtual void GetShieldHp()
    {
        if (this.bossFinalController == null) return;
        this.shieldHp = (int)(this.bossFinalController.ShootingSO.maxHP * 0.4);
    }
    private void Update()
    {
        if (!this.isEnergyShield) return;
        if (this.bossFinalController.DameReceiver.Hp > this.shieldHp) return;
        this.energyShieldController.gameObject.SetActive(true);
        this.isEnergyShield = false;
    }
}
