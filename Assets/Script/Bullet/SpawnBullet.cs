using UnityEngine;

public class SpawnBullet : PoolPrefab
{
    public static SpawnBullet instance;
    protected override void Awake()
    {
        SpawnBullet.instance= this;    
    }
}
