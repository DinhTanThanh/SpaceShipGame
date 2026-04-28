using UnityEngine;

public class BulletEnemyControllerAbstract : LoadMonoBehaviour
{
    [SerializeField] protected BulletEnemyController bulletEnemyController;
    public BulletEnemyController BulletEnemyController=>bulletEnemyController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.bulletEnemyController=GetComponent <BulletEnemyController>();
    }
}
