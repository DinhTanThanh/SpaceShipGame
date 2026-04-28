using UnityEngine;

public abstract class LoadEnemyCtrlAbstract : LoadMonoBehaviour
{
    [SerializeField] protected EnemyController enemyController;
    public EnemyController EnemyController => enemyController;
    protected override void LoadComponent()
    {
        if (enemyController != null) return;
        this.enemyController=GetComponentInParent<EnemyController>();
    }
}
