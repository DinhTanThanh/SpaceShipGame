using UnityEngine;

public class DameSender : LoadMonoBehaviour
{
    public void SendDame(DameReceiver enemyDame)
    {
        ExecuteReceiver(enemyDame, 1);
    }
    public void ExecuteReceiver(DameReceiver dameReceiver,int dame)
    {
        dameReceiver.Receiver(dame);
        if(dameReceiver.Hp<=0) dameReceiver.IsDead= true;
    }
}
