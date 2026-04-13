using UnityEngine;

public class EnemyMoving : Movement
{
    [SerializeField] protected Transform target;
    public Transform Target => target;
    [SerializeField] protected float disLitmit = 3f;
    public float DisLimit => disLitmit;
    public float dis;
    protected override void LoadComponent()
    {
        SetSpeed();
        this.target = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        Vector3 posEnemy = transform.parent.position;
        Vector3 posTarget = this.target.position;
        dis = Vector3.Distance(posTarget, posEnemy);
        if (dis < disLitmit)
        {
            Direct(posTarget);
            return;
        }
        Moving(posTarget);
    }
    protected override void SetSpeed()
    {
        this.speed = 0.002f;
    }
}
