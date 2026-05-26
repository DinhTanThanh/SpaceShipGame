using UnityEngine;

public class MoveToPlayer : FollowObject
{
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.SetSpeed(0.7f);
    }
    public override void SetNameObject()
    {
        this.nameObject = "Player";
    }
    protected override void Moving()
    {
        base.Moving();
        this.speed += 0.03f;
    }
}
