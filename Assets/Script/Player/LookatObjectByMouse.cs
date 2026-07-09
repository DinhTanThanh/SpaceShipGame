using UnityEngine;

public class LookatObjectByMouse : LookatObj
{
    private void Update()
    {
        this.Direct(GetTarget());
    }
    public Vector3 GetTarget()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    protected override void Direct(Vector3 target)
    {
        Vector3 posShip = transform.parent.position;
        Vector3 newPos = target - posShip;
        newPos.Normalize();
        float dir = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0, 0, dir - 90);
    }
}
