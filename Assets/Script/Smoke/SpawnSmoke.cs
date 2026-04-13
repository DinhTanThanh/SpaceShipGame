using UnityEngine;

public class SpawnSmoke : PoolPrefab
{
    [SerializeField] private GameObject smoke;
    public GameObject Smoke { get { return smoke; } }
    public static SpawnSmoke instance;
    protected override void Reset()
    {
        LoadComponent();
    }
    protected override void Awake()
    {
        LoadComponent();
        this.smoke.gameObject.SetActive(false);
        SpawnSmoke.instance= this;
    }
    protected override void LoadComponent()
    {
        if (smoke != null) return;
        this.smoke = GameObject.Find("Smoke");
    }
}
