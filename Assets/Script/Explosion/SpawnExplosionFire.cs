using UnityEngine;

public class SpawnExplosionFire : PoolPrefab
{
    private static SpawnExplosionFire instance;
    public static SpawnExplosionFire Instance => instance;
    [SerializeField] protected GameObject explosionFire;
    public GameObject ExplosionFire => explosionFire;
    protected override void Awake()
    {
        base.Awake();
        SpawnExplosionFire.instance = this;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadExplosionFire();
    }
    protected virtual void LoadExplosionFire()
    {
        if (this.explosionFire != null) return;
        this.explosionFire = GameObject.Find("Explosion_Fire");
        Debug.LogWarning("Load ExplosionFire: " + transform.name);
    }
}
