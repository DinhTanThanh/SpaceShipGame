using JetBrains.Annotations;
using UnityEngine;
public class SupportShipDameReceiver : DameReceiver
{
    [SerializeField] protected SummonSupportShipSkill summonSupportShipSkill;
    public SupportShipController SupportShipController;
    protected override void LoadComponent()
    {
        SupportShipController = transform.parent.GetComponent<SupportShipController>();
        this.LoadSummonSupportShipSkill();
        Reborn();
    }
    protected virtual void LoadSummonSupportShipSkill()
    {
        if (this.summonSupportShipSkill != null) return;
        this.summonSupportShipSkill = FindFirstObjectByType<SummonSupportShipSkill>();
        Debug.LogWarning("Load SummonSupportShipSkill: " + transform.name);
    }
    private void Update()
    {
        if (this.IsDead == true)
        {
            SpawnSmoke.instance.SetPosition(SpawnSmoke.instance.Smoke, transform.position, transform.rotation);
            transform.parent.gameObject.SetActive(false);
            this.Reborn();
        }
    }
    public override void Reborn()
    {
        int hpStart =(int)(this.SupportShipController.PlayerController.DameReceiver.MaxHp * 0.8);
        this.hp = hpStart;
        this.maxHp = hpStart;
        this.IsDead = false;
    }
}
