using UnityEngine;

public class GetPositionPoint : MonoBehaviour
{
    [SerializeField] protected Vector3 positionPoint;
    public Vector3 PositionPoint => positionPoint;
    private void Update()
    {
        positionPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
