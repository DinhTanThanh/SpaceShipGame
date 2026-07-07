using UnityEngine;

public class ObjMoveForwardLimitMouse : Movement
{
    [SerializeField] protected Transform target;
    public Transform Target => target;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.SetLimitDistance(0.5f);
        this.target = transform.Find("Target");
    }
    protected override void SetSpeed()
    {
        this.speed = 5f;
    }
    private void Update()
    {
        Moving(target.position,GetTarget());
    }
    public Vector3 GetTarget()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z=Mathf.Abs(Camera.main.transform.position.z);
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
