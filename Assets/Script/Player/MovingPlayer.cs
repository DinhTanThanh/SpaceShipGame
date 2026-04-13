using UnityEngine;

public class MovingPlayer : Movement
{
    private void Update()
    {
        Moving(GetTarget());
    }
    public Vector3 GetTarget()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
