using UnityEngine;

public class InputController : LoadComponentGame
{
    [SerializeField] protected GetPositionPoint positionPoint;
    public GetPositionPoint PositionPoint => positionPoint;
    private void Reset()
    {
        LoadComponent();
    }
    private void Awake()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {
        if (positionPoint == null)
        {
            this.positionPoint = FindFirstObjectByType<GetPositionPoint>();
        }
    }
}
