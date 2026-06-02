using UnityEngine;
using UnityEngine.Rendering;

public class AbilityWarpCtrl : LoadMonoBehaviour
{
    [SerializeField] protected PlayerRecovery playerRecovery;
    public PlayerRecovery PlayerRecovery => playerRecovery;
    [SerializeField] protected Animator animatorTeleport;
    public Animator AnimatorTeleport => animatorTeleport;
    [SerializeField] protected PlayerController playerController;
    public PlayerController PlayerController => playerController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimatiorTeleport();
        this.LoadPlayerRecovery();
        this.LoadPlayerController();
    }
    protected virtual void LoadPlayerController()
    {
        if (this.playerController != null) return;
        this.playerController = GetComponentInParent<PlayerController>();
        Debug.LogWarning("Load PlayerController: " + transform.name);
    }
    protected virtual void LoadAnimatiorTeleport()
    {
        if (this.animatorTeleport != null) return;
        this.animatorTeleport= transform.parent.GetComponentInChildren<Animator>();
        Debug.LogWarning("Load AnimatiorTeleport: " + transform.name);
    }
    protected virtual void LoadPlayerRecovery()
    {
        if (this.playerRecovery != null) return;
        this.playerRecovery = transform.Find("Recovery").GetComponent<PlayerRecovery>();
        Debug.LogWarning("Load PlayerRecovery: " + transform.name);
    }
}
