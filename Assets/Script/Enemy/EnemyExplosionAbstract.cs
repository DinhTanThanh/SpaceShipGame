using UnityEngine;

public class EnemyExplosionAbstract : LoadMonoBehaviour
{
    [SerializeField] protected EnemyExplosionController enemyExplosionController;
    public EnemyExplosionController EnemyExplosionController => enemyExplosionController;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyExplosionController();
    }
    protected virtual void LoadEnemyExplosionController()
    {
        if (this.enemyExplosionController != null) return;
        this.enemyExplosionController = GetComponentInParent<EnemyExplosionController>();
        Debug.LogWarning("Load EnemyExplosionController: " + transform.name);
    }
}
