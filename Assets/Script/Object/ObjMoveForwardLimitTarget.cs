using UnityEngine;

public class ObjMoveForwardLimitTarget : Movement
{
    [SerializeField] protected Transform target;
    public Transform Target => target;
    [SerializeField] protected Transform player;
    public Transform Player=> player;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        SetSpeed();
        SetLimitDistance();
        this.target = transform.Find("Target");
        this.player = GameObject.Find("Player").transform;
    }
    protected override void LoadComponentEnable()
    {
        base.LoadComponentEnable();
        SetSpeed();
    }
    protected override void SetSpeed()
    {
        this.speed = Random.Range(0.3f,0.4f);
    }
    protected override void SetLimitDistance()
    {
        this.limitDistance = 0f;
    }
    private void Update()
    {
        Vector3 posTarget = target.position;
        Vector3 posPlayer = player.position;
        Moving(posTarget,posPlayer);
    }
}
