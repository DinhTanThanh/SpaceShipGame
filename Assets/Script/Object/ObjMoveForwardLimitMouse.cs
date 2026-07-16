using UnityEngine;

public class ObjMoveForwardLimitMouse : Movement
{
    [SerializeField] protected Transform target;
    [SerializeField] protected PlayerController playerController;
    public Transform Target => target;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.SetLimitDistance(4f);
        this.LoadTarget();
        this.LoadPlayerController();
    }
    protected virtual void LoadPlayerController()
    {
        if (this.playerController != null) return;
        this.playerController = GetComponentInParent<PlayerController>();
        Debug.LogWarning("Load PlayerController: " + transform.name);
    }
    protected virtual void LoadTarget()
    {
        if (this.target != null) return;
        this.target = transform.Find("Target");
        Debug.LogWarning("Load Target: " + transform.name);
    }
    protected override void SetSpeed()
    {
        this.speed = 4f;
    }
    private void Update()
    {
        if (this.playerController.PlayerPushBack.IsCollision)
        {
            this.playerController.PlayerPushBack.PushBack();
            return;
        }
        this.Moving(this.target.position,this.GetTarget());
    }
    public Vector3 GetTarget()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z=Mathf.Abs(Camera.main.transform.position.z);
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
