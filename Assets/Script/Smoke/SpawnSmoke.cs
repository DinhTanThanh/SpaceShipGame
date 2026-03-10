using UnityEngine;

public class SpawnSmoke : PoolPrefab
{
    [SerializeField] private GameObject smoke;
    public GameObject Smoke { get { return smoke; } }
    public static SpawnSmoke instance;
    private void Reset()
    {
        this.smoke = GameObject.Find("Smoke");
    }
    private void Awake()
    {
        this.smoke = GameObject.Find("Smoke");
        SpawnSmoke.instance= this;
    }
}
