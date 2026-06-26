using UnityEngine;

public class SpawnBulletViolet : PoolPrefab
{
    private static SpawnBulletViolet instance;
    public static SpawnBulletViolet Instance => instance;
    [SerializeField] protected GameObject bulletViolet;
    public GameObject BulletViolet => bulletViolet;
    protected override void Awake()
    {
        base.Awake();
        SpawnBulletViolet.instance = this;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletViolet();
    }
    protected virtual void LoadBulletViolet()
    {
        if (this.bulletViolet != null) return;
        this.bulletViolet = GameObject.Find("Bullet_Violet");
        Debug.LogWarning("Load BulletViolet: " + transform.name);
    }
}
