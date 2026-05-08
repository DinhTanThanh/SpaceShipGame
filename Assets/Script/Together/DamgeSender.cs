using UnityEngine;

public class DamgeSender : MonoBehaviour
{
    public void SendDame(MeoteoriteDamereceiver prefabObject)
    {
        ExecuteReceiver(prefabObject, 1);
    }
    public void SendDame(EnemyDameReceiver enemyDame)
    {
        ExecuteReceiver(enemyDame, 1);
    }
    public void SendDame(EnemyMotherDameReceiver enemyDame)
    {
        ExecuteReceiver(enemyDame, 1);
    }
    public void ExecuteReceiver(DameReceiver dameReceiver,int dame)
    {
        dameReceiver.Receiver(dame);
        if(dameReceiver.Hp<=0) dameReceiver.IsDead= true;
    }
}
