using Unity.Mathematics;
using UnityEngine;

public class AbilitySummonEnemyExplosion : BaseAbility
{
    [SerializeField] protected Transform gateway;
    [SerializeField] protected AbilitySummonController abilitySummonController;
    protected override void Reset()
    {
        base.Reset();
        this.SetDelayTimer();
    }
    private void Update()
    {
        this.SummonEnemyExplosion();
    }
    protected override void SetDelayTimer()
    {
        this.timeDelay = 10f;
        this.timer = 0f;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadGateWay();
        this.LoadAbilitySummonController();
    }
    protected virtual void LoadAbilitySummonController()
    {
        if (this.abilitySummonController != null) return;
        this.abilitySummonController = GetComponentInParent<AbilitySummonController>();
        Debug.LogWarning("Load AbilitySummonController: " + transform.name);
    }
    protected virtual void LoadGateWay()
    {
        if (this.gateway != null) return;
        this.gateway = transform.Find("GateWay");
        Debug.LogWarning("Load GateWay: " + transform.name);
    }
    protected virtual void SummonEnemyExplosion()
    {
        if (this.abilitySummonController.EnemyMotherShipCtrl.PlayerController.DameReceiver.IsDead) return;
        if (!this.Timing()) return;
        quaternion rot = this.abilitySummonController.EnemyMotherShipCtrl.transform.rotation;
        GameObject EnemyExplosion = SpawnEnemyExplosion.Instance.SetPosition(SpawnEnemyExplosion.Instance.EnemyExplosion,this.gateway.position , rot);
    }
}
