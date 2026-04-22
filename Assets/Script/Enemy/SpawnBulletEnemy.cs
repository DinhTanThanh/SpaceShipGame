using UnityEngine;

public class SpawnBulletEnemy : PoolPrefab
{
    public static SpawnBulletEnemy instance;
    protected override void LoadComponent()
    {
        SpawnBulletEnemy.instance= this;
    }
}
