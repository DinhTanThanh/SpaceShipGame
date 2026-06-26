using UnityEngine;

public class EnergyShieldController : ShootingController
{
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySO();
    }
    public override void LoadEnemySO()
    {
        if (this.shootingSO != null) return;
        string path = "Shooting/Enemy/" + transform.name;
        this.shootingSO = Resources.Load<ShootingSO>(path);
        Debug.LogWarning("Load EnemySO: " + transform.name);
    }
}
