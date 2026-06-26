using UnityEngine;

public class SpawnBulletYellow : PoolPrefab
{
    private static SpawnBulletYellow instance;
    public static SpawnBulletYellow Instance => instance;
    [SerializeField] protected GameObject bulletYellow;
    public GameObject BulletYellow => bulletYellow;
    protected override void Awake()
    {
        base.Awake();
        SpawnBulletYellow.instance = this;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletViolet();
    }
    protected virtual void LoadBulletViolet()
    {
        if (this.bulletYellow != null) return;
        this.bulletYellow = GameObject.Find("Bullet_Yellow");
        Debug.LogWarning("Load bulletYellow: " + transform.name);
    }
}
