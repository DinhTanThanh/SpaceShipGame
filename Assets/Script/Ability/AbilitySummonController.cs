using UnityEngine;

public class AbilitySummonController : LoadMonoBehaviour
{
    [SerializeField] protected EnemyMotherShipCtrl enemyMotherShipCtrl;
    public EnemyMotherShipCtrl EnemyMotherShipCtrl => enemyMotherShipCtrl;
    protected override void LoadComponent()
    {
        this.enemyMotherShipCtrl=GetComponentInParent<EnemyMotherShipCtrl>();
    }
}
