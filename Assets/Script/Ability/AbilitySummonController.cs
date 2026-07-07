using UnityEngine;

public class AbilitySummonController : LoadMonoBehaviour
{
    [SerializeField] protected EnemyMotherShipCtrl enemyMotherShipCtrl;
    [SerializeField] protected AbilitySummonEnemyExplosion abilitySummonEnemyExplosion;
    [SerializeField] protected AbilitySummonEnemy abilitySummonEnemy;
    [SerializeField] protected EnergyShieldYellowController energyShieldYellowController;

    public EnemyMotherShipCtrl EnemyMotherShipCtrl => enemyMotherShipCtrl;
    public AbilitySummonEnemyExplosion AbilitySummonEnemyExplosion => abilitySummonEnemyExplosion;
    public AbilitySummonEnemy AbilitySummonEnemy => abilitySummonEnemy;
    public EnergyShieldYellowController EnergyShieldYellowController => energyShieldYellowController;
    protected override void LoadComponent()
    {
        this.LoadEnemyMotherShipCtrl();
        this.LoadAbilitySummonEnemyExplosion();
        this.LoadAbilitySummonEnemy();
        this.LoadEnergyShieldYellowController();
    }
    protected virtual void LoadEnergyShieldYellowController()
    {
        if (this.energyShieldYellowController != null) return;
        this.energyShieldYellowController = GetComponentInChildren<EnergyShieldYellowController>();
        Debug.LogWarning("Load EnergyShieldYellowController: " + transform.name);
    }
    protected virtual void LoadAbilitySummonEnemy()
    {
        if (this.abilitySummonEnemy != null) return;
        this.abilitySummonEnemy = GetComponentInChildren<AbilitySummonEnemy>();
        Debug.LogWarning("Load AbilitySummonEnemy: " + transform.name);
    }
    protected virtual void LoadEnemyMotherShipCtrl()
    {
        if (this.enemyMotherShipCtrl != null) return;
        this.enemyMotherShipCtrl = GetComponentInParent<EnemyMotherShipCtrl>();
        Debug.LogWarning("Load EnemyMotherShipCtrl: " + transform.name);
    }
    protected virtual void LoadAbilitySummonEnemyExplosion()
    {
        if (this.abilitySummonEnemyExplosion != null) return;
        this.abilitySummonEnemyExplosion = GetComponentInChildren<AbilitySummonEnemyExplosion>();
        Debug.LogWarning("Load AbilitySummonEnemyExplosion: " + transform.name);
    }
}
