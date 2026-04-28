using UnityEngine;

public class BulletEnemyModify : BulletEnemyControllerAbstract
{
    [SerializeField] protected float speedBulletEnemy;
    public float SpeedBulletEnemy => speedBulletEnemy;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.speedBulletEnemy = 20;
        SetSpeedBulletEnemy();
    }
    protected override void Start()
    {
        base.Start();
        SetSpeedBulletEnemy();
    }
    protected virtual void SetSpeedBulletEnemy()
    {
        this.bulletEnemyController.MovingBullet.SetSpeedBullet(speedBulletEnemy);
    }
}
