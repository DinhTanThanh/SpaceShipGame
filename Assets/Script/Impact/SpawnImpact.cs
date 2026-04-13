using UnityEngine;

public class SpawnImpact : PoolPrefab
{
    [SerializeField] private GameObject impact;
    public GameObject Impact => impact;
    public static SpawnImpact instance;
    protected override void Reset()
    {
        impact = GameObject.Find("Impact");
    }
    protected override void Awake()
    {
        SpawnImpact.instance = this;
        impact = GameObject.Find("Impact");
    }
}
