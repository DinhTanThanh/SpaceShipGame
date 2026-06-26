using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]
public class EnergyShieldDameReceiver : DameReceiver
{
    [SerializeField] protected PolygonCollider2D polygonCollider2D;
    [SerializeField] protected EnergyShieldController energyShieldController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPolygonCollider2D();
        this.LoadEnergyShieldController();
        this.Reborn();
    }
    private void Update()
    {
        if (!this.isDead) return;
        this.transform.parent.gameObject.SetActive(false);
    }
    protected virtual void LoadEnergyShieldController()
    {
        if (this.energyShieldController != null) return;
        this.energyShieldController = GetComponentInParent<EnergyShieldController>();
        Debug.LogWarning("Load EnergyShieldController: " + transform.name);
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
        if (this.energyShieldController == null) return;
        this.hp = this.energyShieldController.ShootingSO.maxHP;
        this.maxHp = this.energyShieldController.ShootingSO.maxHP;
        this.isDead = false;
    }
}
