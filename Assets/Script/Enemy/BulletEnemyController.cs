using UnityEngine;

public class BulletEnemyController : LoadMonoBehaviour
{
    [SerializeField] protected MovingBullet movingBullet;
    public MovingBullet MovingBullet=>movingBullet;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.movingBullet=GetComponentInChildren<MovingBullet>();
    }
}
