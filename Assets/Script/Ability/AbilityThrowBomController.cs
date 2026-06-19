using UnityEngine;

public class AbilityThrowBomController : LoadMonoBehaviour
{
    [SerializeField] protected EnemyV2Controller enemyV2Controller;
    public EnemyV2Controller EnemyV2Controller => enemyV2Controller;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyV2Controller();
    }
    protected virtual void LoadEnemyV2Controller()
    {
        if (this.enemyV2Controller != null) return;
        this.enemyV2Controller = FindFirstObjectByType<EnemyV2Controller>();
        Debug.LogWarning("Load EnemyV2Controller: "+transform.name);
    }
}
