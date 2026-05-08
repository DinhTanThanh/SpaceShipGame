using UnityEngine;

public class AbilityMoving : Movement
{
    [SerializeField] protected Transform target;
    public Transform Target => target;
    protected override void LoadComponent()
    {
        SetLimitDistance();
        SetSpeed();
        this.target = GameObject.FindGameObjectWithTag("Player")?.transform; //GameObject.Find("Player").transform;
    }
    protected override void SetSpeed()
    {
        this.speed =0.2f;
    }
    protected override void SetLimitDistance()
    {
        this.limitDistance = 13f;
    }
    private void Update()
    {
        if (this.target == null) return;
        Vector3 posTarget = target.position;
        Moving(posTarget, posTarget);
    }
    
}
