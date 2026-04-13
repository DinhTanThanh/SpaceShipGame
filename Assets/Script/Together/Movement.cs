using UnityEngine;

public class Movement : LoadMonoBehaviour
{
    [SerializeField] protected float speed;
    public float Speed => speed;
    protected override void LoadComponent()
    {
        SetSpeed();
    }
    protected void Moving(Vector3 target)
    {
        Vector3 positionShip = transform.parent.position;
        Vector3 newPosition = Vector3.Lerp(transform.parent.position, target, speed);
        newPosition.z = 0f;
        transform.parent.position = newPosition;
        Direct(target);
    }
    protected void Direct(Vector3 target)
    {
        Vector3 posShip = transform.parent.position;
        Vector3 newPos = target - posShip;
        float dir = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0, 0, dir - 90);
    }
    protected virtual void SetSpeed()
    {
        this.speed = 0.005f;
    }
}
