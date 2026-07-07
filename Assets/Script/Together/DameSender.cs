using UnityEngine;

public class DameSender : LoadMonoBehaviour
{
    public void SendDame(DameReceiver enemyDame,int dame)
    {
        ExecuteReceiver(enemyDame, dame);
    }
    public void ExecuteReceiver(DameReceiver dameReceiver,int dame)
    {
        dameReceiver.Receive(dame);
        if(dameReceiver.Hp<=0) dameReceiver.IsDead= true;
    }
}
