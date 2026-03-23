using UnityEngine;

public class SpawnSmoke : PoolPrefab
{
    [SerializeField] private GameObject smoke;
    public GameObject Smoke { get { return smoke; } }
    public static SpawnSmoke instance;
    private void Reset()
    {
        LoadComponent();
    }
    private void Awake()
    {
        LoadComponent();
        this.smoke.gameObject.SetActive(false);
        SpawnSmoke.instance= this;
    }
    public void LoadComponent()
    {
        if (smoke != null) return;
        this.smoke = GameObject.Find("Smoke");
    }
}
