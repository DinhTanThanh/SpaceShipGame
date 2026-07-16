using UnityEngine;

public class AbilityMoving : Movement
{
    [SerializeField] protected Transform target;
    public Transform Target => target;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.SetLimitDistance(18f);
        this.SetSpeed();
        this.target = GameObject.FindGameObjectWithTag("Player")?.transform; 
    }
    protected override void SetSpeed()
    {
        this.speed =0.1f;
    }
    private void Update()
    {
        if (this.target == null) return;
        Vector3 posTarget = target.position;
        Moving(posTarget, posTarget);
    }
    
}
