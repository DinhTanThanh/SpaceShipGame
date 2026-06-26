using UnityEngine;

public class SpawnBulletGreen : PoolPrefab
{
    private static SpawnBulletGreen instance;
    public static SpawnBulletGreen Instance => instance;
    [SerializeField] protected GameObject bulletGreen;
    public GameObject BulletGreen => bulletGreen;
    protected override void Awake()
    {
        base.Awake();
        SpawnBulletGreen.instance = this;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletGreen();
    }
    protected virtual void LoadBulletGreen()
    {
        if (this.bulletGreen != null) return;
        this.bulletGreen = GameObject.Find("Bullet_Green");
        Debug.LogWarning("Load Bullet_Green: " + transform.name);
    }
}
