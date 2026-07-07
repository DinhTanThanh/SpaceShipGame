using UnityEngine;

public class SpawnSoundClick : PoolPrefab
{
    private static SpawnSoundClick instance;
    public static SpawnSoundClick Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        SpawnSoundClick.instance = this;
    }
}
