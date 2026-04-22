using UnityEngine;

public class PlayerBeenPosition : ObjectBeenPosition
{
    [SerializeField] protected float speed;
    public float Speed => speed;
    protected override void Reset()
    {
        LoadComponent();
    }
    protected override void Awake()
    {
        LoadComponent();
    }
    protected override void LoadComponent()
    {
        this.speed = 3f;
        GetNameGameObjectPosition();
    }
    private void Update()
    {
        MovingToPosition();
    }
    protected void MovingToPosition()
    {
        Vector3 pos = Vector3.Lerp(transform.parent.position, gameObjectPosition.transform.position, Time.deltaTime*speed);
        transform.parent.position = pos;
        transform.parent.rotation=gameObjectPosition.transform.rotation;
    }
}
