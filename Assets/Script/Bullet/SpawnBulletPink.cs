using UnityEngine;

public class SpawnBulletPink : PoolPrefab
{
    private static SpawnBulletPink instance;
    public static SpawnBulletPink Instance => instance;
    [SerializeField] protected GameObject bulletPink;
    public GameObject BulletPink => bulletPink;
    protected override void Awake()
    {
        base.Awake();
        SpawnBulletPink.instance = this;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletPink();
    }
    protected virtual void LoadBulletPink()
    {
        if (this.bulletPink != null) return;
        this.bulletPink = GameObject.Find("Bullet_Pink");
        Debug.LogWarning("Load Bullet Pink: " + transform.name);
    }
}
