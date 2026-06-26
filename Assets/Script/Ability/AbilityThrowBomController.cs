using UnityEngine;

public class AbilityThrowBomController : LoadMonoBehaviour
{
    [SerializeField] protected EnemyVController enemyV2Controller;
    public EnemyVController EnemyV2Controller => enemyV2Controller;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyV2Controller();
    }
    protected virtual void LoadEnemyV2Controller()
    {
        if (this.enemyV2Controller != null) return;
        this.enemyV2Controller = FindFirstObjectByType<EnemyVController>();
        Debug.LogWarning("Load EnemyV2Controller: "+transform.name);
    }
}
