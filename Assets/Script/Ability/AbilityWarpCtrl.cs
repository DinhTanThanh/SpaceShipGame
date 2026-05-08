using UnityEngine;

public class AbilityWarpCtrl : LoadMonoBehaviour
{
    [SerializeField] protected Animator animatorTeleport;
    public Animator AnimatorTeleport => animatorTeleport;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.animatorTeleport = transform.parent.GetComponentInChildren<Animator>();
    }
}
