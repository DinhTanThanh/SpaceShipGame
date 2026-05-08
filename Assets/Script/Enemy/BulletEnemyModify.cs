using UnityEngine;

public class BulletEnemyModify : BulletEnemyControllerAbstract
{
    [SerializeField] protected float speedBulletEnemy;
    public float SpeedBulletEnemy => speedBulletEnemy;
    [SerializeField] protected Vector3 directMove;
    public Vector3 DirectMove=> directMove;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.speedBulletEnemy = 25;
        SetSpeedBulletEnemy();
        this.directMove = Vector3.up;
    }
    protected override void Start()
    {
        base.Start();
        SetSpeedBulletEnemy();
    }
    protected virtual void SetSpeedBulletEnemy()
    {
        this.bulletEnemyController.MovingBullet.SetSpeedBullet(this.speedBulletEnemy);
    }
}
