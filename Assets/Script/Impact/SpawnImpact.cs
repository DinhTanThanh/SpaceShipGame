using UnityEngine;

public class SpawnImpact : PoolPrefab
{
    [SerializeField] private GameObject impact;
    public GameObject Impact => impact;
    public static SpawnImpact instance;
    private void Reset()
    {
        impact = GameObject.Find("Impact");
    }
    private void Awake()
    {
        SpawnImpact.instance = this;
        impact = GameObject.Find("Impact");
    }
}
