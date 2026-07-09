using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class MeteoriteDamereceiver : DameReceiver
{
    public PolygonCollider2D polygonCollider2D;
    public MeteoriteController MeteoriteCtrller;
    protected override void Reset()
    {
        this.MeteoriteCtrller=transform.parent.GetComponent<MeteoriteController>();
        this.polygonCollider2D=GetComponent<PolygonCollider2D>();
        this.polygonCollider2D.isTrigger = true;
        Reborn();
    }
    private void Update()
    {
        if (IsDead == true)
        {
            SoundFX.Instance.PlayOneShotSoundSmallExplosion();
            SpawnSmoke.instance.SetPosition(SpawnSmoke.instance.Smoke, this.transform.position, this.transform.rotation);
            this.transform.parent.gameObject.SetActive(false);
            this.Reborn();
            SpawnMeteorite.instance.GoBackList(this.transform.parent.gameObject);
            SpawnItems.instance.DropItem(this.MeteoriteCtrller.ShootingSO.dropItems,this.transform.position,Quaternion.Euler(0,0,0));
        }
    }
    public override void Reborn()
    {
        this.hp = this.MeteoriteCtrller.ShootingSO.maxHP;
        this.maxHp = this.MeteoriteCtrller.ShootingSO.maxHP;
        this.IsDead = false;
    }
}
