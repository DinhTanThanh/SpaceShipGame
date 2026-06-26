using UnityEngine;

public class BulletVioletController : LoadMonoBehaviour
{
    [SerializeField] protected MovingBullet movingBullet;
    [SerializeField] protected Transform spawnImpact;
    public Transform SpawnImpact => spawnImpact;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnImpact();
        this.LoadMovingBullet();
    }
    protected virtual void LoadMovingBullet()
    {
        if (this.movingBullet != null) return;
        this.movingBullet = GetComponentInChildren<MovingBullet>();
        this.movingBullet.SetSpeedBullet(20f);
        Debug.LogWarning("Load MovingBullet: " + transform.name);
    }
    protected virtual void LoadSpawnImpact()
    {
        if (this.spawnImpact != null) return;
        this.spawnImpact = GameObject.Find("SpawnImpact")?.transform;
        Debug.LogWarning("Load SpawnImpact: " + transform.name);
    }
}
