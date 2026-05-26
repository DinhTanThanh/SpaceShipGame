using UnityEngine;

public class SpawnExplosion : PoolPrefab
{
    private static SpawnExplosion instance;
    public static SpawnExplosion Instance => instance;
    [SerializeField] protected GameObject explosion;
    public GameObject Explosion => explosion;
    protected override void Awake()
    {
        base.Awake();
        SpawnExplosion.instance = this;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadExplosion();
    }
    protected virtual void LoadExplosion()
    {
        if (this.explosion != null) return;
        this.explosion = GameObject.Find("Explosion");
        Debug.LogWarning("Load Explosion: " + transform.name);
    }
}
