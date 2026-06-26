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
        this.SetSpeed();
        this.SetLimitDistance(0f);
        this.target = transform.Find("Target");
        this.player = GameObject.Find("Player")?.transform;
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
            this.speed = Random.Range(0.15f, 0.25f);
        }
        else
        {
            this.speed = Random.Range(0.3f, 0.35f);
        }
    }
    private void Update()
    {
        if (this.target == null) return;
        Vector3 posTarget = this.target.position;
        if (this.player == null) return;
        Vector3 posPlayer = this.player.position;
        Moving(posTarget,posPlayer);
    }
}
