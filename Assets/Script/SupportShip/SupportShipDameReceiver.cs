using JetBrains.Annotations;
using UnityEngine;
public class SupportShipDameReceiver : DameReceiver
{
    public SupportShipController SupportShipController;
    protected override void LoadComponent()
    {
        SupportShipController = transform.parent.GetComponent<SupportShipController>();
        Reborn();
    }
    private void Update()
    {
        if (IsDead == true)
        {
            SpawnSmoke.instance.SetPosition(SpawnSmoke.instance.Smoke, transform.position, transform.rotation);
            transform.parent.gameObject.SetActive(false);
            //this.Reborn();
            SpawnItems.instance.DropItem(SupportShipController.ShootingSO.dropItems, transform.position, Quaternion.Euler(0, 0, 0));
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
