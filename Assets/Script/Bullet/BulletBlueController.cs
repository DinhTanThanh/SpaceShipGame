using UnityEngine;

public class BulletBlueController : LoadMonoBehaviour
{
    [SerializeField] protected Transform spawnImpact;
    public Transform SpawnImpact => spawnImpact;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnImpact();
    }
    protected virtual void LoadSpawnImpact()
    {
        if (this.spawnImpact != null) return;
        this.spawnImpact = GameObject.Find("SpawnImpact")?.transform;
        Debug.LogWarning("Load SpawnImpact: " + transform.name);
    }
}
