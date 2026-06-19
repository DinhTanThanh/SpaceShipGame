using UnityEngine;

public class DameSender : LoadMonoBehaviour
{
    public void SendDame(DameReceiver enemyDame)
    {
        ExecuteReceiver(enemyDame, 1);
    }
    public void ExecuteReceiver(DameReceiver dameReceiver,int dame)
    {
        dameReceiver.Receive(dame);
        if(dameReceiver.Hp<=0) dameReceiver.IsDead= true;
    }
}
