using UnityEngine;

public class EnemyV2Controller : LoadMonoBehaviour
{
    [SerializeField] protected ShootingSO enemyV2SO;
    public ShootingSO EnemyV2SO => enemyV2SO;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySO();
    }
    protected virtual void LoadEnemySO()
    {
        if (this.enemyV2SO != null) return;
        string path = "Shooting/Enemy/" + transform.name;
        this.enemyV2SO = Resources.Load<ShootingSO>(path);
        Debug.LogWarning("Load EnemyV2SO: " + transform.name);
    }
}
