using UnityEngine;

public class EnergyShieldYellowController : ShootingController
{
    [SerializeField] protected AbilitySummonController abilitySummonController;
    public AbilitySummonController AbilitySummonController => abilitySummonController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySO();
        this.LoadAbilitySummonController(); 
    }
    protected virtual void LoadAbilitySummonController()
    {
        if (this.abilitySummonController != null) return;
        this.abilitySummonController = GetComponentInParent<AbilitySummonController>();
        Debug.LogWarning("Load AbilitySummonController: " + transform.name);
    }
    public override void LoadEnemySO()
    {
        if (this.shootingSO != null) return;
        string path = "Shooting/Enemy/" + transform.name;
        this.shootingSO = Resources.Load<ShootingSO>(path);
        Debug.LogWarning("Load EnemySO: " + transform.name);
    }
}
