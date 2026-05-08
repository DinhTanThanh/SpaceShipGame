using UnityEngine;

public class LookatObj : LoadMonoBehaviour
{
    [SerializeField] protected float speedRotation;
    public float SpeedRotation => speedRotation;
    protected virtual void SetRotation()
    {
        this.speedRotation = 1f;
    }
    protected virtual void Direct(Vector3 target)
    {
        Vector3 posShip = transform.parent.position;
        Vector3 newPos = target - posShip;
        newPos.Normalize();
        float dir = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        Quaternion currentRotation = transform.parent.rotation;
        Quaternion targetRotation = Quaternion.Euler(0f,0f, dir - 90);
        transform.parent.rotation= Quaternion.Lerp(currentRotation, targetRotation, speedRotation * Time.deltaTime);
    }
}
