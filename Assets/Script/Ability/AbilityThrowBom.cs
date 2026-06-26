using UnityEngine;

public class AbilityThrowBom : BaseAbility
{
    [SerializeField] protected AbilityThrowBomController abilityThrowBomController;
    public AbilityThrowBomController AbilityThrowBomController => abilityThrowBomController;
    protected override void SetDelayTimer()
    {
        this.timer = 0f;
        this.timeDelay = 3f;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.SetDelayTimer();
        this.LoadAbilityThrowBomController();
    }
    private void Update()
    {
        if (!this.Timing()) return;
        Transform pos = this.abilityThrowBomController.EnemyV2Controller.transform;
        GameObject Bom = SpawnBom.Instance.SetPosition(SpawnBom.Instance.ObjectBome, pos.position, pos.rotation);
        Bom.transform.SetParent(SpawnBom.Instance.transform);
    }
    protected virtual void LoadAbilityThrowBomController()
    {
        if (this.abilityThrowBomController != null) return;
        this.abilityThrowBomController = GetComponentInParent<AbilityThrowBomController>();
        Debug.LogWarning("Load AbilityThrowBomController: " + transform.name);
    }
}
