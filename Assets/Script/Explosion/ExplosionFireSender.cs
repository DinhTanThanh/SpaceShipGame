using UnityEngine;

public class ExplosionFireSender : DameSender
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DameReceiver dameReceiver=collision.transform.parent?.GetComponentInChildren<DameReceiver>();
        if (dameReceiver == null) return;
        Debug.Log(dameReceiver.transform.name);
        SendDame(dameReceiver, (int)(dameReceiver.MaxHp * 0.3f));
    }
}
