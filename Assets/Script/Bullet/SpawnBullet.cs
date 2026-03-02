using UnityEngine;

public class SpawnBullet : PoolPrefab
{
    public static SpawnBullet instance;
    private void Awake()
    {
        SpawnBullet.instance= this;    
    }
}
