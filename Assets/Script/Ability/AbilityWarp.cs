using UnityEngine;

public class AbilityWarp : BaseAbility
{
    protected Vector4 keyDirection;
    public Vector4 KeyDirection => keyDirection;
    [SerializeField] protected Vector4 warpDirection;
    public Vector4 WarpDirection => warpDirection;
    [SerializeField] protected float warpSpeed;
    public float WarpSpeed=> warpSpeed;
    [SerializeField] protected Animator teleport;
    public Animator Teleport=> teleport;
    protected override void Awake()
    {
        base.Awake();
        EndAnimationTelePort();
    }
    private void FixedUpdate()
    {
        if (isReady) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.timeDelay) return;
        this.timer = 0f;
        this.isReady = true;
    }
    protected virtual void Update()
    {
        CheckWarpDirection();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        SetWarpSpeed();
        SetDelayTimer();
    }
    protected void EndAnimationTelePort()
    {
        this.teleport.SetBool("isTeleporting", false);
    }
    protected void StartAnimationTeleport()
    {
        this.teleport.SetBool("isTeleporting",true);
    }
    protected virtual void ResetWarpDirection()
    {
        this.warpDirection = Vector4.zero;
        this.isReady = false;
    }
    protected virtual void SetWarpSpeed()
    {
        this.warpSpeed = 12f;
    }
    protected virtual void SetWarpDirection()
    {
        if (this.keyDirection.x == 1) WarpLeft();
        if (this.keyDirection.y == 1) WarpRight();
        if (this.keyDirection.z == 1) WarpUp();
        if (this.keyDirection.w == 1) WarpDown();
    }
    protected virtual bool IsDirectionNoSet()
    {
        if(this.warpDirection.x==0 && this.warpDirection.y==0
            &&this.warpDirection.z==0 && this.warpDirection.w==0) return true;
        return false;
    }
    protected virtual void CheckWarpDirection()
    {
        if (!this.IsReady) return;
        SetWarpDirection();
        if (IsDirectionNoSet()) return;
        StartAnimationTeleport();
        Invoke("Warping", 0.1f);
    }

    protected virtual void WarpLeft()
    {
        this.warpDirection.x = 1;
    }
    protected virtual void WarpRight()
    {
        this.warpDirection.y = 1;
    }
    protected virtual void WarpUp()
    {
        this.warpDirection.z = 1;
    }
    protected virtual void WarpDown()
    {
        this.warpDirection.w = 1;
    }
   
    protected override void SetDelayTimer()
    {
        this.timer = 0f;
        this.timeDelay = 1.2f;
    }
    protected virtual void Warping()
    {
        if (this.WarpDirection.z == 1) transform.parent.parent.position += new Vector3(0, 1*this.warpSpeed, 0);
        if (this.WarpDirection.w == 1) transform.parent.parent.position += new Vector3(0, -1*this.warpSpeed, 0);
        if (this.WarpDirection.x == 1) transform.parent.parent.position += new Vector3(-1*this.warpSpeed, 0, 0);
        if (this.WarpDirection.y == 1) transform.parent.parent.position += new Vector3(1*this.warpSpeed, 0, 0);
        ResetWarpDirection();
        EndAnimationTelePort();
    }
}
