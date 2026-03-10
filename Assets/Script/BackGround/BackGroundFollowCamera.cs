using UnityEngine;

public class BackGroundFollowCamera : FollowObject
{
    public override void SetNameObject()
    {
        this.nameObject = "Player";
        this.order = 10f;
    }
}
