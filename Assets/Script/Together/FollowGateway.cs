using UnityEngine;

public class FollowGateway : FollowObject
{
    [SerializeField] protected EnemyExplosionController enemyExplosionController;
    public EnemyExplosionController EnemyExplosionController => enemyExplosionController;
    protected override void Reset()
    {
        base.Reset();
        this.SetSpeed(0.7f);
    }
    public override void SetNameObject()
    {
        this.nameObject = "GateWay";
    }
    protected override void LoadComponent()
    {
        this.LoadEnemyExplosionController();
        base.LoadComponent();
    }
    protected virtual void LoadEnemyExplosionController()
    {
        if (this.enemyExplosionController!=null) return;
        this.enemyExplosionController=GetComponentInParent<EnemyExplosionController>();
        Debug.LogWarning("Load EnemyExplosionController: " + transform.name);
    }
    protected override void LoadObjectPrefab()
    {
        if (this.objectTarget != null) return;
        this.objectTarget = this.enemyExplosionController.EnemyMotherShipCtrl.AbilitySummonController.AbilitySummonEnemyExplosion.transform.GetChild(0).gameObject;
        Debug.LogWarning("Load ObjectPrefab: " + transform.name);
    }
}
