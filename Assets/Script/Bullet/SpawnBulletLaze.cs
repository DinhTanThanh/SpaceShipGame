using UnityEngine;

public class SpawnBulletLaze : PoolPrefab
{
    private static SpawnBulletLaze instance;
    public static SpawnBulletLaze Instance => instance;
    [SerializeField] protected GameObject bulletLaze;
    public GameObject BulletLaze => bulletLaze;
    protected override void Awake()
    {
        base.Awake();
        SpawnBulletLaze.instance = this;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletLaze();
    }
    protected virtual void LoadBulletLaze()
    {
        if (this.bulletLaze != null) return;
        this.bulletLaze = GameObject.Find("BulletLaze");
        Debug.LogWarning("Load BulletLaze: " + transform.name);
    }
}
