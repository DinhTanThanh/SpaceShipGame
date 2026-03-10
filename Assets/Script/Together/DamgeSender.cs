using UnityEngine;

public class DamgeSender : MonoBehaviour
{
    public void SendDame(MeoteoriteDamereceiver prefabObject)
    {
        prefabObject.Receiver(1);
        if (prefabObject.HP <= 0)
        {
            prefabObject.IsDead= true;
        }
    }
}
