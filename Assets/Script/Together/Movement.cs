using UnityEngine;

public class Movement : LoadMonoBehaviour
{
    [SerializeField] protected float limitDistance;
    public float LimitDistance => limitDistance;
    [SerializeField] protected float speed;
    public float Speed => speed;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        SetSpeed();
    }
    protected virtual void Moving(Vector3 target,Vector3 targetMouse)
    {
        if (CheckAchieveDistance(targetMouse))
        {
            Vector3 positionShip = transform.parent.position;
            Vector3 newPosition = Vector3.Lerp(positionShip, target, speed*Time.deltaTime);
            newPosition.z = 0f;
            transform.parent.position = newPosition;
        }
    }
   
    protected bool CheckAchieveDistance(Vector3 target)
    {
        float dis = Vector3.Distance(transform.parent.position, target);
        if(dis<limitDistance) return false;
        return true;
    }
    protected virtual void SetSpeed()
    {
        this.speed = 0.005f;
    }
    public virtual void SetLimitDistance(float limitDistance)
    {
        this.limitDistance = limitDistance;
    }
}
