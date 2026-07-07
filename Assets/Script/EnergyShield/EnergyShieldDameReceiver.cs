using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]
public class EnergyShieldDameReceiver : DameReceiver
{
    [SerializeField] protected PolygonCollider2D polygonCollider2D;
    [SerializeField] protected EnergyShieldYellowController energyShieldYellowController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPolygonCollider2D();
        this.LoadEnergyShieldYellowController();
        this.Reborn();
    }
    private void Update()
    {
        if (!this.isDead) return;
        this.transform.parent.gameObject.SetActive(false);
    }
    protected virtual void LoadEnergyShieldYellowController()
    {
        if (this.energyShieldYellowController != null) return;
        this.energyShieldYellowController = GetComponentInParent<EnergyShieldYellowController>();
        Debug.LogWarning("Load EnergyShieldYellowController: " + transform.name);
    }
    protected virtual void LoadPolygonCollider2D()
    {
        if (this.polygonCollider2D != null) return;
        this.polygonCollider2D = GetComponent<PolygonCollider2D>();
        this.polygonCollider2D.isTrigger = true;
        Debug.LogWarning("Load PolygonCollider2D: " + transform.name);
    }
    public override void Reborn()
    {
        if (this.energyShieldYellowController == null) return;
        this.hp = this.energyShieldYellowController.ShootingSO.maxHP;
        this.maxHp = this.energyShieldYellowController.ShootingSO.maxHP;
        this.isDead = false;
    }
}
