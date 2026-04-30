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
        if (Random.value > 0.5)
        {
            this.speed = Random.Range(0.25f, 0.35f);
        }
        else
        {
            this.speed = Random.Range(0.4f, 0.45f);
        }
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
