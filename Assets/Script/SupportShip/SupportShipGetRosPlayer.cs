using Unity.Mathematics;
using UnityEngine;

public class SupportShipGetRosPlayer : SupportShipControllerAbstract
{
    private void Update()
    {
        this.SetRostation(this.SupportShipController.Player.rotation);
    }
    protected virtual void SetRostation(quaternion rostation)
    {
        this.transform.parent.rotation = rostation;
    }
}
