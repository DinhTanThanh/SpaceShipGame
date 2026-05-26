using UnityEngine;

public class AbilitySummonController : LoadMonoBehaviour
{
    [SerializeField] protected EnemyMotherShipCtrl enemyMotherShipCtrl;
    public EnemyMotherShipCtrl EnemyMotherShipCtrl => enemyMotherShipCtrl;
    [SerializeField] protected AbilitySummonEnemyExplosion abilitySummonEnemyExplosion;
    public AbilitySummonEnemyExplosion AbilitySummonEnemyExplosion => abilitySummonEnemyExplosion;
    protected override void LoadComponent()
    {
        this.LoadEnemyMotherShipCtrl();
        this.LoadAbilitySummonEnemyExplosion();
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
