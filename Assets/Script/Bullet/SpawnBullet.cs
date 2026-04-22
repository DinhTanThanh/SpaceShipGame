using UnityEngine;

public class SpawnBullet : PoolPrefab
{
    public static SpawnBullet instance;
    protected override void LoadComponent()
    {
        SpawnBullet.instance = this;
    }
}
