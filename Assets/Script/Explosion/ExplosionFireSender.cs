using UnityEngine;

public class ExplosionFireSender : DameSender
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DameReceiver dameReceiver=collision.transform.parent?.parent?.GetComponentInChildren<DameReceiver>();
        if (dameReceiver == null) return;
        Debug.Log("Khong phai NULLLLLLLLLLLL");
        dameReceiver.Receive((int)(dameReceiver.MaxHp*0.2f));
    }
}
