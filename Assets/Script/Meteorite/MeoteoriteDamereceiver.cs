using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class MeoteoriteDamereceiver : DameReceiver
{
    public PolygonCollider2D polygonCollider2D;
    public MeteoriteController MeteoriteCtrller;
    private void Reset()
    {
        MeteoriteCtrller=transform.parent.GetComponent<MeteoriteController>();
        polygonCollider2D=GetComponent<PolygonCollider2D>();
        polygonCollider2D.isTrigger = true;
        Reborn();
    }
    private void Update()
    {
        if (IsDead == true)
        {
            //Debug.Log("Object đã chết");
            SpawnSmoke.instance.SetPosition(SpawnSmoke.instance.Smoke, transform.position, transform.rotation);
            transform.parent.gameObject.SetActive(false);
            Reborn();
            SpawnMeteorite.instance.GoBackList(transform.parent.gameObject);
            SpawnItems.instance.SpawnItem(MeteoriteCtrller.ShottingSO.dropItems,transform.position,Quaternion.Euler(0,0,0));
        }
    }
    public override void Reborn()
    {
        HP = MeteoriteCtrller.ShottingSO.maxHP;
        this.IsDead = false;
    }
}
