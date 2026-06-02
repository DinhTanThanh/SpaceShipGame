using UnityEngine;

public class SupportShipMoving : FollowObject
{
    protected override void Reset()
    {
        base.Reset();
        this.SetSpeed(5f);
    }
    protected override void Awake()
    {
        base.Awake();
        this.SetSpeed(5f);
    }
    public override void SetNameObject()
    {
        this.nameObject = "SupportPos";
    }
}
